#!/bin/bash

# 颜色定义
RED='\033[0;31m'
GREEN='\033[0;32m'
YELLOW='\033[1;33m'
NC='\033[0m' # 无色彩

# 错误处理
set -euo pipefail

# 总步骤数
TOTAL_STEPS=14
CURRENT_STEP=0

# 是否跳过推送操作（步骤 13）
SKIP_PUSH=false

# 日志函数
log() {
    local message="$1"
    local color="$2"
    local prefix="$3"
    local step="$4"

    # 计算进度百分比
    local progress=$(( (CURRENT_STEP * 100) / TOTAL_STEPS ))

    # 输出日志
    echo -e "${color}${prefix} [${progress}%] 步骤 ${step}/${TOTAL_STEPS}: ${message}${NC}"
}

# 检查 Unity Editor 是否正在运行
check_unity_running() {
    log "检查 Unity Editor 是否正在运行..." "$YELLOW" "[INFO]" "$CURRENT_STEP"

    # 检查 Unity 进程（跨平台）
    if [[ "$OSTYPE" == "linux-gnu"* || "$OSTYPE" == "darwin"* ]]; then
        if pgrep -x "Unity" > /dev/null; then
            log "检测到 Unity Editor 正在运行，请关闭后重试" "$RED" "[ERROR]" "$CURRENT_STEP"
            exit 1
        fi
    elif [[ "$OSTYPE" == "msys" || "$OSTYPE" == "cygwin" || "$OSTYPE" == "win32" ]]; then
        if tasklist | grep -i "Unity.exe" > /dev/null; then
            log "检测到 Unity Editor 正在运行，请关闭后重试" "$RED" "[ERROR]" "$CURRENT_STEP"
            exit 1
        fi
    else
        log "无法检测 Unity Editor 是否运行，未知的操作系统类型: $OSTYPE" "$RED" "[ERROR]" "$CURRENT_STEP"
        exit 1
    fi

    log "Unity Editor 未运行，检查通过" "$GREEN" "[INFO]" "$CURRENT_STEP"
}

# 检查当前分支是否为 develop
check_branch() {
    local current_branch
    current_branch=$(git rev-parse --abbrev-ref HEAD)
    log "当前分支为 $current_branch" "$YELLOW" "[INFO]" "$CURRENT_STEP"

    if [ "$current_branch" != "develop" ]; then
        log "当前分支不是 develop，请切换到 develop 分支后重试" "$RED" "[ERROR]" "$CURRENT_STEP"
        exit 1
    fi

    log "当前分支为 develop，检查通过" "$GREEN" "[INFO]" "$CURRENT_STEP"
}

# 检查是否有未提交的更改
check_uncommitted_changes() {
    if [ -n "$(git status --porcelain)" ]; then
        log "检测到未提交的更改，请提交或暂存后再运行脚本" "$RED" "[ERROR]" "$CURRENT_STEP"
        exit 1
    fi

    log "没有未提交的更改，检查通过" "$GREEN" "[INFO]" "$CURRENT_STEP"
}

# 获取最后一次提交信息
get_last_commit_message() {
    git log -1 --pretty=%B
}

# 获取版本号（从 Assets/package.json 中获取）
get_version() {
    # 使用 grep 和 sed 从 Assets/package.json 获取版本号
    local version
    version=$(grep -o '"version": "[^"]*"' Assets/package.json | sed 's/"version": "\(.*\)"/\1/')
    if [ -z "$version" ]; then
        log "无法从 Assets/package.json 读取版本号" "$RED" "[ERROR]" "$CURRENT_STEP"
        exit 1
    fi
    echo "$version"
}

# 安全复制函数
safe_copy() {
    local src="$1"
    local dest="$2"

    if cp -r "$src" "$dest"; then
        log "成功复制 $src 到 $dest" "$GREEN" "[INFO]" "$CURRENT_STEP"
    else
        log "复制 $src 到 $dest 失败" "$RED" "[ERROR]" "$CURRENT_STEP"
        exit 1
    fi
}

