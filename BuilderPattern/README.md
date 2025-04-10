# 建造者模式

建造者模式是一种创建型设计模式，用于分步骤构建复杂对象，尤其适用于参数多、构建逻辑复杂的场景。以下通过一个.NET Core示例详细解析该模式及其应用。

### 建造者模式结构
1. **Product（产品类）**：最终构建的复杂对象。
2. **Builder（抽象建造者）**：定义构建产品各部分的接口。
3. **ConcreteBuilder（具体建造者）**：实现Builder接口，提供具体构建步骤和获取产品的方法。
4. **Director（指挥者）**：可选类，封装构建流程，确保不同构建方式的一致性。

### 应用场景
- 对象包含多个组成部分，构建过程需分步或定制顺序。
- 构造方法参数过多，尤其是可选参数多，需避免构造函数膨胀。
- 需隔离复杂对象的创建代码和使用代码，提升可维护性。

### 示例：构建PDF报告
#### 1. 定义Product（Report类）
```csharp
public class Report
{
    public string Title { get; set; }
    public string Content { get; set; }
    public string Footer { get; set; }
    public string Format { get; set; }

    public void Display()
    {
        Console.WriteLine($"Format: {Format}");
        Console.WriteLine($"Title: {Title}");
        Console.WriteLine($"Content: {Content}");
        Console.WriteLine($"Footer: {Footer}");
    }
}
```

#### 2. 抽象建造者接口（IReportBuilder）
```csharp
public interface IReportBuilder
{
    IReportBuilder SetTitle(string title);
    IReportBuilder SetContent(string content);
    IReportBuilder SetFooter(string footer);
    IReportBuilder SetFormat(string format);
    Report Build();
}
```

#### 3. 具体建造者（PdfReportBuilder）
```csharp
public class PdfReportBuilder : IReportBuilder
{
    private Report _report = new Report();

    public IReportBuilder SetTitle(string title)
    {
        _report.Title = $"[PDF] {title}";
        return this;
    }

    public IReportBuilder SetContent(string content)
    {
        _report.Content = content;
        return this;
    }

    public IReportBuilder SetFooter(string footer)
    {
        _report.Footer = $"PDF Footer: {footer}";
        return this;
    }

    public IReportBuilder SetFormat(string format)
    {
        _report.Format = format;
        return this;
    }

    public Report Build()
    {
        // 强制验证逻辑
        if (string.IsNullOrEmpty(_report.Title))
            throw new InvalidOperationException("Report title is required.");
        return _report;
    }
}
```

#### 4. 指挥者类（ReportDirector）
```csharp
public class ReportDirector
{
    public void BuildAnnualReport(IReportBuilder builder)
    {
        builder.SetFormat("PDF")
               .SetTitle("Annual Report 2023")
               .SetContent("Financial data...")
               .SetFooter("Confidential");
    }

    public void BuildCustomReport(IReportBuilder builder, string title, string content)
    {
        builder.SetFormat("PDF")
               .SetTitle(title)
               .SetContent(content)
               .SetFooter("Generated on " + DateTime.Now.ToString("yyyy-MM-dd"));
    }
}
```

#### 5. 客户端调用
```csharp
// 使用Director构建标准报告
var pdfBuilder = new PdfReportBuilder();
var director = new ReportDirector();
director.BuildAnnualReport(pdfBuilder);
Report annualReport = pdfBuilder.Build();
annualReport.Display();

// 直接使用Builder灵活构建
var customBuilder = new PdfReportBuilder();
customBuilder.SetTitle("Custom Project Update")
             .SetContent("Project is on track...")
             .SetFooter("Team Alpha");
Report customReport = customBuilder.Build();
customReport.Display();
```

### 输出结果
```
Format: PDF
Title: [PDF] Annual Report 2023
Content: Financial data...
Footer: PDF Footer: Confidential

Format: PDF
Title: [PDF] Custom Project Update
Content: Project is on track...
Footer: PDF Footer: Team Alpha
```

### 模式优势
- **解耦构建与表示**：客户端无需了解对象内部结构。
- **精细化控制**：支持分步骤、按需配置对象。
- **代码复用**：通过不同Builder或Director复用构建逻辑。

### 实际应用
- **.NET Core中的HostBuilder**：构建应用主机时配置服务、日志等。
- **EF Core的DbContext配置**：链式方法设置数据库连接、日志策略等。
- **ASP.NET Core中间件配置**：通过IApplicationBuilder分步配置请求处理管道。

通过建造者模式，复杂对象的创建过程变得清晰、灵活且易于维护，特别适用于框架设计和复杂业务对象构建场景。