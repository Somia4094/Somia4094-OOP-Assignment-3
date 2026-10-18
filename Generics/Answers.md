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