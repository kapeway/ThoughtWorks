using System.Collections.Generic;

namespace ExpensesApp
{
    public class Expense
    {
        private readonly int _expenseAmount;
        public Person PersonPaid { get; set; }
        public IList<Person> PersonPaidFor { get; set; }

        public Expense(int expenseAmount, Person personPaid, List<Person> personsPaidFor)
        {
            _expenseAmount = expenseAmount;
            PersonPaid = personPaid;
            PersonPaidFor = personsPaidFor;
        }

        public int GetTotalAmount()
        {
            return _expenseAmount;
        }
    }
}