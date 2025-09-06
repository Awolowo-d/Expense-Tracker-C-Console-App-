using System;

namespace ExpenseTracker.Models
{
    public class Expense
    {
        private static int _counter = 1;   // Auto-incrementing ID

        public int Id { get; private set; }         // Unique ID
        public decimal Amount { get; set; }         // Money spent
        public string Category { get; set; }        // e.g., Food, Transport
        public DateTime Date { get; set; }          // Date of expense
        public string Description { get; set; }     // Optional details

        // Constructor
        public Expense(decimal amount, string category, DateTime date, string description)
        {
            Id = _counter++;
            Amount = amount;
            Category = category;
            Date = date;
            Description = description;
        }
    }
}
