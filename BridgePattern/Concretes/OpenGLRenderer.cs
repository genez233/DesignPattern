using System.Threading.Channels;
using BridgePattern.Interfaces;

namespace BridgePattern.Concretes;

/// <summary>
/// 具体实现化：OpenGL 渲染器
/// </summary>
public class OpenGLRenderer : IRenderer
{
    public void RenderCircle(float radius)
    {
        Console.WriteLine($"OpenGL 渲染圆形，半径为：{radius}");
    }

    public void RenderSquare(float side)
    {
        Console.WriteLine($"OpenGL 渲染正方形，边长为：{side}");
    }
}