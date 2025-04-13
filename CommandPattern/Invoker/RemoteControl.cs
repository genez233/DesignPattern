
using CommandPattern.Interfaces;

namespace CommandPattern.Invoker;

/// <summary>
/// 调用者
/// </summary>
public class RemoteControl
{
    private readonly Stack<ICommand> _history = new Stack<ICommand>();
    public void ExecuteCommand(ICommand command)
    {
        command.Execute();
        _history.Push(command);
    }
    
    public void UndoLastCommand()
    {
        if (_history.Count == 0)
        {
            return;
        }
        var command = _history.Pop();
        command.Undo();
    }
}