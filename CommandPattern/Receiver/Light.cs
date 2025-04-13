namespace CommandPattern.Receiver;

/// <summary>
/// 接收者：灯
/// </summary>
public class Light
{
    public void TurnOn()
    {
        Console.WriteLine("灯亮了");
    }

    public void TurnOff()
    {
        Console.WriteLine("灯灭了");
    }
}