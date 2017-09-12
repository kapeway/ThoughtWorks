using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ExpensesApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Expenses Share App \n");
            var listOfTransactions = DataImportHelper.ImportListOfTransactions();
            var dictionaryOfPeopleInGroup=new Dictionary<string,Person>();
            var stopWatch=new Stopwatch();
            stopWatch.Start();
            foreach (var transaction in listOfTransactions)
            {
                AddNewPeopleToGroup(dictionaryOfPeopleInGroup,transaction);
                var personPayingTransaction = dictionaryOfPeopleInGroup[transaction.Name];
                var personsPaidFor = new List<Person> ();
                Console.WriteLine($"{personPayingTransaction.Name} spent  {transaction.Amount} for");
                foreach (var personInTransaction in transaction.PeopleInTransaction)
                {
                    var person = dictionaryOfPeopleInGroup[personInTransaction];
                    personsPaidFor.Add(person);
                    Console.WriteLine(person.Name);
                }
                var expense = new Expense(transaction.Amount, personPayingTransaction,personsPaidFor);
                expense.Process();
            }

            Console.WriteLine("#***************************************#  RESULT  #****************************************#\n");

            foreach (var item in dictionaryOfPeopleInGroup)
            {
                Console.WriteLine(item.Value.PrintAmountOwedByPerson());
                Console.WriteLine(item.Value.PrintAmountOwedByPersonToOtherPerson());
            }
            stopWatch.Stop();
            Console.WriteLine($"The computation of each persons share took {stopWatch.Elapsed.TotalSeconds}");
        }

        private static void AddNewPeopleToGroup(Dictionary<string, Person> listOfPeopleInGroup, ExpenseTransactions transaction)
        {
            if(!listOfPeopleInGroup.ContainsKey(transaction.Name))
                listOfPeopleInGroup.Add(transaction.Name,new Person(transaction.Name));
            foreach (var personInTransactionName in transaction.PeopleInTransaction)
            {
                if(!listOfPeopleInGroup.ContainsKey(personInTransactionName))
                    listOfPeopleInGroup.Add(personInTransactionName,new Person(personInTransactionName));
            }
        }
    }
}
