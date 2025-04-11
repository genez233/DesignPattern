using BridgePattern.Interfaces;

namespace BridgePattern.Concretes;

/// <summary>
/// DirectX渲染器
/// </summary>
public class DirectXRenderer : IRenderer
{
    public void RenderCircle(float radius)
    {
        Console.WriteLine($"DirectX渲染圆形: 半径为：{radius}");
    }

    public void RenderSquare(float side)
    {
        Console.WriteLine($"DirectX渲染正方形: 边长为：{side}");
    }
}