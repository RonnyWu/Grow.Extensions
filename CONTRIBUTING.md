# Contributing to Grow.Extensions

First off, thank you for considering contributing to Grow.Extensions! It's people like you that make this library better for everyone.

## Code of Conduct
By participating in this project, you are expected to uphold our Code of Conduct. Please report unacceptable behavior to [your-email].

## How Can I Contribute?

### Reporting Bugs
Before creating bug reports, please check the issue list as you might find out that you don't need to create one. When you are creating a bug report, please include as many details as possible:

* Use a clear and descriptive title
* Describe the exact steps to reproduce the problem
* Provide specific examples to demonstrate the steps
* Describe the behavior you observed and what behavior you expected to see
* Include code samples and stack traces if applicable
* Include Unity version and .NET version information

### Suggesting Enhancements
Enhancement suggestions are tracked as GitHub issues. When creating an enhancement suggestion, please include:

* A clear and descriptive title
* A detailed description of the proposed functionality
* Explain why this enhancement would be useful
* List any alternative solutions or features you've considered

### Pull Requests
Please follow these steps when submitting a pull request:

1. Fork the repository and create your branch from `main`
2. If you've added code that should be tested, add tests
3. Ensure your code follows the project's code style (defined in .DotSettings)
4. Update the documentation if needed
5. Write a clear commit message following our commit message conventions

#### Commit Message Format
```
type(scope): subject

body

footer
```

Types:
* feat: A new feature
* fix: A bug fix
* docs: Documentation only changes
* style: Changes that do not affect the meaning of the code
* refactor: A code change that neither fixes a bug nor adds a feature
* perf: A code change that improves performance
* test: Adding missing tests
* chore: Changes to the build process or auxiliary tools

#### Code Style Guidelines
We use JetBrains Rider's default code style with some customizations. The complete style guide is defined in the `.DotSettings` file in the repository root.

Key points:
* Use Rider's code cleanup feature (Ctrl+Alt+L / Cmd+Alt+L) before committing
* Follow the existing code formatting in the project
* Use Rider's code inspections to catch potential issues
* Enable "Format on Save" in Rider for consistent styling
* Maximum of one blank line between methods and properties
* XML documentation required for all public APIs

### Development Setup
1. Fork and clone the repository
2. Open the project in Unity 2021.3 or later
3. Install JetBrains Rider (recommended) or Visual Studio
4. Import the project's .DotSettings file into your IDE
5. Make your changes
6. Run tests to ensure nothing is broken
7. Submit your pull request

### Running Tests
1. Open the Unity Test Runner (Window > General > Test Runner)
2. Run all tests to ensure your changes haven't broken anything
3. Add new tests for new functionality

## Documentation
* Keep XML documentation up to date
* Update README.md if needed
* Add examples for new features
* Document breaking changes

## Questions?
Feel free to open an issue with the "question" label if you need help or clarification.

## License
By contributing, you agree that your contributions will be licensed under the same license as the original project.

Thank you for your contributions!
