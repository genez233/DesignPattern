using VisitorPattern.Interfaces;

namespace VisitorPattern.Structures;

/// <summary>
/// 对象结构：文档类
/// </summary>
public class Document
{
    private List<IDocumentElement> _elements = new();
    public void AddElement(IDocumentElement element) => _elements.Add(element);
    
    public void Accept(IDocumentVisitor visitor)
    {
        foreach (var element in _elements)
        {
            element.Accept(visitor);
        }
    }
}