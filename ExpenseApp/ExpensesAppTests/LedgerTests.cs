using System.Linq;
using ExpensesApp;
using NUnit.Framework;

namespace ExpensesAppTests
{
    [TestFixture]
    class LedgerTests
    {
        [Test]
        public void CreditsLedger_UpdateLedger_CreatesNewEntryIfRecordDoesntExist()
        {
            var sut = new CreditsLedger("A");
            sut.UpdateLedger("B", 100);
            var result = sut.GetLedger();
            Assert.That(result.First().Key, Is.EqualTo("B"));
            Assert.That(result.First().Value, Is.EqualTo(100));
        }
        [Test]
        public void CreditsLedger_UpdateLedger_AddsValueIfRecordExist()
        {
            var sut = new CreditsLedger("A");
            sut.UpdateLedger("B", 100);
            sut.UpdateLedger("B", 50);
            var result = sut.GetLedger();
            Assert.That(result.First().Key, Is.EqualTo("B"));
            Assert.That(result.First().Value, Is.EqualTo(150));
        }
    }
}
