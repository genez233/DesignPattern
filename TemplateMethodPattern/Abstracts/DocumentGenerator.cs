namespace TemplateMethodPattern.Abstracts;

/// <summary>
/// 定义抽象类：文档生成器
/// </summary>
public abstract class DocumentGenerator
{
    public void GenerateDocument()
    {
        Initialize();
        AddContent();
        if (RequireWatermark())
        {
            AddWatermark();
        }
        Save();
    }
    
    // 抽象方法：子类必须实现
    public abstract void Initialize();
    public abstract void AddContent();
    public abstract void Save();
    
    // 添加钩子方法 在抽象类中提供可选步骤，子类可决定是否覆盖
    protected virtual bool RequireWatermark() => false; // 钩子方法
    protected virtual void AddWatermark() {}    // 默认空实现
}