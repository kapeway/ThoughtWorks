﻿using System;
using System.Collections.Generic;

namespace ExpensesApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Expenses Share App \n");
            var listOfTransactions = DataImportHelper.ImportListOfTransactions();
            var dictionaryOfPeopleInGroup=new Dictionary<string,Person>();

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
                personPayingTransaction.PayExpense(new Expense(transaction.Amount, personPayingTransaction,personsPaidFor));
            }

            
            foreach (var item in dictionaryOfPeopleInGroup)
            {
                Console.WriteLine(item.Value.GetExpenseShare());
            }
        }

        private static void AddNewPeopleToGroup(Dictionary<string, Person> listOfPeopleInGroup, ExpenseTransactions transaction)
        {
            foreach (var personInTransactionName in transaction.PeopleInTransaction)
            {
                if(!listOfPeopleInGroup.ContainsKey(personInTransactionName))
                    listOfPeopleInGroup.Add(personInTransactionName,new Person(personInTransactionName));
            }
        }
    }
}
