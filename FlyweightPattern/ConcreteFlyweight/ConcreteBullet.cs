using FlyweightPattern.Fyewight;

namespace FlyweightPattern.ConcreteFlyweight;

/// <summary>
/// 实现IBullet接口
/// </summary>
public class ConcreteBullet : IBullet
{
    private readonly string _color; // 内部状态
    private readonly int _speed;    // 内部状态
    public ConcreteBullet(string color, int speed)
    {
        _color = color;
        _speed = speed;
    }
    
    public void Fire(int x, int y, string direction)
    {
        Console.WriteLine($"发射{_color}子弹：速度{_speed}, 位置（{x},{y}）方向：{direction}");
    }
}