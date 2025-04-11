namespace BridgePattern.Interfaces;

/// <summary>
/// 实现化接口：渲染引擎
/// </summary>
public interface IRenderer
{
    void RenderCircle(float radius);
    void RenderSquare(float side);
}