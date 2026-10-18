
namespace RefactoringLab;

public interface INotificationChannel
{
    void Send(string to, string message);
}

public class EmailChannel : INotificationChannel
{
    public void Send(string to, string message) =>
        Console.WriteLine($"[email] {to}: {message}");
}

public class SmsChannel : INotificationChannel
{
    public void Send(string to, string message) =>
        Console.WriteLine($"[sms] {to}: {message}");
}

public class Notification
{
    private readonly INotificationChannel _channel;
    private readonly bool _urgent;
    private readonly DateTime? _sendAt;

    public Notification(
        INotificationChannel channel,
        bool urgent = false,
        DateTime? sendAt = null)
    {
        _channel = channel;
        _urgent = urgent;
        _sendAt = sendAt;
    }

    public void Send(string to, string message)
    {
        if (_urgent)
        {
            message = $"[URGENT] {message}";
        }

        if (_sendAt.HasValue)
        {
            Console.WriteLine(
                $"[{_channel.GetType().Name} scheduled {_sendAt.Value:g}] {to}: {message}");
            return;
        }

        _channel.Send(to, message);
    }
}
