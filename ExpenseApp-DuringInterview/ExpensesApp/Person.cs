using System;
using System.Collections.Generic;

namespace ExpensesApp
{
    public class Person
    {
        public Person(string name)
        {
            Name = name;
            TotalAmountOwed = 0;
            PeopleIndebtedTo=new Dictionary<string, int>();
        }

        public string Name { get; set; }
        public int TotalAmountOwed { get; set; }
        public IDictionary<string, int> PeopleIndebtedTo { get; set; }

        public string PrintAmountOwedByPerson()
        {
            if (TotalAmountOwed < 0)
                return $"{this.Name} gets {Math.Abs(this.TotalAmountOwed)}";
            return $"{this.Name} has to give {this.TotalAmountOwed}";
        }
    }
}