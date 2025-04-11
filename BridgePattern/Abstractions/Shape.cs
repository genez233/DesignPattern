using BridgePattern.Interfaces;

namespace BridgePattern.Abstractions;

/// <summary>
/// 抽象化基类 Shape
/// </summary>
public abstract class Shape
{
    protected IRenderer _renderer { get; }
    protected Shape(IRenderer renderer)
    {
        _renderer = renderer;
    }
    
    public abstract void Draw();
}