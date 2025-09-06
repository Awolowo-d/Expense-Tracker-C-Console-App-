using System;
using System.Collections.Generic;
using System.Linq;
using ExpenseTracker.Models;

namespace ExpenseTracker.Services
{
    public class ExpenseService
    {
        private List<Expense> expenses = new List<Expense>();

        // 1. Add Expense
        public void AddExpense(decimal amount, string category, DateTime date, string description)
        {
            var expense = new Expense(amount, category, date, description);
            expenses.Add(expense);
            Console.WriteLine($"Expense added: ID={expense.Id}, {expense.Category}, {expense.Amount}, {expense.Date.ToShortDateString()}");
        }

        // 2. View All Expenses
        public void ViewExpenses()
        {
            if (expenses.Count == 0)
            {
                Console.WriteLine("No expenses recorded.");
                return;
            }

            foreach (var exp in expenses)
            {
                Console.WriteLine($"ID: {exp.Id}, Amount: {exp.Amount}, Category: {exp.Category}, Date: {exp.Date.ToShortDateString()}, Desc: {exp.Description}");
            }
        }

        // 3. View Expenses by Category
        public void ViewExpensesByCategory(string category)
        {
            var filtered = expenses.Where(e => e.Category.Equals(category, StringComparison.OrdinalIgnoreCase)).ToList();
            if (filtered.Count == 0)
            {
                Console.WriteLine($"No expenses found in category: {category}");
                return;
            }

            foreach (var exp in filtered)
            {
                Console.WriteLine($"ID: {exp.Id}, Amount: {exp.Amount}, Date: {exp.Date.ToShortDateString()}, Desc: {exp.Description}");
            }
        }

        // 4. Calculate Total Expenses
        public void CalculateTotalExpenses()
        {
            decimal total = expenses.Sum(e => e.Amount);
            Console.WriteLine($"Total Expenses: {total}");
        }

        // 5. Delete Expense
        public void DeleteExpense(int id)
        {
            var exp = expenses.Find(e => e.Id == id);
            if (exp != null)
            {
                expenses.Remove(exp);
                Console.WriteLine($"Expense with ID {id} deleted.");
            }
            else
            {
                Console.WriteLine("Expense not found.");
            }
        }

        // 6. Update Expense
        public void UpdateExpense(int id, decimal newAmount, string newCategory, DateTime newDate, string newDescription)
        {
            var exp = expenses.Find(e => e.Id == id);
            if (exp != null)
            {
                exp.Amount = newAmount;
                exp.Category = newCategory;
                exp.Date = newDate;
                exp.Description = newDescription;
                Console.WriteLine($"Expense with ID {id} updated.");
            }
            else
            {
                Console.WriteLine("Expense not found.");
            }
        }

        // 7. View Expenses by Date Range
        public void ViewExpensesByDateRange(DateTime start, DateTime end)
        {
            var filtered = expenses.Where(e => e.Date >= start && e.Date <= end).ToList();
            if (filtered.Count == 0)
            {
                Console.WriteLine($"No expenses found between {start.ToShortDateString()} and {end.ToShortDateString()}.");
                return;
            }

            foreach (var exp in filtered)
            {
                Console.WriteLine($"ID: {exp.Id}, Amount: {exp.Amount}, Category: {exp.Category}, Date: {exp.Date.ToShortDateString()}, Desc: {exp.Description}");
            }
        }

        // 8. Sort Expenses
        public void SortExpenses(string criteria)
        {
            List<Expense> sorted;

            if (criteria.Equals("amount", StringComparison.OrdinalIgnoreCase))
                sorted = expenses.OrderByDescending(e => e.Amount).ToList();
            else if (criteria.Equals("date", StringComparison.OrdinalIgnoreCase))
                sorted = expenses.OrderByDescending(e => e.Date).ToList();
            else
            {
                Console.WriteLine("Invalid sort criteria. Use 'amount' or 'date'.");
                return;
            }

            foreach (var exp in sorted)
            {
                Console.WriteLine($"ID: {exp.Id}, Amount: {exp.Amount}, Category: {exp.Category}, Date: {exp.Date.ToShortDateString()}");
            }
        }

        // 9. Summary Report by Category
        public void SummaryReportByCategory()
        {
            if (expenses.Count == 0)
            {
                Console.WriteLine("No expenses recorded.");
                return;
            }

            var summary = expenses
                .GroupBy(e => e.Category)
                .Select(g => new { Category = g.Key, Total = g.Sum(e => e.Amount) });

            Console.WriteLine("\n--- Summary Report by Category ---");
            foreach (var item in summary)
            {
                Console.WriteLine($"{item.Category}: {item.Total}");
            }
            Console.WriteLine($"Overall Total: {expenses.Sum(e => e.Amount)}");
        }
    }
}
