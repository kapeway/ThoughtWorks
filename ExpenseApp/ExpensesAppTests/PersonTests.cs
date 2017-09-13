using ExpensesApp;
using ExpensesApp.Models;
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
        public void Person_PrintTotalAmountDueOrOwedWhenNoTransaction_ReturnsDefaultDtring()
        {
            var sut = new Person("A");
            Assert.That(sut.PrintTotalAmountDueOrOwed(), Is.EqualTo("A has to give 0"));
        }
        [Test]
        public void Person_PrintAmountOwedOrDueByPerPersonWhenNoTransaction_ReturnsEmptyString()
        {
            var sut = new Person("A");
            Assert.That(sut.PrintAmountOwedOrDueByPerPerson(), Is.EqualTo(""));
        }
        [Test]
        public void Person_PrintTotalAmountDueOrOwedWhenCreditHigher_ReturnsDefaultDtring()
        {
            var sut = new Person("A");
            sut.Credits.UpdateLedger("B",100);
            Assert.That(sut.PrintTotalAmountDueOrOwed(), Is.EqualTo("A gets 100"));
        }
        [Test]
        public void Person_PrintTotalAmountDueOrOwedWhenDebitHigher_ReturnsDefaultDtring()
        {
            var sut = new Person("A");
            sut.Debits.UpdateLedger("B", 100);
            Assert.That(sut.PrintTotalAmountDueOrOwed(), Is.EqualTo("A has to give 100"));
        }

        [Test]
        public void Person_PrintAmountOwedOrDueByPerPerson_ReturnsEmptyString()
        {
            var sut = new Person("A");
            Assert.That(sut.PrintAmountOwedOrDueByPerPerson(), Is.EqualTo(""));
        }
        [Test]
        public void Person_PrintAmountOwedOrDueByPerPersonWhenCreditHigher_ReturnsDefaultDtring()
        {
            var sut = new Person("A");
            sut.Credits.UpdateLedger("B", 100);
            Assert.That(sut.PrintAmountOwedOrDueByPerPerson(), Is.EqualTo("A has to recieve from B Rs 100\n"));
        }
        [Test]
        public void Person_PrintAmountOwedOrDueByPerPersonWhenDebitHigher_ReturnsDefaultDtring()
        {
            var sut = new Person("A");
            sut.Debits.UpdateLedger("B", 100);
            Assert.That(sut.PrintAmountOwedOrDueByPerPerson(), Is.EqualTo("A has to pay B Rs 100\n"));
        }


    }
}
