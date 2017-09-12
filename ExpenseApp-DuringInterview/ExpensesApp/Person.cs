using System;
using System.Collections.Generic;
using System.Linq;

namespace ExpensesApp
{
    public class Person
    {
        public Person(string name)
        {
            Name = name;
            Credits = new CreditsLedger(name + " Credit Ledger");
            Debits = new DebitsLedger(name + " Debit Ledger");
        }

        public string Name { get; set; }
        public CreditsLedger Credits { get; set; }
        public DebitsLedger Debits { get; set; }

        public string PrintTotalAmountDueOrOwed()
        {
            var totalAmountDueOrOwed = Credits.ComputeLedgerBalance() - Debits.ComputeLedgerBalance();
            return totalAmountDueOrOwed>0 ? $"{Name} gets {totalAmountDueOrOwed}" : $"{Name} has to give {Math.Abs(totalAmountDueOrOwed)}";
        }

        public string PrintAmountOwedOrDueByPerPerson()
        {
            var result = "";
            var debitsLedger = Debits.GetLedger();
            var creditsLedger = Credits.GetLedger();
            result = result + ProcessDebitLedgerForDuesAndOwes(creditsLedger, debitsLedger);
            result = result + ProcessCreditLedgerForOwesAndDues(creditsLedger, debitsLedger);
            return result;
        }

        private string ProcessDebitLedgerForDuesAndOwes(IDictionary<string, int> creditsLedger, IDictionary<string, int> debitsLedger)
        {
            var result = "";
            foreach (var debitEntry in debitsLedger)
            {
                if (creditsLedger.ContainsKey(debitEntry.Key))continue;
                result = result + $"{Name} has to pay {debitEntry.Key} Rs {debitEntry.Value}\n";
            }
            return result;
        }

        private string ProcessCreditLedgerForOwesAndDues(IDictionary<string, int> creditsLedger, IDictionary<string, int> debitsLedger)
        {
            var result = "";
            foreach (var creditEntry in creditsLedger)
            {
                if (creditEntry.Key == Name) continue;
                var balanceDueOrOwed = 0;
                if (debitsLedger.ContainsKey(creditEntry.Key))
                    balanceDueOrOwed = creditEntry.Value - debitsLedger[creditEntry.Key];
                else
                    balanceDueOrOwed = creditEntry.Value;

                if (balanceDueOrOwed > 0)
                    result = result + $"{Name} has to recieve from {creditEntry.Key} Rs {balanceDueOrOwed}\n";
                else
                    result = result + $"{Name} has to pay {creditEntry.Key} Rs {Math.Abs(balanceDueOrOwed)}\n";
            }
            return result;
        }
    }
}