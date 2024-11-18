# Changelog
All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

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