using System.Collections;
using IteratorPattern.Interfaces;
using IteratorPattern.Models;

namespace IteratorPattern.ConcreteIterator;

/// <summary>
/// 实现聚合类
/// </summary>
public class BookCollection : IBookCollection
{
    private readonly List<Book> _books = new();
    
    public IEnumerator<Book> GetEnumerator()
    {
        return new BookIterator(_books.ToArray());
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void AddBook(Book book)
    {
        _books.Add(book);
    }

    public int Count => _books.Count;
}