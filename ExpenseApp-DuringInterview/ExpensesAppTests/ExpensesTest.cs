using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpensesApp;
using NUnit.Framework;

namespace ExpensesAppTests
{
    [TestFixture]
    public class ExpensesTest
    {
        [Test]
        public void Expense_GetTotalAmount_ShouldReturnTheTotalExpenseAmount()
        {
            var sut = new Expense(100,null,null);
            var result = sut.GetTotalAmount();
            Assert.That(result, Is.EqualTo(100));
        }

        [Test]
        public void Expense_PersonPaid_ShouldReturnThePersonWhoPaidTheExpense()
        {
            var person = new Person("A");
            var sut = new Expense(100,person,null);
            var result = sut.PersonPaid;
            Assert.That(result, Is.EqualTo(person));
        }

        [Test]
        public void Expense_PeopleInvolvedInExpense_ShouldReturnTheListOfPersonWhoAreInTheExpense()
        {
            var personPaid = new Person("A");
            var personsPaidFor=new List<Person>{new Person("A"), new Person("B"), new Person("C"),new Person("D") };
            var sut = new Expense(100, personPaid, personsPaidFor);
            var result = sut.PersonsPaidFor;
            Assert.That(result, Is.EqualTo(personsPaidFor));
        }

        [Test]
        public void Person_PayExpense_ShouldSplitTheExpensesAmongPeopleInThePaidForGroupIfPersonPaidIsInList()
        {
            var personA = new Person("A");
            var personB = new Person("B");
            var personC = new Person("C");
            var personD = new Person("D");
            var sut = new Expense(100, personA, new List<Person> { personA, personB, personC, personD });
            sut.Process();
            Assert.That(personA.TotalAmountOwed, Is.EqualTo(-75));
            Assert.That(personA.PeopleIndebtedTo.Count, Is.EqualTo(0));

            Assert.That(personB.TotalAmountOwed, Is.EqualTo(25));
            Assert.That(personB.PeopleIndebtedTo.Count, Is.EqualTo(1));
            Assert.That(personB.PeopleIndebtedTo["A"], Is.EqualTo(25));

            Assert.That(personC.TotalAmountOwed, Is.EqualTo(25));
            Assert.That(personC.PeopleIndebtedTo.Count, Is.EqualTo(1));
            Assert.That(personC.PeopleIndebtedTo["A"], Is.EqualTo(25));

            Assert.That(personD.TotalAmountOwed, Is.EqualTo(25));
            Assert.That(personD.PeopleIndebtedTo.Count, Is.EqualTo(1));
            Assert.That(personD.PeopleIndebtedTo["A"], Is.EqualTo(25));
        }

        [Test]
        public void Person_PayExpense_ShouldSplitWithAppropriateNumberIfPersonPaidNotInList()
        {
            var personA = new Person("A");
            var personB = new Person("B");
            var expense = new Expense(100, personA, new List<Person> { personB });
            expense.Process();
            Assert.That(personA.TotalAmountOwed, Is.EqualTo(-100));
            Assert.That(personB.TotalAmountOwed, Is.EqualTo(100));
        }

    }
}
