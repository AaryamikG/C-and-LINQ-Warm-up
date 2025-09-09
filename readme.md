# Lab: C# & LINQ Warm-Up

**Duration:** \~1 hour
**Context:** You are consultants working with a healthcare provider who want quick insights from outpatient appointment data.

---

## Learning Objectives

By the end of this lab, you will be able to:

* Explain how MVC separates concerns in a web application.
* Use dependency injection to consume services in ASP.NET Core.
* Apply LINQ to answer business-style questions from a dataset.
* Recognise how dependency injection makes your code more testable and maintainable.
* Submit your changes via a pull request with a reflective comment.

---

## Scene Setting — Healthcare Consultancy

A regional NHS Trust has asked your consultancy team to prototype an analytics tool for outpatient appointments.

They don’t want a full product yet — just quick answers to a few important questions using the data they already have.

You’ve been given a **starter ASP.NET Core MVC project** with models, a service interface, and seeded in-memory data. Your job is to implement **LINQ queries** to answer the Trust’s questions and return results through a service that can later be plugged into controllers/views.

---

## Starter Project

The repository contains:

```
/OutpatientsAnalytics
  /Controllers
    ReportsController.cs     // empty actions for you to implement
  /Models
    Appointment.cs
    Clinician.cs
    Department.cs
    Outcome.cs
    /ViewModels
      NoShowRateViewModel.cs
      TopClinicianViewModel.cs
      WaitTimeViewModel.cs
  /Services
    IDataContext.cs
    InMemoryDataContext.cs   // already wired up with sample data
    ReportsService.cs        // contains TODOs
  Program.cs                 // DI and MVC are set up
  README.md
```

The `InMemoryDataContext` already provides lists of `Appointment`, `Clinician`, and `Department`. You don't need to load CSVs.

You will implement methods inside **`ReportsService`** that consume `IDataContext` and return the answers, then expose them through **controller actions**.

---

## Your Tasks

### 1. Explore the Project (5 min)

* Open the solution and identify where **models**, **services**, **controllers**, and **DI registration** live.
* Find the `ReportsService`. Notice that it receives `IDataContext` via constructor injection.
* Look at the `ReportsController` - it's set up to use your service.

👉 Question to reflect on: *Why might constructor injection be better than instantiating `InMemoryDataContext` directly inside the service?*

---

### 2. LINQ Queries (25 min)

Implement the following methods in `ReportsService`. Use LINQ queries to work with the in-memory collections.

1. **No-show rate per department**

   * Group by `Department.Name`.
   * Count how many appointments have outcome `NoShow` vs total.
   * Return department name + no-show rate.

2. **Top 3 clinicians this month**

   * Filter appointments to those with outcome `Completed` in the current month.
   * Group by clinician.
   * Return the top 3 with the highest completed count.

3. **Average wait time (days) per specialty**

   * Compute difference between `ScheduledStartUtc` and `BookedUtc`.
   * Group by clinician specialty.
   * Return specialty + average wait in days.

👉 Use documentation and IntelliSense — don't just copy/paste code.

---

### 3. Add Controller Actions (10 min)

* In `ReportsController`, add three actions that call your service methods.
* Each action should return a simple JSON result.
* Use the existing view models in the `Models/ViewModels` folder.

---

### 4. Test Your Application (10 min)

* Run the application (`dotnet run`).
* Test both the console output and the web endpoints:
  * Console: Check that your numbers make sense by spot-checking a few rows in the seed data.
  * Web: Visit `/Reports/NoShowRates`, `/Reports/TopClinicians`, and `/Reports/WaitTimes` in your browser.

---

### 5. Reflection & PR (10 min)

* Create a **pull request** with your work.
* In the PR description, answer these reflection prompts (2–3 sentences each):

1. **LINQ:** Which operator (`GroupBy`, `Select`, `Average`, etc.) did you find most useful in this lab, and why?
2. **Dependency Injection:** Why is constructor injection preferable to creating a new `InMemoryDataContext` inside your service?
3. **MVC Separation:** Now that you've implemented both console output and web endpoints, which parts of your code stayed the same, and which parts were different between the two approaches?

---

## Stretch Goals (if time allows)

* Add a filter parameter to your “Top 3 clinicians” method so it can return results for a given specialty.
* Add a method for “Distribution of appointment outcomes by department”.

---

## Deliverables

* Updated `ReportsService` with working LINQ methods.
* Three controller actions that return JSON data.
* Console output that shows answers for the three business questions.
* Working web endpoints accessible via browser.
* A pull request with reflective answers to the three questions above.


