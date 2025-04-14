namespace IteratorPattern.Models;

/// <summary>
/// 书籍类实体
/// </summary>
/// <param name="title"></param>
/// <param name="author"></param>
public class Book(string title, string author)
{
    public string Title { get; set; } = title;
    public string Author { get; set; } = author;
}