namespace FlyweightPattern.Fyewight;

/// <summary>
/// 定义 Flyweight 接口
/// </summary>
public interface IBullet
{
    void Fire(int x, int y, string direction);
}