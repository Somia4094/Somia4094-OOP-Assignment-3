
namespace RefactoringLab.Part02.Enrollment;

public interface IPaymentGateway
{
    void Charge(string studentId, decimal amount);
}

public interface ISeatInventory
{
    void Reserve(string courseId, string studentId);
}

public interface IInvoiceGenerator
{
    string Create(string studentId, decimal amount);
}

public interface IEmailService
{
    void Send(string studentId, string subject, string body);
}

public class PaymentGateway : IPaymentGateway
{
    public void Charge(string studentId, decimal amount) =>
        Console.WriteLine($"charge {studentId}: {amount}");
}

public class SeatInventory : ISeatInventory
{
    public void Reserve(string courseId, string studentId) =>
        Console.WriteLine($"reserve seat {courseId} for {studentId}");
}

public class InvoiceGenerator : IInvoiceGenerator
{
    public string Create(string studentId, decimal amount)
    {
        var invoiceId = $"INV-{studentId}-{amount}";
        Console.WriteLine($"invoice {invoiceId}");
        return invoiceId;
    }
}

public class EmailService : IEmailService
{
    public void Send(string studentId, string subject, string body) =>
        Console.WriteLine($"email {studentId}: {subject} / {body}");
}

public class EnrollmentService
{
    private readonly IPaymentGateway _payment;
    private readonly ISeatInventory _seats;
    private readonly IInvoiceGenerator _invoices;
    private readonly IEmailService _email;

    public EnrollmentService(
        IPaymentGateway payment,
        ISeatInventory seats,
        IInvoiceGenerator invoices,
        IEmailService email)
    {
        _payment = payment;
        _seats = seats;
        _invoices = invoices;
        _email = email;
    }

    public void Enroll(string studentId, string courseId, decimal amount)
    {
        _payment.Charge(studentId, amount);
        _seats.Reserve(courseId, studentId);

        var invoiceId = _invoices.Create(studentId, amount);

        _email.Send(
            studentId,
            "Enrollment confirmed",
            $"Invoice {invoiceId} for {courseId}");
    }
}
