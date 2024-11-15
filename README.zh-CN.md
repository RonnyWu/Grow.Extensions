# Grow.Extensions

[English](README.md) | [简体中文](README.zh-CN.md)

Grow框架的扩展包

## 概述
一组有用的扩展方法，用于Unity开发，旨在提高生产力和代码可读性。

## 安装

### 通过Unity包管理器
1. 打开包管理器窗口
2. 点击左上角的“+”按钮
3. 选择“Add package from git URL…”
4. 输入: `https://github.com/RonnyWu/Grow.Extensions.git#v0.0.1`

### 通过manifest.json
将下面这行添加到你的 `manifest.json`  `dependencies` 部分下:
```json
{
    "com.ronny.grow.extensions": "https://github.com/RonnyWu/Grow.Extensions.git#v0.0.1"
}
```

## 特性
- ToXxx 系列扩展函数
    - bool : `ToInt()`
    - byte : `ToInt()`, `ToChar()`, `ToHex()`
    - char : `ToInt()`, `ToByte()`
    - decimal : `ToInt()`, `ToLong()`, `ToDouble()`, `ToRound()`, `ToAbs()`, `ToCeiling()`, `ToFloor()`, `ToFixed()`, `ToCurrency()`, `ToCurrencyWithSymbol()`, `ToPercentage()`
    - double : `ToInt()`, `ToLong()`, `ToDecimal()`, `ToRound()`, `ToAbs()`, `ToCeiling()`, `ToFloor()`, `ToFixed()`, `ToPercentage()`
    - float : `ToInt()`, `ToLong()`, `ToDouble()`, `ToDecimal()`, `ToRound()`, `ToAbs()`, `ToCeiling()`, `ToFloor()`, `ToFixed()`, `ToPercentage()`
    - int : `ToLong()`, `ToFloat()`, `ToDouble()`, `ToDecimal()`, `ToAbs()`, `ToFixed()`
    - long : `ToInt()`, `ToFloat()`, `ToDouble()`, `ToDecimal()`, `ToAbs()`, `ToFixed()`
    - short : `ToInt()`, `ToLong()`, `ToFloat()`, `ToDouble()`, `ToDecimal()`, `ToAbs()`, `ToFixed()`
    - string : `ToInt()`, `ToLong()`, `ToFloat()`, `ToDouble()`, `ToDecimal()`, `ToBool()`, `ToDateTime()`

## 用法示例
```csharp
using Grow.Extensions;

var value = -666;
Debug.Log(source.ToAbs()); // returns 666
```

## 需求
- Unity 2023.2或更高版本
- 无第三方依赖

## 文档
你可以先查看API文档，到目前为止都是简单的方法

## 贡献
欢迎投稿！欢迎随时提交Pull Request。

## 更新日志
请参阅 [CHANGELOG](CHANGELOG.md) 了解每个版本中更改的详细信息。

## 许可证
本项目使用麻省理工学院（MIT）许可协议，详情请参阅 [LICENSE](LICENSE) 文件。