using System;

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
            return totalAmountDueOrOwed>0 ? $"{Name} is owed Rs {totalAmountDueOrOwed}" : $"{Name} ows Rs {Math.Abs(totalAmountDueOrOwed)}";
        }

        public string PrintAmountOwedOrDueByPerPerson()
        {
            var result = "";
            var totalAmountDueOrOwed = Credits.ComputeLedgerBalance() - Debits.ComputeLedgerBalance();
            if (totalAmountDueOrOwed > 0)
            {
                var debitsLedger = Debits.GetLedger();
                foreach (var entry in debitsLedger)
                {
                    if (entry.Key != Name)
                        result += $"{entry.Key} owes Rs {entry.Value} to {Name}\n";
                }
            }
            else
            {
                var creditsLedger = Credits.GetLedger();
                foreach (var entry in creditsLedger)
                {
                    if (entry.Key != Name)
                        result += $"{entry.Key} is owed Rs {entry.Value} by {Name}\n";
                }

            }
            return result;
        }
    }
}