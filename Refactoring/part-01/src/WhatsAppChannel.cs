
namespace RefactoringLab;

public class WhatsAppChannel : INotificationChannel
{
    public void Send(string to, string message) =>
        Console.WriteLine($"[WhatsApp] to={to}: {message}");
}
