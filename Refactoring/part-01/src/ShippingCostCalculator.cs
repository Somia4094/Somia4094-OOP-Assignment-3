namespace RefactoringLab;

public class ShippingCostCalculator
{
    private readonly IEnumerable<IShippingCarrier> _carriers;
    public ShippingCostCalculator(IEnumerable<IShippingCarrier> carriers)
    {
        _carriers = carriers;
    }

    public decimal Calculate(string carrier, decimal weightKg)
    {
        var selectedCarrier = _carriers.FirstOrDefault(
            c => c.Name.Equals(carrier, StringComparison.OrdinalIgnoreCase));

        if (selectedCarrier is null)
        {
            throw new ArgumentException($"Unknown carrier: {carrier}");
        }

        return selectedCarrier.Calculate(weightKg);
    }

}
