using System.Collections;
using IteratorPattern.Interfaces;
using IteratorPattern.Models;

namespace IteratorPattern.ConcreteIterator;

/// <summary>
/// 实现具体迭代器
/// </summary>
public class BookIterator(Book[] books) : IBookIterator
{
    private int _index = -1;

    public bool MoveNext()
    {
        _index++;
        return _index < books.Length;
    }
    
    public void Reset()
    {
        _index = -1;
    }

    public Book Current
    {
        get
        {
            try
            {
                return books[_index];
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e);
                throw new InvalidOperationException();
            }
        }
    }
    
    object IEnumerator.Current => Current;
    public void Dispose()
    {
        // 清理非托管资源（本示例无需处理）
    }
}