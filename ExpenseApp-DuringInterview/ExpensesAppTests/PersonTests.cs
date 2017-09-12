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
            var sut = new Person("A");
            Assert.That(sut.Name, Is.EqualTo("A"));
        }
        [Test]
        public void Person_PrintTotalAmountDueOrOwed_ReturnsTotalAmountDueOrOwnedByPerson()
        {
            var sut = new Person("A");
            Assert.That(sut.PrintTotalAmountDueOrOwed(), Is.EqualTo("A has to give 0"));
        }

    }
}
