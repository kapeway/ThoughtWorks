using System;
using System.Collections.Generic;

namespace ExpensesApp
{
    class ExpenseShareAppHelper
    {
        public static void UpdateLedgerOfPersonsInvolvedInTransaction(Dictionary<string, Person> dictionaryOfPersons, ExpenseTransactions transaction)
        {
            var personToCredit = dictionaryOfPersons[transaction.Name];
            var perPersonShareInTransaction = transaction.Amount / transaction.PeopleInTransaction.Count;

            if (personToCredit.Name != transaction.Name)
                personToCredit.Credits.UpdateLedger(transaction.Name, transaction.Amount - perPersonShareInTransaction);
            else
                personToCredit.Credits.UpdateLedger(transaction.Name, transaction.Amount);

            foreach (var nameOfPeopleInTransaction in transaction.PeopleInTransaction)
            {
                var personToDebit = dictionaryOfPersons[nameOfPeopleInTransaction];
                personToDebit.Debits.UpdateLedger(transaction.Name, perPersonShareInTransaction);
                if(personToCredit.Name!= transaction.Name)
                    personToCredit.Debits.UpdateLedger(nameOfPeopleInTransaction, perPersonShareInTransaction);
            }
        }

        public static void PrintTransactionDetailsForDebugPurpose(Dictionary<string, Person> dictionaryOfPersons, ExpenseTransactions transaction)
        {
            var personPayingTransaction = dictionaryOfPersons[transaction.Name];
            Console.WriteLine($"{personPayingTransaction.Name} spent  {transaction.Amount} for");
            foreach (var personInTransaction in transaction.PeopleInTransaction)
            {
                var person = dictionaryOfPersons[personInTransaction];
                Console.WriteLine(person.Name);
            }
        }

        public static void AddNewPersonToGroupFromTransaction(Dictionary<string, Person> dictionaryOfPersonInGroup, ExpenseTransactions transaction)
        {
            if (!dictionaryOfPersonInGroup.ContainsKey(transaction.Name))
                dictionaryOfPersonInGroup.Add(transaction.Name, new Person(transaction.Name));

            foreach (var personInTransactionName in transaction.PeopleInTransaction)
            {
                if(!dictionaryOfPersonInGroup.ContainsKey(personInTransactionName))
                    dictionaryOfPersonInGroup.Add(personInTransactionName,new Person(personInTransactionName));
            }
        }
    }
}