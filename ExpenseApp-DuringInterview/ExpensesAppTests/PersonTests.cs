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
            Assert.That(sut.ExpensesShare, Is.EqualTo(0));
        }

        [Test]
        public void Person_PayExpense_ShouldSplitTheExpensesAmongPeopleInThePaidForGroupIfPersonPaidIsInList ()
        {
            var sut = new Person("A");
            var personB= new Person("B");
            var personC = new Person("C");
            var personD = new Person("D");
            sut.PayExpense(new Expense(100,sut,new List<Person>{sut,personB,personC,personD}));
            Assert.That(sut.ExpensesShare,Is.EqualTo(-75));
            Assert.That(personB.ExpensesShare, Is.EqualTo(25));
            Assert.That(personC.ExpensesShare, Is.EqualTo(25));
            Assert.That(personD.ExpensesShare, Is.EqualTo(25));
        }

        [Test]
        public void Person_PayExpense_ShouldSplitWithAppropriateNumberIfPersonPaidNotInList()
        {
            var sut = new Person("A");
            var personB = new Person("B");
            sut.PayExpense(new Expense(100, sut, new List<Person> { personB}));
            Assert.That(sut.ExpensesShare, Is.EqualTo(-100));
            Assert.That(personB.ExpensesShare, Is.EqualTo(100));
        }

        [Test]
        public void Person_GetExpenseSharePersonPaid_ShouldGetBackHisShare()
        {
            var sut = new Person("A");
            var personB = new Person("B");
            sut.PayExpense(new Expense(100, sut, new List<Person> { sut, personB }));
            var result = sut.GetExpenseShare();
            Assert.That(result,Is.EqualTo("A gets 50"));
        }

        [Test]
        public void Person_GetExpenseSharePersonReceived_ShouldGiveBackHisShare()
        {
            var personA = new Person("A");
            var sut = new Person("B");
            personA.PayExpense(new Expense(100, personA, new List<Person> { sut, personA }));
            var result = sut.GetExpenseShare();
            Assert.That(result, Is.EqualTo("B has to give 50"));
        }

    }
}
