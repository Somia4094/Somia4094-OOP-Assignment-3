
namespace RefactoringLab;

public interface INotificationSender
{
    void Send(string to, string body);
}
