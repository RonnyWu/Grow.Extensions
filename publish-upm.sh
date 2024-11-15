#!/bin/bash

# 颜色定义
RED='\033[0;31m'
GREEN='\033[0;32m'
YELLOW='\033[1;33m'
NC='\033[0m' # No Color

# 错误处理
set -e

echo -e "${YELLOW}开始 UPM 包发布流程...${NC}"

# 检查当前分支
CURRENT_BRANCH=$(git symbolic-ref --short HEAD)
if [ "$CURRENT_BRANCH" != "develop" ]; then
    echo -e "${RED}错误: 请先切换到 develop 分支${NC}"
    exit 1
fi

# 检查是否有未提交的更改
if ! git diff-index --quiet HEAD --; then
    echo -e "${RED}错误: 有未提交的更改，请先提交${NC}"
    exit 1
fi

# 获取最后一次提交信息
COMMIT_MSG=$(git log -1 --pretty=%B)

# 获取当前版本号
VERSION=$(node -p "require('./package.json').version")
echo -e "${GREEN}准备发布版本: $VERSION${NC}"

# 创建临时目录
TEMP_DIR=$(mktemp -d)
echo -e "${GREEN}创建临时目录: $TEMP_DIR${NC}"

# 复制文件到临时目录
echo -e "${GREEN}复制文件到临时目录...${NC}"
cp -r Assets/Documentation~ "$TEMP_DIR/"
cp -r Assets/Editor "$TEMP_DIR/"
cp -r Assets/Runtime "$TEMP_DIR/"
cp -r Assets/Samples~ "$TEMP_DIR/"
cp -r Assets/Tests "$TEMP_DIR/"
cp Assets/CHANGELOG.md "$TEMP_DIR/"

# 保存其他必要文件
cp package.json "$TEMP_DIR/"
cp README.md "$TEMP_DIR/"
cp README.zh-CN.md "$TEMP_DIR/"
cp LICENSE "$TEMP_DIR/"

# 切换到 main 分支
echo -e "${GREEN}切换到 main 分支...${NC}"
git checkout main

# 清理当前目录（保留 .git）
echo -e "${GREEN}清理当前目录...${NC}"
find . -mindepth 1 -maxdepth 1 ! -name '.git' -exec rm -rf {} +

# 复制文件到主目录
echo -e "${GREEN}复制文件到主目录...${NC}"
cp -r "$TEMP_DIR"/* ./

# 删除临时目录
rm -rf "$TEMP_DIR"

# 添加所有更改
git add .

# 提交更改
echo -e "${GREEN}提交更改...${NC}"
git commit -m "chore: release version $VERSION"

# 创建新的 tag
echo -e "${GREEN}创建新的 tag v$VERSION...${NC}"
git tag -a "v$VERSION" -m "Release version $VERSION"

# 推送更改和 tag
echo -e "${GREEN}推送更改和 tag 到远程...${NC}"
git push origin main
git push origin "v$VERSION"

# 切回 develop 分支
echo -e "${GREEN}切回 develop 分支...${NC}"
git checkout develop

# 更新提交信息并推送
echo -e "${GREEN}更新提交信息并推送...${NC}"
git commit --amend -m "$COMMIT_MSG

v$VERSION 版本已发布"
git push origin develop --force

echo -e "${GREEN}完成！${NC}"
echo -e "${GREEN}已发布版本 v$VERSION${NC}"