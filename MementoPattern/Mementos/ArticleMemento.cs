namespace MementoPattern.Mementos;

/// <summary>
/// 备忘录类：保存文章内容
/// </summary>
public class ArticleMemento(string content)
{
    public string Content { get; set; } = content;
}