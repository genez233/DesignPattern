using VisitorPattern.Concretes;

namespace VisitorPattern.Interfaces;

/// <summary>
/// 访问者接口
/// </summary>
public interface IDocumentVisitor
{
    void Visit(Paragraph paragraph);
    void Visit(Image image);
    void Visit(Table table);
}