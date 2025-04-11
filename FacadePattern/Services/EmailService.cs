namespace FacadePattern.Services;

/// <summary>
/// 邮件服务
/// </summary>
public class EmailService
{
    public void SendConfirmation(string email, string message)
    {
        Console.WriteLine($"Sending confirmation email to {email}: {message}");
    }
}