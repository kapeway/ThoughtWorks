using System.Collections.Generic;
using ExpensesApp;
using NUnit.Framework;

namespace ExpensesAppTests
{
    [TestFixture]
    public class PersonTests
    {
        [Test]
        public void Person_Name_ReturnsPersonName()
        {
            var sut=new Person("A");
            Assert.That(sut.Name,Is.EqualTo("A"));
            Assert.That(sut.TotalAmountOwed, Is.EqualTo(0));
        }

        [Test]
        public void Person_PrintAmountOwedByPerson_ShouldPrintHisShareToGetBack()
        {
            var sut = new Person("A");
            var personB = new Person("B");
            var expense = new Expense(100, sut, new List<Person> { sut, personB });
            expense.Process();
            var result = sut.PrintAmountOwedByPerson();
            Assert.That(result,Is.EqualTo("A gets 50"));
        }

        [Test]
        public void Person_PrintAmountOwedByPerson_ShouldPrintHisShareToGiveBack()
        {
            var personA = new Person("A");
            var sut = new Person("B");
            var expense = new Expense(100, personA, new List<Person> { sut, personA });
            expense.Process();
            var result = sut.PrintAmountOwedByPerson();
            Assert.That(result, Is.EqualTo("B has to give 50"));
        }

        [Test]
        public void Person_PrintAmountOwedByPersonToOtherPerson_ShouldPrintIndividualPersonsShare()
        {
            var sut = new Person("A");
            var personB = new Person("B");
            var expense = new Expense(100, sut, new List<Person> { sut, personB });
            expense.Process();
            var result = sut.PrintAmountOwedByPersonToOtherPerson();
            Assert.That(result, Is.EqualTo("A has to receive from B Rs 50 \n"));
        }
        [Test]
        public void Person_PrintAmountOwedByPersonToOtherPerson_ShouldPrintHisShareToGiveBack()
        {
            var personA = new Person("A");
            var sut = new Person("B");
            var expense = new Expense(100, personA, new List<Person> { sut, personA });
            expense.Process();
            var result = sut.PrintAmountOwedByPersonToOtherPerson();
            Assert.That(result, Is.EqualTo("B has to pay A Rs 50 \n"));
        }
    }
}
