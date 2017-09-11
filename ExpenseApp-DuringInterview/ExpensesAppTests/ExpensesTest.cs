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
            var result = sut.PersonPaidFor;
            Assert.That(result, Is.EqualTo(personsPaidFor));
        }

    }
}
