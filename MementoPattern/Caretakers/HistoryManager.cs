using MementoPattern.Mementos;

namespace MementoPattern.Caretakers;

/// <summary>
/// 管理者：历史记录管理器
/// </summary>
public class HistoryManager
{
    private readonly Stack<ArticleMemento> _history = new();
    
    /// <summary>
    /// 保存状态
    /// </summary>
    /// <param name="memento"></param>
    public void SaveState(ArticleMemento memento)
    {
        _history.Push(memento);
    }
    
    /// <summary>
    /// 恢复状态：撤销操作（恢复上一个状态）
    /// </summary>
    public ArticleMemento? Undo()
    {
        if (_history.Count > 0)
        {
            var memento = _history.Pop();
            Console.WriteLine($"恢复到状态：{memento.Content}");
            return memento;
        }
        else
        {
            Console.WriteLine("没有可恢复的状态！");
        }
        return null;
    }
}