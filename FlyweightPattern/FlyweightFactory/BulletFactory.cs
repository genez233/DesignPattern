using FlyweightPattern.ConcreteFlyweight;
using FlyweightPattern.Fyewight;

namespace FlyweightPattern.FlyweightFactory;

public class BulletFactory
{
    private readonly Dictionary<string, IBullet> _bullets = new();
    
    public IBullet GetBullet(string type)
    {
        if (!_bullets.ContainsKey(type))
        {
            // 根据类型创建子弹（内部状态）
            switch (type)
            {
                case "Pistol":
                    _bullets[type] = new ConcreteBullet("红色", 100);
                    break;
                case "Rifle":
                    _bullets[type] = new ConcreteBullet("蓝色", 200);
                    break;
                default:
                    throw new ArgumentException("Invalid type");
            }
        }
        
        return _bullets[type];
    }
}