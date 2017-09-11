using System.Collections.Generic;

namespace ExpensesApp
{
    public class Expense
    {
        private readonly int _expenseAmount;
        public Person PersonPaid { get; set; }
        public IList<Person> PersonsPaidFor { get; set; }

        public Expense(int expenseAmount, Person personPaid, IList<Person> personsesPaidFor)
        {
            _expenseAmount = expenseAmount;
            PersonPaid = personPaid;
            PersonsPaidFor = personsesPaidFor;
        }

        public int GetTotalAmount()
        {
            return _expenseAmount;
        }

        public void Process()
        {
            if (PersonsPaidFor.Contains(PersonPaid))
            {
                var shareAmount = GetTotalAmount() / PersonsPaidFor.Count;
                foreach (var person in PersonsPaidFor)
                {
                    if (person.Name == PersonPaid.Name)
                    {
                        person.TotalAmountOwed = person.TotalAmountOwed - (GetTotalAmount() - shareAmount);
                    }
                    else
                    {
                        person.TotalAmountOwed = person.TotalAmountOwed + shareAmount;
                        if (!person.PeopleIndebtedTo.ContainsKey(PersonPaid.Name))
                            person.PeopleIndebtedTo.Add(PersonPaid.Name, shareAmount);
                        else
                            person.PeopleIndebtedTo[PersonPaid.Name] = person.PeopleIndebtedTo[PersonPaid.Name] + shareAmount;
                    }
                }
            }
            else
            {
                var shareAmount = GetTotalAmount() / PersonsPaidFor.Count;
                foreach (var person in PersonsPaidFor)
                {
                    person.TotalAmountOwed = person.TotalAmountOwed + shareAmount;
                }
                PersonPaid.TotalAmountOwed = PersonPaid.TotalAmountOwed - GetTotalAmount();
            }
        }
    }
}