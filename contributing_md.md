# Contributing to JayPDFLibs

Thank you for your interest in contributing to JayPDFLibs! We welcome contributions from developers of all skill levels. This document provides guidelines and information for contributors.

## 🌟 Ways to Contribute

### 🐛 Bug Reports
- Search existing issues before creating new ones
- Use the bug report template
- Include minimal reproducible examples
- Specify your environment (OS, .NET version, etc.)

### 💡 Feature Requests
- Check if the feature aligns with project goals
- Provide detailed use cases and examples
- Consider implementation complexity and impact

### 📝 Code Contributions
- Bug fixes and feature implementations
- Performance improvements
- Test coverage improvements
- Documentation updates

### 🌏 Localization & Internationalization
- Thai language testing and improvements
- Support for additional languages and scripts
- Font compatibility testing

### 📚 Documentation
- API documentation improvements
- User guides and tutorials
- Code examples and samples
- Architecture documentation

## 🚀 Getting Started

### Prerequisites
- .NET 8.0 SDK or later
- Git
- A GitHub account
- IDE: Visual Studio 2022, VS Code, or Rider

### Development Setup

1. **Fork and Clone**
```bash
# Fork the repository on GitHub, then clone your fork
git clone https://github.com/YOUR-USERNAME/JayPDFLibs.git
cd JayPDFLibs

# Add upstream remote
git remote add upstream https://github.com/ORIGINAL-OWNER/JayPDFLibs.git
```

2. **Install Dependencies**
```bash
# Restore NuGet packages
dotnet restore

# Build the solution
dotnet build
```

3. **Run Tests**
```bash
# Run all tests
dotnet test

# Run tests with coverage
dotnet test --collect:"XPlat Code Coverage"
```

4. **Verify Setup**
```bash
# Run the example project
dotnet run --project examples/JayPDFLibs.Examples
```

### Project Structure Understanding
```
JayPDFLibs/
├── src/
│   ├── JayPDFLibs.Core/         # Core PDF functionality
│   ├── JayPDFLibs.Templates/    # Template processing
│   ├── JayPDFLibs.DataSources/  # Data source integrations
│   └── JayPDFLibs.Rendering/    # PDF output generation
├── tests/
│   ├── Unit/                          # Unit tests
│   ├── Integration/                   # Integration tests
│   └── Performance/                   # Benchmark tests
├── examples/                          # Sample projects
├── docs/                             # Documentation
└── assets/
    └── fonts/                        # Test fonts (Thai fonts)
```

## 💻 Development Workflow

