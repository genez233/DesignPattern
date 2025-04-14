using System.Collections;
using IteratorPattern.Models;

namespace IteratorPattern.ConcreteIterator;

/// <summary>
/// 使用 C# 语法糖实现（yield）
/// </summary>
public class BookCollectionYield : IEnumerable<Book>
{
    private readonly List<Book> _books = new();
    public void AddBook(Book book) => _books.Add(book);
    public IEnumerator<Book> GetEnumerator()
    {
        foreach (var book in _books)
        {
            yield return book;
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}