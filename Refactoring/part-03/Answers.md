# Part 03 — answers

---

## BlockedUsers

- Time complexity before:
  - O(B * R), where B is the number of blocked IDs and R is the number of requests.
- Time (ms) before:
  - 16 ms.
- What did you change?
  - Used a HashSet<int> for membership checks instead of repeatedly searching a List<int>. Compared both implementations using the same input data.
- Time complexity after:
  - O(B + R) on average, including building the HashSet.
- Time (ms) after:
  - 1 ms.

---

## Students

- What was the problem?
  - GetAllStudents eagerly created one million Student objects, even though Program.cs printed only the first three.
- What did you change?
  - Changed GetAllStudents to use yield return so students are generated lazily as requested.