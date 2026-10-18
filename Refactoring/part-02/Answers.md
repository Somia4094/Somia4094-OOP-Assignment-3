
# Part 02 — answers

---

## Reports

- What was the problem?
  - The three exporters duplicated the loading, validation, and saving steps, making changes harder to maintain.
- What did you change?
  - Introduced an abstract ReportExporter class containing the common export workflow. Each concrete exporter implements only the Format method.
- Why did you choose that approach?
  - The Template Method pattern centralizes the shared algorithm while allowing each report type to provide its own formatting.

---

## Enrollment

- What was the problem?
  - Program.cs directly coordinated all enrollment operations and depended on concrete service classes.
- What did you change?
  - Introduced service interfaces and an EnrollmentService that receives its dependencies through constructor injection and coordinates the enrollment workflow.
- Why did you choose that approach?
  - This separates orchestration from the entry point and reduces coupling to concrete implementations, making services easier to replace and test.
