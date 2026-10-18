namespace RefactoringLab;

public interface IShippingCarrier
{
    string Name { get; }

    decimal Calculate(decimal weightKg);

}
