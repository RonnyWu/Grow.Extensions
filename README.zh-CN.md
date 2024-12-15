# Grow.Extensions

## 状态
[![Unity](https://img.shields.io/badge/unity-2021.3%2B-blue?logo=unity)](https://unity.com/)
[![.NET](https://img.shields.io/badge/.NET-Standard%202.1-512BD4?logo=.net)](https://dotnet.microsoft.com/)
[![License](https://img.shields.io/github/license/RonnyWu/Grow.Extensions)](LICENSE)
[![Release](https://img.shields.io/github/v/release/RonnyWu/Grow.Extensions)](https://github.com/RonnyWu/Grow.Extensions/releases)
[![Code Size](https://img.shields.io/github/languages/code-size/RonnyWu/Grow.Extensions)](https://github.com/RonnyWu/Grow.Extensions)

[English](README.md) | [简体中文](README.zh-CN.md)

## 概述
Grow.Extensions 是一个轻量级的 Unity 扩展库，无需任何依赖，提供全面的类型转换和实用工具方法，旨在提高开发效率。

## 特性

### 类型转换扩展
提供多种数据类型间的转换方法：

#### 数值转换
- **整数类型** (`int`, `long`, `short`)
  ```csharp
  int value = -123;
  long longVal = value.ToLong();     // 转换为 long
  float floatVal = value.ToFloat();  // 转换为 float
  decimal decVal = value.ToDecimal(); // 转换为 decimal
  int absVal = value.ToAbs();        // 获取绝对值
  ```

#### 浮点数转换
- **小数和浮点类型** (`float`, `double`, `decimal`)
  ```csharp
  decimal price = 123.456m;
  string currency = price.ToCurrency();        // "123.46"
  string percent = price.ToPercentage();       // "123.46%"
  decimal rounded = price.ToRound();           // 123
  ```

#### 基础类型转换
- **常用类型** (`bool`, `byte`, `char`, `string`)
  ```csharp
  string dateStr = "2024-01-01";
  DateTime date = dateStr.ToDateTime();  // 转换为 DateTime
  
  byte value = 65;
  char charVal = value.ToChar();        // 转换为字符 'A'
  string hexVal = value.ToHex();        // 转换为十六进制 "41"
  ```

## 安装方法

### 通过 Unity Package Manager
```
https://github.com/RonnyWu/Grow.Extensions.git#v0.0.1
```

### 通过 manifest.json
```json
{
  "dependencies": {
    "com.ronny.grow.extensions": "https://github.com/RonnyWu/Grow.Extensions.git#v0.0.1"
  }
}
```

## 环境要求
- Unity 2021.3 或更高版本
- .NET Standard 2.1
- 无外部依赖

## 文档
- [API 文档](https://github.com/RonnyWu/Grow.Extensions/wiki)
- [更新日志](CHANGELOG.md)
- [示例代码](Samples~/TypeConversion)

## 参与贡献
欢迎参与项目贡献！你可以：
- 提交 [Bug 报告](https://github.com/RonnyWu/Grow.Extensions/issues)
- 提交 [Pull Request](https://github.com/RonnyWu/Grow.Extensions/pulls)
- 提出新功能建议

## 开源协议
本项目采用 MIT 协议 - 详见 [LICENSE](LICENSE) 文件

## 联系方式
- 作者：Ronny Wu
- 邮箱：ronnywu.pe@gmail.com
- GitHub：[@RonnyWu](https://github.com/RonnyWu)