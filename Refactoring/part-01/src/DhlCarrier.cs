
namespace RefactoringLab;

public class DhlCarrier : IShippingCarrier
{
	public string Name => "DHL";

	public decimal Calculate(decimal weightKg)
	{
		return weightKg * 18m;
	}
}
