namespace BuilderPattern;

/// <summary>
/// 定义 Product （Report类）
/// </summary>
public class Report
{
    public string Title { get; set; }
    public string Content { get; set; }
    public string Footer { get; set; }
    public string Format { get; set; }

    public void Display()
    {
        Console.WriteLine($"Title: {Title}");
        Console.WriteLine($"Content: {Content}");
        Console.WriteLine($"Footer: {Footer}");
        Console.WriteLine($"Format: {Format}");
    }
}