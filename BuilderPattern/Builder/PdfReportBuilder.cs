using BuilderPattern.Interfaces;

namespace BuilderPattern.Builder;

/// <summary>
/// 具体建造者 PdfReportBuilder
/// </summary>
public class PdfReportBuilder : IReportBuilder
{
    private readonly Report _report = new Report();
    public IReportBuilder SetTitle(string title)
    {
        _report.Title = title;
        return this;
    }

    public IReportBuilder SetContent(string content)
    {
        _report.Content = content;
        return this;
    }

    public IReportBuilder SetFooter(string footer)
    {
        _report.Footer = footer;
        return this;
    }

    public IReportBuilder SetFormat(string format)
    {
        _report.Format = format;
        return this;
    }

    public Report Build()
    {
        if (string.IsNullOrEmpty(_report.Title))
        {
            throw new InvalidOperationException("Report title is required.");
        }
        return _report;
    }
}