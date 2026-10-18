
namespace RefactoringLab;

public class FedExCarrier : IShippingCarrier
{
    public string Name => "FedEx";

    public decimal Calculate(decimal weightKg)
    {
        return weightKg * 15m;
    }
}