### Branch Strategy
- **main**: Stable, production-ready code
- **develop**: Integration branch for features
- **feature/***: New features and enhancements
- **bugfix/***: Bug fixes
- **hotfix/***: Critical fixes for production

### Creating a Pull Request

1. **Create Feature Branch**
```bash
git checkout develop
git pull upstream develop
git checkout -b feature/your-feature-name
```

2. **Make Changes**
- Write clean, readable code
- Follow existing code style and conventions
- Add appropriate tests
- Update documentation as needed

3. **Commit Guidelines**
```bash
# Use conventional commit format
git commit -m "feat: add Thai text wrapping support"
git commit -m "fix: resolve font embedding memory leak"
git commit -m "docs: update API documentation for PdfPage"
git commit -m "test: add unit tests for CSV data source"
```

**Commit Type Prefixes:**
- `feat`: New feature
- `fix`: Bug fix
- `docs`: Documentation changes
- `style`: Code formatting (no functional changes)
- `refactor`: Code refactoring
- `test`: Adding or updating tests
- `chore`: Maintenance tasks
- `perf`: Performance improvements

4. **Push and Create PR**
```bash
git push origin feature/your-feature-name
# Create pull request through GitHub UI
```

### Pull Request Guidelines

#### PR Title Format
```
type(scope): brief description

Examples:
feat(fonts): add support for Thai font ligatures
fix(templates): resolve XML parsing memory leak  
docs(api): update PdfDocument class documentation
```

#### PR Description Template
```markdown
## Summary
Brief description of changes

## Type of Change
- [ ] Bug fix
- [ ] New feature
- [ ] Documentation update
- [ ] Performance improvement
- [ ] Code refactoring

## Testing
- [ ] Unit tests added/updated
- [ ] Integration tests added/updated
- [ ] Manual testing performed
- [ ] Performance impact assessed

## Thai Language Impact
- [ ] No impact on Thai language support
- [ ] Improves Thai language support
- [ ] New Thai language feature
- [ ] Requires Thai language testing

## Screenshots/Examples
(If applicable)

## Checklist
- [ ] Code follows project style guidelines
- [ ] Self-review completed
- [ ] Documentation updated
- [ ] Tests added/updated
- [ ] No breaking changes (or marked as BREAKING CHANGE)
```

## 🧪 Testing Guidelines

### Test Categories

#### Unit Tests
```csharp
[Test]
public void PdfDocument_AddPage_ShouldCreateNewPage()
{
    // Arrange
    var document = new PdfDocument();
    
    // Act
    var page = document.AddPage();
    
    // Assert
    page.Should().NotBeNull();
    document.Pages.Should().HaveCount(1);
}
```

#### Integration Tests
```csharp
[Test]
public void CsvDataSource_WithThaiData_ShouldGenerateValidPdf()
{
    // Arrange
    var csvData = "ชื่อ,ราคา\nสินค้า A,100\nสินค้า B,200";
    var dataSource = new CsvDataSource(csvData);
    
    // Act
    var document = PdfGenerator.FromDataSource(dataSource)
        .WithFont("Sarabun-Regular.ttf")
        .Generate();
    
    // Assert
    document.Should().NotBeNull();
    // Additional PDF validation
}
```

#### Performance Tests
```csharp
[Benchmark]
public void GenerateLargeDocument_1000Pages()
{
    var document = new PdfDocument();
    for (int i = 0; i < 1000; i++)
    {
        var page = document.AddPage();
        page.AddText($"Page {i + 1}", 100, 700);
    }
    document.SaveToStream(Stream.Null);
}
```

### Thai Language Testing
- Test with various Thai fonts
- Verify character encoding (UTF-8, UTF-16)
- Test complex text scenarios (mixed languages)
- Validate font embedding and character positioning

### Test Naming Convention
```csharp
// Pattern: MethodName_Scenario_ExpectedResult
PdfPage_AddThaiText_ShouldRenderCorrectly()
FontManager_LoadInvalidFont_ShouldThrowException()
TemplateEngine_ProcessThaiTemplate_ShouldSubstituteVariables()
```

## 📋 Code Style Guidelines

### C# Coding Standards

#### Naming Conventions
- **Classes**: PascalCase (`PdfDocument`, `FontManager`)
- **Methods**: PascalCase (`AddPage()`, `LoadFont()`)
- **Properties**: PascalCase (`PageCount`, `FontName`)
- **Fields**: _camelCase (`_pages`, `_fontCache`)
- **Parameters**: camelCase (`fontSize`, `fontName`)
- **Constants**: UPPER_CASE (`MAX_PAGE_SIZE`, `DEFAULT_ENCODING`)

#### Code Organization
```csharp
namespace JayPDFLibs.Core.Document
{
    /// <summary>
    /// Represents a PDF document with support for Thai language content.
    /// </summary>
    public class PdfDocument : IDisposable
    {
        #region Fields
        private readonly List<PdfPage> _pages;
        private readonly FontManager _fontManager;
        #endregion

        #region Properties
        public int PageCount => _pages.Count;
        public FontManager Fonts => _fontManager;
        #endregion

        #region Constructors
        public PdfDocument()
        {
            _pages = new List<PdfPage>();
            _fontManager = new FontManager();
        }
        #endregion

        #region Public Methods
        public PdfPage AddPage(PageSize size = PageSize.A4)
        {
            var page = new PdfPage(size);
            _pages.Add(page);
            return page;
        }
        #endregion

        #region Private Methods
        private void ValidatePageSize(PageSize size)
        {
            // Implementation
        }
        #endregion

        #region IDisposable
        public void Dispose()
        {
            _pages?.Clear();
            _fontManager?.Dispose();
        }
        #endregion
    }
}
```

#### Error Handling
```csharp
// Use specific exceptions
throw new FontNotFoundException($"Font '{fontName}' not found in system or embedded fonts.");

// Validate parameters
public void LoadFont(string fontPath)
{
    if (string.IsNullOrWhiteSpace(fontPath))
        throw new ArgumentException("Font path cannot be null or empty.", nameof(fontPath));
    
    if (!File.Exists(fontPath))
        throw new FileNotFoundException($"Font file not found: {fontPath}");
}

// Use using statements for disposables
using var fileStream = new FileStream(filePath, FileMode.Create);
document.SaveToStream(fileStream);
```

### Documentation Standards

#### XML Documentation
```csharp
/// <summary>
/// Adds Thai text to the PDF page with specified formatting.
/// </summary>
/// <param name="text">The Thai text content to add.</param>
/// <param name="x">X coordinate position.</param>
/// <param name="y">Y coordinate position.</param>
/// <param name="fontName">Font name (supports Thai fonts like Sarabun).</param>
/// <param name="fontSize">Font size in points.</param>
/// <returns>The current <see cref="PdfPage"/> for method chaining.</returns>
/// <exception cref="ArgumentNullException">Thrown when text is null.</exception>
/// <exception cref="FontNotFoundException">Thrown when specified font is not available.</exception>
/// <example>
/// <code>
/// page.AddThaiText("สวัสดีครับ", 100, 700, "Sarabun-Regular", 14);
/// </code>
/// </example>
public PdfPage AddThaiText(string text, float x, float y, string fontName, float fontSize)
```

## 🌏 Thai Language Contribution Guidelines

### Font Testing Requirements
When contributing Thai language features:

1. **Test with Standard Fonts**
   - Sarabun (Regular, Bold, Light)
   - Prompt (Regular, Bold)
   - Kanit (Regular, Bold)
   - Noto Sans Thai

2. **Character Set Testing**
```csharp
// Test basic Thai characters
var basicThai = "กขคงจฉชซฌญฎฏฐฑฒณดตถทธนบปผฝพฟภมยรลวศษสหฬอฮ";

// Test Thai numerals
var thaiNumerals = "๐๑๒๓๔๕๖๗๘๙";

// Test tone marks and vowels
var toneMarks = "กิกีกึกืกุกูเกแกโกใกไก็ก่ก้ก๊ก๋";

// Test complex combinations
var complexText = "ประเทศไทย ๒๕๖๘ จำนวน ๑,๒๓๔.๕๖ บาท";
```

3. **Layout Testing**
   - Text wrapping with Thai characters
   - Mixed Thai-English content
   - Number formatting (Thai vs Arabic numerals)
   - Date and time formatting

### Localization Contributions
- Thai error messages and documentation
- Thai sample templates and examples
- Currency and number formatting for Thailand
- Thai calendar and date support

## 🏆 Recognition

### Contributor Levels
- **First-time Contributors**: Welcome guide and mentoring
- **Regular Contributors**: Recognition in releases and README
- **Core Contributors**: Commit access and decision-making involvement
- **Maintainers**: Full repository access and release management

### Hall of Fame
Contributors who make significant impacts will be recognized in:
- README.md acknowledgments
- Release notes
- Project documentation
- Conference presentations and blog posts

## 📞 Getting Help

### Communication Channels
- **GitHub Discussions**: General questions and feature discussions
- **GitHub Issues**: Bug reports and specific problems  
- **Discord/Slack**: Real-time chat (link in repository)
- **Email**: maintainers@dynamicpdflibrary.com

### Mentorship Program
New contributors can request mentorship for:
- Understanding the codebase
- Guidance on first contributions
- Thai language feature development
- Performance optimization techniques

## 📜 Code of Conduct

We are committed to providing a friendly, safe, and welcoming environment for all contributors, regardless of:
- Experience level
- Gender identity and expression
- Sexual orientation
- Disability
- Personal appearance
- Body size
- Race
- Ethnicity
- Age
- Religion
- Nationality

### Expected Behavior
- Be respectful and inclusive
- Provide constructive feedback
- Focus on what is best for the community
- Show empathy towards other community members

### Unacceptable Behavior
- Harassment, discrimination, or intimidation
- Offensive comments or personal attacks
- Public or private harassment
- Publishing others' private information
- Other conduct inappropriate in a professional setting

### Enforcement
Report unacceptable behavior to maintainers@dynamicpdflibrary.com. All reports will be handled confidentially.

## 📋 Contributor License Agreement

By contributing to JayPDFLibs, you agree that:
- Your contributions will be licensed under the Apache License 2.0
- You have the right to submit your contributions
- You understand that your contributions are public and may be redistributed

## 🎯 Conclusion

Thank you for considering contributing to JayPDFLibs! Your contributions help make PDF generation with Thai language support accessible to developers worldwide.

For questions about contributing, please:
1. Check existing documentation and issues
2. Ask in GitHub Discussions
3. Contact maintainers directly

Happy coding! 🚀

---

**Remember**: Every contribution, no matter how small, makes a difference. Whether it's fixing a typo, adding a test, or implementing a major feature, your effort is valued and appreciated.