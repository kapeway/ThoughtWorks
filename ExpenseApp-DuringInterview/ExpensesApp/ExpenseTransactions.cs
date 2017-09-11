using System.Collections.Generic;

namespace ExpensesApp
{
    public class ExpenseTransactions
    {
        public string Name { get; set; }
        public int Amount { get; set; }
        public IList<string> PeopleInTransaction { get; set; }
    }
}