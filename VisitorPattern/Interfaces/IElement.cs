namespace VisitorPattern.Interfaces;

/// <summary>
/// 元素接口
/// </summary>
public interface IDocumentElement
{
    void Accept(IDocumentVisitor visitor);
}