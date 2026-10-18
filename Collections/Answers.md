\# Collections \& Extension Methods



\## Task 2.1 - Research



\### 1. What is IReadOnlyDictionary<TKey, TValue>?



`IReadOnlyDictionary` lets us read data using keys, but it does not provide methods to add or remove items.



A normal `Dictionary` allows us to add, update, and remove items. We can return `IReadOnlyDictionary` from a public method when we want callers to read the data without giving them methods to change it. However, the original dictionary can still be changed by its owner.



\### 2. What is SortedDictionary<TKey, TValue>?



`SortedDictionary` stores items in key order. A normal `Dictionary` does not guarantee that items are sorted by key.



A normal `Dictionary` usually searches faster, with average O(1) lookup time. `SortedDictionary` usually takes O(log n) to search for a key.



I would use `SortedDictionary` when I need items to stay sorted by key, such as a timetable ordered by session start time.



\### Sources



\- Microsoft Learn - IReadOnlyDictionary: https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ireadonlydictionary-2

\- Microsoft Learn - SortedDictionary: https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.sorteddictionary-2

\- Wouter on Architecture - Choosing a C# Dictionary: https://wouteronarchitecture.com/choosing-a-csharp-dictionary/



\---



\## Task 2.2 - Pick the Collection



\### S1 - Find a student by national ID



\*\*Collection: Dictionary\*\*



I would use a Dictionary because it can find a student quickly using their national ID as the key.



\### S2 - Keep course tags without duplicates



\*\*Collection: HashSet\*\*



I would use a HashSet because it does not store duplicate tags.



\### S3 - Keep grades in the order they were entered



\*\*Collection: List\*\*



I would use a List because it keeps grades in the order they were added and allows duplicate grades.



\### S4 - Return a course price list that callers can only read



\*\*Collection: IReadOnlyDictionary\*\*



I would use IReadOnlyDictionary because callers need to read course prices but should not be given methods to change them.



\### S5 - Keep timetable sessions sorted by start time



\*\*Collection: SortedDictionary\*\*



I would use SortedDictionary because it keeps sessions sorted by their start-time keys.



\### S6 - Return results that the caller may stop iterating over early



\*\*Collection: IEnumerable\*\*



I would use IEnumerable because the caller can read results one at a time and stop whenever needed.

