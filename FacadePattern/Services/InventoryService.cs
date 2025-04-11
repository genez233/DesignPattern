namespace FacadePattern.Services;

/// <summary>
/// 库存服务
/// </summary>
public class InventoryService
{
    public bool CheckStock(string productId, int quantity)
    {
        Console.WriteLine($"Checking stock for product {productId}...");
        // 模拟库存充足
        return true;
    }
}