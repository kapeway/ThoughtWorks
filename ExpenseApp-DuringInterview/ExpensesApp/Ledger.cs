using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace ExpensesApp
{
    public abstract class Ledger 
    {
        protected Ledger()
        {
            _ledger = new Dictionary<string, int>();
        }
        private IDictionary<string, int> _ledger { get; set; }
        public string Name { get; set; }

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

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Ledger) obj);
        }

        protected bool Equals(Ledger other)
        {
            return _ledger.SequenceEqual(other._ledger) && string.Equals(Name, other.Name);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_ledger != null ? _ledger.GetHashCode() : 0) * 397) ^ (Name != null ? Name.GetHashCode() : 0);
            }
        }
    }

    public class CreditsLedger : Ledger
    {
        public CreditsLedger(string name)
        {
            Name = name;
        }
    }

    public class DebitsLedger : Ledger
    {
        public DebitsLedger(string name)
        {
            Name = name;
        }
    }
}
