using System;
using System.Collections.Generic;

namespace ExpensesApp
{
    public class Person
    {
        public Person(string name)
        {
            Name = name;
            ExpensesShare = 0;
        }

        public string Name { get; set; }
        public int ExpensesShare { get; set; }
        public void PayExpense(Expense expense)
        {
            if (expense.PersonPaidFor.Contains(expense.PersonPaid))
            {
                var shareAmount = expense.GetTotalAmount() / expense.PersonPaidFor.Count;
                foreach (var person in expense.PersonPaidFor)
                {
                    if (person.Name == Name)
                        person.ExpensesShare = person.ExpensesShare - (expense.GetTotalAmount()-shareAmount);
                    else
                        person.ExpensesShare = person.ExpensesShare + shareAmount;
                }
            }
            else
            {
                var shareAmount = expense.GetTotalAmount() / expense.PersonPaidFor.Count;
                foreach (var person in expense.PersonPaidFor)
                {
                    person.ExpensesShare = person.ExpensesShare + shareAmount;
                }
                expense.PersonPaid.ExpensesShare = expense.PersonPaid.ExpensesShare - expense.GetTotalAmount();
            }
        }

        public string GetExpenseShare()
        {
            if (this.ExpensesShare < 0)
                return $"{this.Name} gets {Math.Abs(this.ExpensesShare)}";
            return $"{this.Name} has to give {this.ExpensesShare}";
        }
    }
}