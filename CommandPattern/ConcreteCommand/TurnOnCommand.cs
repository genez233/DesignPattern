using CommandPattern.Interfaces;
using CommandPattern.Receiver;

namespace CommandPattern.ConcreteCommand;

/// <summary>
/// 命令的具体实现
/// </summary>
public class TurnOnCommand(Light light) : ICommand
{
    
    public void Execute()
    {
        light.TurnOn();
    }

    public void Undo()
    {
        light.TurnOff();
    }
}