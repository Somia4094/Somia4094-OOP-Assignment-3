var phoneTests = new (string? Input, bool Expected)[]
{
    ("01012345678", true),
    ("+201512345678", true),
    ("01312345678", false),
    ("0101234567", false),
    ("0101234567a", false)
};

Console.WriteLine("=== Egyptian Phone Validation ===");

foreach (var test in phoneTests)
{
    bool actual = test.Input.IsValidEgyptianPhone();

    Console.WriteLine(
        $"Input: {test.Input ?? "null"}, " +
        $"Expected: {test.Expected}, Actual: {actual}");
}

var nationalIdTests = new (string? Input, bool Expected)[]
{
    ("29901011234567", true),
    ("19901011234567", false),
    ("2990101123456", false)
};

Console.WriteLine();
Console.WriteLine("=== Egyptian National ID Validation ===");

foreach (var test in nationalIdTests)
{
    bool actual = test.Input.IsValidEgyptianNationalId();

    Console.WriteLine(
        $"Input: {test.Input ?? "null"}, " +
        $"Expected: {test.Expected}, Actual: {actual}");
}