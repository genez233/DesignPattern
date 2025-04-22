using TemplateMethodPattern.Abstracts;

namespace TemplateMethodPattern.ConcreteClass;

/// <summary>
/// 具体实现类：HTML文档生成器
/// </summary>
public class HtmlDocumentGenerator : DocumentGenerator
{
    public override void Initialize()
    {
        Console.WriteLine("初始化HTML文档生成器");
    }

    public override void AddContent()
    {
        Console.WriteLine("添加HTML文档内容");
    }

    public override void Save()
    {
        Console.WriteLine("保存HTML文档");
    }

    // 子类覆盖钩子方法
    protected override bool RequireWatermark() => true;
    protected override void AddWatermark()
    {
        Console.WriteLine("添加水印到HTML文档");
    }
}