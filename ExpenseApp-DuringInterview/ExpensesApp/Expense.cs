using System.Collections.Generic;

namespace ExpensesApp
{
    public class Expense
    {
        private readonly int _totalAmount;
        public Person PersonPaying { get; set; }
        public IList<Person> PersonsInTransaction { get; set; }

        public Expense(int totalAmount, Person personPaying, IList<Person> personsInTransaction)
        {
            _totalAmount = totalAmount;
            PersonPaying = personPaying;
            PersonsInTransaction = personsInTransaction;
        }

        public void Process()
        {
            if (PersonsInTransaction.Contains(PersonPaying))
            {
                var perPersonShare = _totalAmount / PersonsInTransaction.Count;
                foreach (var personInTransaction in PersonsInTransaction)
                {
                    if (PersonPaying.Name == personInTransaction.Name)
                    {
                        var personPayingNetAmount = _totalAmount - perPersonShare;
                        PersonPaying.TotalAmountOwed = PersonPaying.TotalAmountOwed - personPayingNetAmount;
                    }
                    else
                    {
                        personInTransaction.TotalAmountOwed = personInTransaction.TotalAmountOwed + perPersonShare;
                        AddIndebtedAmountPerPerson(personInTransaction, perPersonShare);
                        SubtractIndebtedAmountFromPersonPaying(personInTransaction, perPersonShare);
                    }
                }
            }
            else
            {
                var perPersonShare = _totalAmount / PersonsInTransaction.Count;
                foreach (var personInTransaction in PersonsInTransaction)
                {
                    personInTransaction.TotalAmountOwed = personInTransaction.TotalAmountOwed + perPersonShare;
                    AddIndebtedAmountPerPerson(personInTransaction, perPersonShare);
                    SubtractIndebtedAmountFromPersonPaying(personInTransaction, perPersonShare);
                }
                PersonPaying.TotalAmountOwed = PersonPaying.TotalAmountOwed - _totalAmount;
            }
        }

        private void SubtractIndebtedAmountFromPersonPaying(Person p, int shareAmount)
        {
            if (!PersonPaying.PersonIndebtedTo.ContainsKey(p.Name))
                PersonPaying.PersonIndebtedTo.Add(p.Name, -shareAmount);
            else
                PersonPaying.PersonIndebtedTo[p.Name] = PersonPaying.PersonIndebtedTo[p.Name] - shareAmount;
        }


        private void AddIndebtedAmountPerPerson(Person p, int shareAmount)
        {
            if (!p.PersonIndebtedTo.ContainsKey(PersonPaying.Name))
                p.PersonIndebtedTo.Add(PersonPaying.Name, shareAmount);
            else
                p.PersonIndebtedTo[PersonPaying.Name] = p.PersonIndebtedTo[PersonPaying.Name] + shareAmount;
        }
    }
}