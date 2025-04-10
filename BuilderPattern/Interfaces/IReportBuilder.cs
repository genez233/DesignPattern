namespace BuilderPattern.Interfaces;

/// <summary>
/// 抽象建造者接口
/// </summary>
public interface IReportBuilder
{
    IReportBuilder SetTitle(string title);
    IReportBuilder SetContent(string content);
    IReportBuilder SetFooter(string footer);
    IReportBuilder SetFormat(string format);
    Report Build();
}