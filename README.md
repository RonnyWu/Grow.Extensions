# Grow.Extensions

## Status
[![Unity](https://img.shields.io/badge/unity-2021.3%2B-blue?logo=unity)](https://unity.com/)
[![.NET](https://img.shields.io/badge/.NET-Standard%202.1-512BD4?logo=.net)](https://dotnet.microsoft.com/)
[![License](https://img.shields.io/github/license/RonnyWu/Grow.Extensions)](LICENSE)
[![Release](https://img.shields.io/github/v/release/RonnyWu/Grow.Extensions)](https://github.com/RonnyWu/Grow.Extensions/releases)
[![Code Size](https://img.shields.io/github/languages/code-size/RonnyWu/Grow.Extensions)](https://github.com/RonnyWu/Grow.Extensions)

[English](README.md) | [简体中文](README.zh-CN.md)

## Overview
Grow.Extensions is a lightweight, zero-dependency extension library for Unity, providing a comprehensive set of type conversion and utility methods to enhance development efficiency.

## Features

### Type Conversion Extensions
Provides extensive type conversion methods across various data types:

#### Numeric Conversions
- **Integer Types** (`int`, `long`, `short`)
  ```csharp
  int value = -123;
  long longVal = value.ToLong();     // Convert to long
  float floatVal = value.ToFloat();  // Convert to float
  decimal decVal = value.ToDecimal(); // Convert to decimal
  int absVal = value.ToAbs();        // Get absolute value
  ```

#### Floating Point Conversions
- **Decimal & Floating Types** (`float`, `double`, `decimal`)
  ```csharp
  decimal price = 123.456m;
  string currency = price.ToCurrency();        // "123.46"
  string percent = price.ToPercentage();       // "123.46%"
  decimal rounded = price.ToRound();           // 123
  ```

#### Basic Type Conversions
- **Common Types** (`bool`, `byte`, `char`, `string`)
  ```csharp
  string dateStr = "2024-01-01";
  DateTime date = dateStr.ToDateTime();  // Convert to DateTime
  
  byte value = 65;
  char charVal = value.ToChar();        // Convert to char 'A'
  string hexVal = value.ToHex();        // Convert to hex "41"
  ```

## Installation

### Option 1: Unity Package Manager (Recommended)
1. Open the Package Manager window (Window > Package Manager)
2. Click the "+" button in the top-left corner
3. Select "Add package from git URL"
4. Enter the repository URL : `https://github.com/RonnyWu/Grow.Extensions.git`
5. Click "Add"

### Option 2: Manifest.json
Add the following line to your `Packages/manifest.json`:
```json
{
  "dependencies": {
    "com.ronny.grow.extensions": "https://github.com/RonnyWu/Grow.Extensions.git"
  }
}
```

### Option 3: Local Import
1. Download or clone this repository
2. Extract the archive if needed
3. In Unity, open Package Manager (Window > Package Manager)
4. Click the "+" button and choose "Add package from disk"
5. Navigate to and select the `package.json` file in the downloaded/cloned folder
6. Click "Open"

### Version Control
- To lock to a specific version, append `#v{version}` to the URL (e.g. `https://github.com/RonnyWu/Grow.Extensions.git#v1.2.3`)
- To use the latest version, omit the version tag
- View all available versions on the [releases page](https://github.com/RonnyWu/Grow.Extensions/releases)

## Requirements
- Unity 2021.3 or higher
- .NET Standard 2.1
- No external dependencies

## Documentation
- [API Documentation](https://github.com/RonnyWu/Grow.Extensions/wiki)
- [Changelog](CHANGELOG.md)
- [Examples](Samples~/TypeConversion)

## Contributing
Contributions are welcome! Please feel free to:
- Submit [bug reports](https://github.com/RonnyWu/Grow.Extensions/issues)
- Submit [pull requests](https://github.com/RonnyWu/Grow.Extensions/pulls)
- Suggest new features

## License
This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Contact
- Author: Ronny Wu
- Email: ronnywu.pe@gmail.com
- GitHub: [@RonnyWu](https://github.com/RonnyWu)