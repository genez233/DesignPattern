using MementoPattern.Mementos;

namespace MementoPattern.Originators;

/// <summary>
/// 发起人：文章类（需要保存和恢复状态的对象）
/// </summary>
public class Article
{
    public string Content { get; set; } = string.Empty;

    /// <summary>
    /// 创建备忘录，保存当前状态
    /// </summary>
    /// <returns></returns>
    public ArticleMemento Save()
    {
        return new ArticleMemento(Content);
    }

    /// <summary>
    /// 恢复备忘录，恢复到之前的某个状态
    /// </summary>
    /// <param name="memento"></param>
    public void RestoreMemento(ArticleMemento memento)
    {
        Content = memento.Content;
    }
}