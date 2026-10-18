
using RefactoringLab;

IShippingCarrier[] carriers =
{
    new AramexCarrier(),
    new FedExCarrier(),
    new DhlCarrier(),
    new BostaCarrier()
};

var shipping = new ShippingCostCalculator(carriers);

Console.WriteLine($"Aramex 2kg → {shipping.Calculate("Aramex", 2)}");
Console.WriteLine($"FedEx 2kg  → {shipping.Calculate("FedEx", 2)}");
Console.WriteLine($"Bosta 2kg  → {shipping.Calculate("Bosta", 2)}");
Console.WriteLine();


IOrderRepository repository = new SqlOrderRepository();
INotificationSender emailSender = new SmtpEmailSender();

var processor = new OrderProcessor(repository, emailSender);
processor.Process(1001, "customer@example.com");
Console.WriteLine();

new Notification(
    new EmailChannel(),
    urgent: true,
    sendAt: DateTime.Today.AddHours(18))
    .Send("customer@example.com", "Your order ships tomorrow");

new Notification(
    new SmsChannel(),
    urgent: true)
    .Send("+201000000000", "OTP 4821");


new Notification(
    new WhatsAppChannel(),
    urgent: true)
    .Send("+201000000000", "Your order is ready");

