using IteratorPattern.Models;

namespace IteratorPattern.Interfaces;

/// <summary>
/// 迭代器接口, 用于迭代集合，直接使用 IEnumerator
/// </summary>
public interface IBookIterator : IEnumerator<Book>
{
    // 默认包含：
    // bool MoveNext();
    // void Reset();
    // Book Current { get; }
    // object IEnumerator.Current => Current;
    // void Dispose();
}