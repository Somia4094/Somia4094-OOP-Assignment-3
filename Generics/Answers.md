## Step 2 — A store for courses

**What is the same?**

Both stores use a List to store objects. They have the same four methods: Add, GetById, GetAll, and Remove. Both search for an item by its Id and return null if it is not found.

**What is different?**

StudentStore works with Student objects, which have Id and Name. CourseStore works with Course objects, which have Id, Title, and Price. The code is almost the same, but it is repeated for two different types.


## Step 3 — One class for both

**Compiler error:**  
Paste the actual compiler error here.

**Why does the compiler reject it?**

The compiler does not know that `T` has an `Id` property. `T` can represent any type, including types that do not have an `Id`. Therefore, accessing `item.Id` is not allowed without a constraint.


## Step 7 — Why Store<string> must NOT compile

`Store<string>` must not compile because `Store<T>` has the constraint `where T : IHasId`. The `string` type does not implement `IHasId` and does not provide the required `Id` property.

## Research — Common name

The common name for this kind of class is a **generic repository**. It provides common operations for storing, retrieving, and removing objects without duplicating the implementation for every type.