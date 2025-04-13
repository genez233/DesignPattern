namespace CommandPattern.Interfaces;

/// <summary>
/// 命令接口
/// </summary>
public interface ICommand
{
    void Execute();
    void Undo();
}