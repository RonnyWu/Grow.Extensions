# Changelog
All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [0.0.4] - 2024-12-11

### Added
- Added `ToCeilingSyntax` for ceiling value calculations
- Added `ToRoundSyntax` for numeric rounding operations
- Added `ToRemapSyntax` for range transformation
- Added `ToPercentageSyntax` for percentage formatting
- Added `ToNormalizeSyntax` for range normalization
- Added `ToFloorSyntax` for floor value calculations
- Added `ToFixedSyntax` for precise decimal place formatting
- Added `ToClampSyntax` for value range constraints
- Added `ToAbsSyntax` for type-safe absolute value operations
- Added hybrid `FormatCache` for optimized number formatting
- Added `CONTRIBUTING.md` and `CODE_OF_CONDUCT.md` files

### Changed
- Renamed Documentation~ and Samples~ to standard directory names
- Updated code formatting and style configurations

### Removed
- Removed deprecated code in new version

### Added (Documentation)
- Updated issue templates

# [0.0.3] - 2024-12-06

### Features
- Add comprehensive numeric type conversion extensions
  - ToFloat: Support all primitive types with range validation and precision handling
  - ToShort: Support all primitive types with overflow protection
  - ToLong: Support all primitive types with range validation
  - ToInt: Support all primitive types with boundary checks

### Refactor
- Remove redundant and duplicate conversion methods while maintaining API compatibility

### Style
- Format numeric conversion syntax methods for better readability
  - ToDoubleSyntax
  - ToBinaryStringSyntax
  - ToHexStringSyntax

### Chore
- Upgrade Unity version from 2021.3.43f1 to 2021.3.45f1

## [0.0.2] - 2024-11-29

### Added
- **Byte Conversion Suite**
  - **ToByteSyntax**: Single byte conversion
    - Optimized conversion for all primitive types (1/8/16/32/64/128-bit)
    - Consistent default value handling
    - Complete nullable type support
    - Proper boundary checking and floating-point handling

  - **ToByteArraySyntax**: Byte array conversion
    - Zero-allocation implementation using stackalloc
    - Direct memory marshalling for primitive types
    - Optimized decimal conversion with precision preservation
    - Efficient string encoding with automatic memory management
    - Stack allocation optimization for small inputs

- **String Representation Suite**
  - **ToBinaryStringSyntax**: Binary format
    - O(1) lookup-based conversion for numeric types
    - IEEE 754 floating-point support
    - Optimized memory usage with stackalloc
    - Efficient byte array handling

  - **ToHexStringSyntax**: Hexadecimal format
    - Zero-allocation implementation for small inputs
    - Optional formatting (uppercase, "0x" prefix)
    - Direct bit manipulation optimization
    - Bulk conversion support

- **Boolean Conversion Suite**
  - **ToBoolSyntax**: Boolean conversion
    - Consistent behavior across all numeric types
    - Configurable default values for nullable types
    - Generic IConvertible support
    - Efficient string parsing with null-safety

### Changed
- Cleaned up project dependencies for minimal footprint
- Added MIT license headers to all source files

### Technical Highlights
- Zero-allocation implementations where possible
- Comprehensive XML documentation
- JetBrains.Annotations support
- Thread-safe, pure function implementations
- ReSharper-compliant code organization

## [0.0.1] - 2024-11-18

### Added
- Initial release with comprehensive type conversion extensions

#### Type Conversion Extensions
- **Numeric Types**
  - Integer conversions (`int`, `long`, `short`)
  - Floating-point conversions (`float`, `double`, `decimal`)
  - Mathematical operations (Abs, Round, Ceiling, Floor)
  - Formatting utilities (Fixed, Currency, Percentage)

- **Basic Types**
  - Boolean conversions
  - Byte/Char conversions
  - String parsing utilities
  - DateTime parsing

### Technical Notes
- Implemented as extension methods for easy integration
- Zero external dependencies
- Full Unity 2021.3+ compatibility
- Comprehensive XML documentation