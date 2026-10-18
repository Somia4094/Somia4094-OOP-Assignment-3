namespace RefactoringLab;

public class AramexCarrier : IShippingCarrier

{
    public string Name => "Aramex";


    public decimal Calculate(decimal weightKg)
    {
        return weightKg * 12m;

    }
}