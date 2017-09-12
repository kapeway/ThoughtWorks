using System.Collections.Generic;

namespace ExpensesApp
{
    class DataImportHelper
    {
        public static List<ExpenseTransactions> ImportListOfTransactions()
        {
            var expenseTransactions1 = new ExpenseTransactions
            {
                Amount = 100,
                Name = "A",
                PeopleInTransaction = new List<string> { "A", "B", "C", "D" }
            };
            var expenseTransactions2 = new ExpenseTransactions
            {
                Amount = 500,
                Name = "B",
                PeopleInTransaction = new List<string> { "C", "D" }
            };
            var expenseTransactions3 = new ExpenseTransactions
            {
                Amount = 300,
                Name = "D",
                PeopleInTransaction = new List<string> { "A", "B" }
            };

            return new List<ExpenseTransactions> { expenseTransactions1, expenseTransactions2, expenseTransactions3 };
        }
    }
}