# 安全执行步骤的函数
safe_execute() {
    local step="$1"
    local description="$2"
    local command="$3"

    while true; do
        CURRENT_STEP=$step
        log "$description" "$YELLOW" "[INFO]" "$CURRENT_STEP"
        if eval "$command"; then
            log "$description 成功" "$GREEN" "[INFO]" "$CURRENT_STEP"
            break
        else
            retry_or_exit "$step" "$description"
        fi
    done
}

# 失败后提供重试或退出选项
retry_or_exit() {
    local step="$1"
    local message="$2"

    echo -e "${RED}步骤 $step 失败: $message${NC}"
    while true; do
        echo -e "${YELLOW}请选择: [r] 重试 / [q] 退出${NC}"
        read -rp "输入选择: " choice
        case "$choice" in
            r|R)
                echo -e "${YELLOW}重试步骤 $step...${NC}"
                return 0 # 返回 0 表示继续重试
                ;;
            q|Q)
                echo -e "${RED}退出脚本...${NC}"
                exit 1
                ;;
            *)
                echo -e "${RED}无效选择，请输入 'r' 或 'q'${NC}"
                ;;
        esac
    done
}

# 主流程
main() {
    echo -e "${YELLOW}开始 UPM 包发布流程...${NC}"

    # 询问是否跳过推送操作
    echo -e "${YELLOW}是否跳过推送操作（用于测试）？[y/N]${NC}"
    read -rp "输入选择: " skip_push_choice
    if [[ "$skip_push_choice" =~ ^[yY]$ ]]; then
        SKIP_PUSH=true
        echo -e "${YELLOW}推送操作将被跳过${NC}"
    fi

    # 步骤 1: 检查 Unity Editor 是否正在运行
    safe_execute 1 "检查 Unity Editor 是否正在运行" "check_unity_running"

    # 步骤 2: 检查当前分支
    safe_execute 2 "检查当前分支" "check_branch"

    # 步骤 3: 检查是否有未提交的更改
    safe_execute 3 "检查未提交的更改" "check_uncommitted_changes"

    # 步骤 4: 获取最后一次提交信息
    safe_execute 4 "获取最后一次提交信息" 'COMMIT_MSG=$(get_last_commit_message)'

    # 步骤 5: 获取版本号
    safe_execute 5 "获取版本号" 'VERSION=$(get_version)'

    # 步骤 6: 创建临时目录
    safe_execute 6 "创建临时目录" 'TEMP_DIR=$(mktemp -d)'

    # 步骤 7: 复制 Assets 目录下的内容到临时目录
    safe_execute 7 "复制 Assets 目录下的内容到临时目录" 'safe_copy "Assets/." "$TEMP_DIR"'

    # 步骤 8: 切换到 main 分支
    safe_execute 8 "切换到 main 分支" "git checkout main"

    # 步骤 9: 清理当前目录（保留 .git 和 package.json）
    safe_execute 9 "清理当前目录" 'find . -mindepth 1 -maxdepth 1 ! -name ".git" ! -name "package.json" -exec rm -rf {} +'

    # 步骤 10: 将临时目录的文件复制到主目录
    safe_execute 10 "复制临时目录的内容到主目录" 'cp -r "$TEMP_DIR"/. ./'

    # 步骤 11: 删除临时目录
    safe_execute 11 "删除临时目录" 'rm -rf "$TEMP_DIR"'

    # 步骤 12: 提交更改并创建 tag
    safe_execute 12 "提交更改并创建 tag" 'git add . && git commit -m "chore: release version $VERSION" && git tag -a "v$VERSION" -m "Release version $VERSION"'

    # 步骤 13: 推送更改和 tag 到远程（可选）
    if [ "$SKIP_PUSH" = false ]; then
        safe_execute 13 "推送更改和 tag 到远程" 'git push origin main && git push origin "v$VERSION"'
    else
        log "跳过推送操作（测试模式）" "$YELLOW" "[INFO]" 13
    fi

    # 步骤 14: 切回 develop 分支并更新提交信息
    safe_execute 14 "切回 develop 分支并更新提交信息" 'git checkout develop && git commit --amend -m "$COMMIT_MSG\n\nv$VERSION released" && git push origin develop --force'

    log "完成！已发布版本 v$VERSION" "$GREEN" "[INFO]" "$CURRENT_STEP"
}

# 执行主流程
main