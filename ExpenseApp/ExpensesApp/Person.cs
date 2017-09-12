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
            TotalAmountOwed = 0;
            PersonIndebtedTo=new Dictionary<string, int>();
        }

        public string Name { get; set; }
        public int TotalAmountOwed { get; set; }
        public IDictionary<string, int> PersonIndebtedTo { get; set; }

        public string PrintAmountOwedByPerson()
        {
            if (TotalAmountOwed < 0)
                return $"{this.Name} gets {Math.Abs(this.TotalAmountOwed)}";
            return $"{this.Name} has to give {this.TotalAmountOwed}";
        }

        public string PrintAmountOwedByPersonToOtherPerson()
        {
            var result = "";
            foreach (var item in PersonIndebtedTo)
            {
                if(item.Value>0)
                    result = result + $"{Name} has to pay {item.Key} Rs {item.Value} \n";
                else
                    result = result + $"{Name} has to receive from {item.Key} Rs {Math.Abs(item.Value)} \n";
            }
            return result;
        }
    }
}