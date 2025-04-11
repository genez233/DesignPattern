using BridgePattern.Abstractions;
using BridgePattern.Interfaces;

namespace BridgePattern.RefinedAbstractions;

/// <summary>
/// 扩展抽象化类：圆形
/// </summary>
public class Circle : Shape
{
    private float _radius;
    public Circle(IRenderer renderer, float radius) : base(renderer)
    {
        _radius = radius;
    }
    
    public override void Draw()
    {
        _renderer.RenderCircle(_radius);
    }
}