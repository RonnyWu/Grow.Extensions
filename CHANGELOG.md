# Changelog
All notable changes to this package will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),  
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [v0.0.1]

### Added
- Initial package setup
- Basic project structure
- ToXxx family of extension functions added
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