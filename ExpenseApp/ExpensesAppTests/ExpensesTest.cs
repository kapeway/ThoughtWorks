using System.Collections.Generic;
using System.Linq;
using ExpensesApp;
using NUnit.Framework;

namespace ExpensesAppTests
{
    [TestFixture]
    public class ExpensesTest
    {
        [Test]
        public void Expense_PersonPaid_ShouldReturnThePersonWhoPaidTheExpense()
        {
            var person = new Person("A");
            var sut = new Expense(100,person,null);
            var result = sut.PersonPaying;
            Assert.That(result, Is.EqualTo(person));
        }

        [Test]
        public void Expense_PeopleInvolvedInExpense_ShouldReturnTheListOfPersonWhoAreInTheExpense()
        {
            var personPaid = new Person("A");
            var personsPaidFor=new List<Person>{new Person("A"), new Person("B"), new Person("C"),new Person("D") };
            var sut = new Expense(100, personPaid, personsPaidFor);
            var result = sut.PersonsInTransaction;
            Assert.That(result, Is.EqualTo(personsPaidFor));
        }

        [Test]
        public void Expense_Process_ShouldSplitTheExpensesAmongPeopleInThePaidForGroupIfPersonPaidIsInList()
        {
            var personA = new Person("A");
            var personB = new Person("B");
            var personC = new Person("C");
            var personD = new Person("D");
            var sut = new Expense(100, personA, new List<Person> { personA, personB, personC, personD });
            sut.Process();
            Assert.That(personA.TotalAmountOwed, Is.EqualTo(-75));
            Assert.That(personA.PersonIndebtedTo.Count, Is.EqualTo(3));

            Assert.That(personB.TotalAmountOwed, Is.EqualTo(25));
            Assert.That(personB.PersonIndebtedTo.Count, Is.EqualTo(1));
            Assert.That(personB.PersonIndebtedTo["A"], Is.EqualTo(25));

            Assert.That(personC.TotalAmountOwed, Is.EqualTo(25));
            Assert.That(personC.PersonIndebtedTo.Count, Is.EqualTo(1));
            Assert.That(personC.PersonIndebtedTo["A"], Is.EqualTo(25));

            Assert.That(personD.TotalAmountOwed, Is.EqualTo(25));
            Assert.That(personD.PersonIndebtedTo.Count, Is.EqualTo(1));
            Assert.That(personD.PersonIndebtedTo["A"], Is.EqualTo(25));
        }

        [Test]
        public void Expense_Process_ShouldSplitWithAppropriateNumberIfPersonPaidNotInList()
        {
            var personA = new Person("A");
            var personB = new Person("B");
            var personC = new Person("C");
            var expense1 = new Expense(100, personA, new List<Person> { personB });
            expense1.Process();
            var expense2 = new Expense(100, personB, new List<Person> { personA });
            expense2.Process();
            var expense3 = new Expense(99, personC, new List<Person> { personA, personB, personC });
            expense3.Process();

            Assert.That(personA.TotalAmountOwed, Is.EqualTo(33));
            Assert.That(personA.PersonIndebtedTo.First().Value, Is.EqualTo(0));

            Assert.That(personB.TotalAmountOwed, Is.EqualTo(33));
            Assert.That(personB.PersonIndebtedTo.First().Value, Is.EqualTo(0));
        }
    }
}
