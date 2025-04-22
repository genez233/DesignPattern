using TemplateMethodPattern.Abstracts;

namespace TemplateMethodPattern.ConcreteClass;

/// <summary>
/// 实现具体子类：PDF文档生成器
/// </summary>
public class PdfDocumentGenerator : DocumentGenerator
{
    public override void Initialize()
    {
        Console.WriteLine("初始化PDF文档生成器");
    }

    public override void AddContent()
    {
        Console.WriteLine("添加PDF文档内容");
    }

    public override void Save()
    {
        Console.WriteLine("保存PDF文档");
    }
}