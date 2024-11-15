# Grow.Extensions

[English](README.md) | [简体中文](README.zh-CN.md)

Extensions package for Grow Framework

## Overview
A collection of useful extensions methods for Unity development, designed to enhance productivity and code readability.

## Installation

### Via Unity Package Manager
1. Open the Package Manager window
2. Click the "+" button in the top-left corner
3. Select "Add package from git URL..."
4. Enter: `https://github.com/RonnyWu/Grow.Extensions.git#v0.0.1`

### Via manifest.json
Add the following line to your `manifest.json` under the `dependencies` section:
```json
{
    "com.ronny.grow.extensions": "https://github.com/RonnyWu/Grow.Extensions.git#v0.0.1"
}
```

## Features
- ToXxx family of extension functions
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

## Usage Examples
```csharp
using Grow.Extensions;

var value = -666;
Debug.Log(source.ToAbs()); // returns 666
```

## Requirements
- Unity 2023.2 or later
- No third-party dependencies

## Documentation
You can check the API documentation first, so far it's all simple methods

## Contributing
Contributions are welcome! Please feel free to submit a Pull Request.

## Changelog
See [CHANGELOG](CHANGELOG.md) for details about changes in each release.

## License
This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.