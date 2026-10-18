
namespace RefactoringLab;

public class BostaCarrier : IShippingCarrier
{
    public string Name => "Bosta";

    public decimal Calculate(decimal weightKg)
    {
        return weightKg * 10m;
    }
}
