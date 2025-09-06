using System;
using ExpenseTracker.Services;

namespace ExpenseTracker
{
    class Program
    {
        static void Main(string[] args)
        {
            ExpenseService expenseService = new ExpenseService();
            bool running = true;

            while (running)
            {
                Console.WriteLine("\n--- Expense Tracker ---");
                Console.WriteLine("1. Add Expense");
                Console.WriteLine("2. View All Expenses");
                Console.WriteLine("3. View Expenses by Category");
                Console.WriteLine("4. Calculate Total Expenses");
                Console.WriteLine("5. Delete Expense");
                Console.WriteLine("6. Update Expense");
                Console.WriteLine("7. View Expenses by Date Range");
                Console.WriteLine("8. Sort Expenses");
                Console.WriteLine("9. Summary Report by Category");
                Console.WriteLine("10. Exit");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter Amount: ");
                        decimal amount = decimal.Parse(Console.ReadLine());
                        Console.Write("Enter Category: ");
                        string category = Console.ReadLine();
                        Console.Write("Enter Date (yyyy-mm-dd): ");
                        DateTime date = DateTime.Parse(Console.ReadLine());
                        Console.Write("Enter Description: ");
                        string desc = Console.ReadLine();
                        expenseService.AddExpense(amount, category, date, desc);
                        break;

                    case "2":
                        expenseService.ViewExpenses();
                        break;

                    case "3":
                        Console.Write("Enter Category: ");
                        string filterCategory = Console.ReadLine();
                        expenseService.ViewExpensesByCategory(filterCategory);
                        break;

                    case "4":
                        expenseService.CalculateTotalExpenses();
                        break;

                    case "5":
                        Console.Write("Enter Expense ID to Delete: ");
                        int delId = int.Parse(Console.ReadLine());
                        expenseService.DeleteExpense(delId);
                        break;

                    case "6":
                        Console.Write("Enter Expense ID to Update: ");
                        int updId = int.Parse(Console.ReadLine());
                        Console.Write("Enter New Amount: ");
                        decimal newAmount = decimal.Parse(Console.ReadLine());
                        Console.Write("Enter New Category: ");
                        string newCategory = Console.ReadLine();
                        Console.Write("Enter New Date (yyyy-mm-dd): ");
                        DateTime newDate = DateTime.Parse(Console.ReadLine());
                        Console.Write("Enter New Description: ");
                        string newDesc = Console.ReadLine();
                        expenseService.UpdateExpense(updId, newAmount, newCategory, newDate, newDesc);
                        break;

                    case "7":
                        Console.Write("Enter Start Date (yyyy-mm-dd): ");
                        DateTime startDate = DateTime.Parse(Console.ReadLine());
                        Console.Write("Enter End Date (yyyy-mm-dd): ");
                        DateTime endDate = DateTime.Parse(Console.ReadLine());
                        expenseService.ViewExpensesByDateRange(startDate, endDate);
                        break;

                    case "8":
                        Console.Write("Sort by 'amount' or 'date': ");
                        string criteria = Console.ReadLine();
                        expenseService.SortExpenses(criteria);
                        break;

                    case "9":
                        expenseService.SummaryReportByCategory();
                        break;

                    case "10":
                        running = false;
                        Console.WriteLine("Exiting...");
                        break;

                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }
        }
    }
}
