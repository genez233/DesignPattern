# 亨元模式（Flyweight）

#### 什么是享元模式？

**享元模式**是一种结构型设计模式，核心目标是**减少内存占用**和**提高性能**，通过共享相似对象的状态来实现。它适用于需要创建大量相似对象的场景，通过分离对象的**内部状态**（可共享的、不变的部分）和**外部状态**（不可共享的、变化的部分），避免重复存储冗余数据。

---

#### 享元模式的核心概念

1. **内部状态（Intrinsic State）**
    - 对象中**可共享**的部分，通常不变且与对象上下文无关（如颜色、纹理）。
2. **外部状态（Extrinsic State）**
    - 对象中**不可共享**的部分，依赖外部传入（如位置、方向）。
3. **Flyweight 工厂**
    - 管理共享的 Flyweight 对象，确保合理复用。

---

#### 享元模式的结构

|角色|说明|
|-|-|
|`Flyweight`|接口，定义对象可接受外部状态的操作。|
|`ConcreteFlyweight`|实现 Flyweight 接口，包含内部状态。|
|`UnsharedFlyweight`|（可选）不共享的具体类，直接存储所有状态。|
|`FlyweightFactory`|工厂类，管理 Flyweight 对象池，确保共享。|


---

#### 适用场景

- 系统中存在大量相似对象。
- 对象的大部分状态可以外部化。
- 需要缓存或复用对象以减少内存开销。
- 经典案例：文本编辑器中的字符、游戏中的粒子特效、GUI 中的图标复用。

---

#### 优缺点

**优点**

- 显著减少内存占用。
- 提高对象复用性。

**缺点**

- 增加系统复杂度（需分离内外部状态）。
- 多线程环境下需注意线程安全。

---

### .NET Core 示例：游戏子弹管理系统

#### 场景描述

假设有一个射击游戏，需要管理成千上万的子弹对象。子弹的**类型**（如颜色、速度）是内部状态，**位置**和**方向**是外部状态。

---

#### 代码实现

1. **定义 Flyweight 接口**

```C#
public interface IBullet
{
    void Fire(int x, int y, string direction);
}
```
2. **实现 ConcreteFlyweight**

```C#
public class ConcreteBullet : IBullet
{
    private readonly string _color;  // 内部状态
    private readonly int _speed;     // 内部状态

    public ConcreteBullet(string color, int speed)
    {
        _color = color;
        _speed = speed;
    }

    public void Fire(int x, int y, string direction)
    {
        Console.WriteLine($"发射 {_color} 子弹: 速度 {_speed}, 位置 ({x}, {y}), 方向 {direction}");
    }
}
```
3. **实现 Flyweight 工厂**

```C#
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
                    throw new ArgumentException("无效的子弹类型");
            }
        }
        return _bullets[type];
    }
}
```
4. **客户端调用**

```C#
class Program
{
    static void Main(string[] args)
    {
        var factory = new BulletFactory();

        // 发射手枪子弹（共享内部状态）
        var bullet1 = factory.GetBullet("Pistol");
        bullet1.Fire(10, 20, "北方");  // 外部状态通过参数传入

        // 发射步枪子弹（共享内部状态）
        var bullet2 = factory.GetBullet("Rifle");
        bullet2.Fire(30, 40, "南方");

        // 再次获取手枪子弹，验证是否复用
        var bullet3 = factory.GetBullet("Pistol");
        Console.WriteLine($"bullet1 和 bullet3 是同一实例: {ReferenceEquals(bullet1, bullet3)}");
    }
}
```

---

#### 输出结果

```Markdown
发射 红色 子弹: 速度 100, 位置 (10, 20), 方向 北方
发射 蓝色 子弹: 速度 200, 位置 (30, 40), 方向 南方
bullet1 和 bullet3 是同一实例: True
```

---

#### 模式分析

- **内部状态**：子弹颜色和速度被共享，存储于 `ConcreteBullet`。
- **外部状态**：位置和方向由客户端传入，不存储在对象中。
- **工厂复用**：`BulletFactory` 确保相同类型的子弹只创建一次。

---

#### 扩展思考

- **线程安全**：若多线程访问工厂，需对 `_bullets` 加锁。
- **混合状态**：若某些对象不可共享，可结合 `UnsharedFlyweight` 实现。
- **性能权衡**：在对象复用和代码复杂度之间寻找平衡。

享元模式通过共享不变部分，优雅地解决了海量对象的内存问题，是优化密集型资源的利器。

