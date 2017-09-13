using System.Collections.Generic;
using System.Linq;
using ExpensesApp;
using ExpensesApp.AppHelper;
using ExpensesApp.Models;
using NUnit.Framework;

namespace ExpensesAppTests
{
    [TestFixture]
    public class ExpenseShareAppHelperTests
    {
        [Test]
        public void ExpenseShareAppHelper_UpdateLedgerForALoaningToB_DebitsAndCreditsAppropriateRegisters()
        {
            var dictionaryOfPersons = new Dictionary<string, Person> {{"A", new Person("A")}, {"B", new Person("B")}};
            var expenseTransaction1 = new ExpenseTransactions { Amount = 100, Name = "A", PeopleInTransaction = new List<string> { "B" } };
            ExpenseShareAppHelper.UpdateLedgerOfPersonsInvolvedInTransaction(dictionaryOfPersons, expenseTransaction1);
            var aCreditLedger = dictionaryOfPersons["A"].Credits.GetLedger();
            var bDebitsLedger = dictionaryOfPersons["B"].Debits.GetLedger();
            Assert.That(aCreditLedger.First().Key, Is.EqualTo("B"));
            Assert.That(aCreditLedger.First().Value, Is.EqualTo(100));
            Assert.That(bDebitsLedger.First().Key, Is.EqualTo("A"));
            Assert.That(bDebitsLedger.First().Value, Is.EqualTo(100));
        }

        [Test]
        public void ExpenseShareAppHelper_UpdateLedgerForBLoaningToA_DebitsAndCreditsAppropriateRegisters()
        {
            var dictionaryOfPersons = new Dictionary<string, Person> { { "A", new Person("A") }, { "B", new Person("B") } };
            var expenseTransaction1 = new ExpenseTransactions { Amount = 100, Name = "B", PeopleInTransaction = new List<string> { "A" } };
            ExpenseShareAppHelper.UpdateLedgerOfPersonsInvolvedInTransaction(dictionaryOfPersons, expenseTransaction1);
            var aDebitsLedger = dictionaryOfPersons["A"].Debits.GetLedger();
            var bCreditsLedger = dictionaryOfPersons["B"].Credits.GetLedger();
            Assert.That(aDebitsLedger.First().Key, Is.EqualTo("B"));
            Assert.That(aDebitsLedger.First().Value, Is.EqualTo(100));
            Assert.That(bCreditsLedger.First().Key, Is.EqualTo("A"));
            Assert.That(bCreditsLedger.First().Value, Is.EqualTo(100));
        }
        [Test]
        public void ExpenseShareAppHelper_AddNewPersonToGroupFromTransaction_DebitsAndCreditsAppropriateRegisters()
        {
            var expectedDictionaryOfPeople = new Dictionary<string, Person> {  { "B", new Person("B") }, { "A", new Person("A") } };
            var dictionaryOfPersons = new Dictionary<string, Person>();
            var expenseTransaction1 = new ExpenseTransactions { Amount = 100, Name = "B", PeopleInTransaction = new List<string> { "A" } };
            ExpenseShareAppHelper.AddNewPersonToGroupFromTransaction(dictionaryOfPersons, expenseTransaction1);
            CollectionAssert.AreEquivalent(dictionaryOfPersons, expectedDictionaryOfPeople);
        }
    }
}
