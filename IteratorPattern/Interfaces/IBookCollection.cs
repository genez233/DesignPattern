using IteratorPattern.Models;

namespace IteratorPattern.Interfaces;

/// <summary>
/// 定义聚合接口（已内聚 IEnumerable）
/// </summary>
public interface IBookCollection : IEnumerable<Book>
{
    void AddBook(Book book);
    int Count { get; }
}