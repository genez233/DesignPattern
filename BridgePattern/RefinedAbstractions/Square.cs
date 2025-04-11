using BridgePattern.Abstractions;
using BridgePattern.Interfaces;

namespace BridgePattern.RefinedAbstractions;

/// <summary>
/// 扩展抽象化：正方形
/// </summary>
public class Square : Shape
{
    private float _side;
    public Square(IRenderer renderer, float side) : base(renderer)
    {
        _side = side;
    }
    
    public override void Draw()
    {
        _renderer.RenderSquare(_side);
    }
}