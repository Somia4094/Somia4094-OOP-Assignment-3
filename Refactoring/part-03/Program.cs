
using RefactoringLab.Part03.BlockedUsers;
using RefactoringLab.Part03.Students;

Console.WriteLine("=== Blocked users ===");

const int blockedCount = 50_000;
const int requestCount = 5_000;

var blockedIds = BlockedUserChecker.BuildBlockedIds(blockedCount);
var requestIds = BlockedUserChecker.BuildRequestIds(requestCount, blockedCount);

var slowMs = BlockedUserChecker.MeasureMs(
    blockedIds, requestIds, out var slowFound, useHashSet: false);

var fastMs = BlockedUserChecker.MeasureMs(
    blockedIds, requestIds, out var fastFound, useHashSet: true);

Console.WriteLine(
    $"Before (List): found={slowFound}, time={slowMs} ms");

Console.WriteLine(
    $"After (HashSet): found={fastFound}, time={fastMs} ms");

Console.WriteLine();

Console.WriteLine("=== Students (1_000_000) ===");

var printed = 0;

foreach (var student in StudentCatalog.GetAllStudents())
{
    Console.WriteLine($"{student.Id}: {student.Name}");
    printed++;

    if (printed == 3)
        break;
}

Console.WriteLine($"printed={printed}");
