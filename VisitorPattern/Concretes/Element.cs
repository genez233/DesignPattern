using VisitorPattern.Interfaces;

namespace VisitorPattern.Concretes;

/// <summary>
/// 具体元素：段落
/// </summary>
public class Paragraph(string text) : IDocumentElement
{
    public string Text { get; set; } = text;
    public void Accept(IDocumentVisitor visitor)
    {
        visitor.Visit(this);
    }
}

public class Image(string url) : IDocumentElement
{
    public string Url { get; set; } = url;
    public void Accept(IDocumentVisitor visitor)
    {
        visitor.Visit(this);
    }
}

public class Table(string[][] rows) : IDocumentElement
{
    public string[][] Rows { get; set; } = rows;
    public void Accept(IDocumentVisitor visitor)
    {
        visitor.Visit(this);
    }
}