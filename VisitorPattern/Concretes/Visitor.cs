using System.Text;
using VisitorPattern.Interfaces;

namespace VisitorPattern.Concretes;

/// <summary>
/// 具体访问者：HTML 导出访问者
/// </summary>
public class HtmlVisitor : IDocumentVisitor
{
    private StringBuilder _output = new StringBuilder();
    public string GetOutput() => _output.ToString();
    
    public void Visit(Paragraph paragraph)
    {
        _output.AppendLine($"<p>{paragraph.Text}</p>");
    }

    public void Visit(Image image)
    {
        _output.AppendLine($"<img src=\"{image.Url}\" />");
    }

    public void Visit(Table table)
    {
        _output.AppendLine("<table>");
        foreach (var row in table.Rows)
        {
            _output.AppendLine("<tr>");
            foreach (var cell in row)
            {
                _output.AppendLine($"<td>{cell}</td>");
            }
            _output.AppendLine("</tr>");
        }
    }
}

public class MarkdownVisitor : IDocumentVisitor
{
    private StringBuilder _output = new StringBuilder();
    public string GetOutput() => _output.ToString();
    public void Visit(Paragraph paragraph)
    {
        _output.AppendLine($"{paragraph.Text}\n");
    }

    public void Visit(Image image)
    {
        _output.AppendLine($"![{image.Url}]({image.Url})");
    }

    public void Visit(Table table)
    {
        foreach (var row in table.Rows)
        {
            _output.AppendLine("|" + string.Join("|", row) + "|");
        }

        _output.AppendLine();
    }
}