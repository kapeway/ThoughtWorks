using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace ExpensesApp
{
    public abstract class Ledger 
    {
        protected Ledger()
        {
            _ledger = new Dictionary<string, int>();
        }
        private IDictionary<string, int> _ledger { get; set; }

        public int ComputeLedgerBalance()
        {
            return _ledger.Sum(item => item.Value);
        }

        public void UpdateLedger(string ledgerKey,int amount)
        {
            if (_ledger.ContainsKey(ledgerKey))
                _ledger[ledgerKey] += amount;
            else
                _ledger[ledgerKey] = amount;
        }

        public IDictionary<string, int> GetLedger()
        {
            return _ledger;
        }
    }

    public class CreditsLedger : Ledger
    {
        public CreditsLedger(string name)
        {
            Name = name;
        }
        public string Name { get; set; }

    }
    public class DebitsLedger : Ledger
    {
        public DebitsLedger(string name)
        {
            Name = name;
        }
        public string Name { get; set; }
    }
}
