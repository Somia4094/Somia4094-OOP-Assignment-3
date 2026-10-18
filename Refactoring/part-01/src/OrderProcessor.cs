
namespace RefactoringLab;

public class OrderProcessor
{
    private readonly IOrderRepository _repo;
    private readonly INotificationSender _email;

    public OrderProcessor(
        IOrderRepository repo,
        INotificationSender email)
    {
        _repo = repo;
        _email = email;
    }

    public void Process(int orderId, string customerEmail)
    {
        var processedAt = DateTime.Now;

        _repo.Save(orderId, processedAt);
        _email.Send(
            customerEmail,
            $"Order {orderId} confirmed at {processedAt}");
    }
}

public class SqlOrderRepository : IOrderRepository
{
    public void Save(int orderId, DateTime processedAt) =>
        Console.WriteLine($"[SQL] save order {orderId} @ {processedAt:O}");
}

public class SmtpEmailSender : INotificationSender
{
    public void Send(string to, string body) =>
        Console.WriteLine($"[SMTP] to={to} body={body}");
}
