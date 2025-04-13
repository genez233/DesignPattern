using CommandPattern.Interfaces;
using CommandPattern.Receiver;

namespace CommandPattern.ConcreteCommand;

/// <summary>
/// 命令模式：具体命令
/// </summary>
public class TurnOffCommand(Light light) : ICommand
{
    public void Execute()
    {
        light.TurnOff();
    }

    public void Undo()
    {
        light.TurnOn();
    }
}