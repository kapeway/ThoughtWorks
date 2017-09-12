using System;
using System.Collections.Generic;

namespace ExpensesApp
{
    class DataImportHelper
    {
        private static readonly string[] ProbablePeopleNames = { "Ajay", "Bapin", "Cathy", "Darwin", "Elango", "Frank", "Harry" };

        public static IList<ExpenseTransactions> ImportListOfTransactions()
        {
            var listOfImportedTransactions = new List<ExpenseTransactions> ();

            for (var i = 0; i < 100; i++)
            {
                var randomAmount = new Random();
                var randomUserPayingBill = SelectRandomPerson();
                listOfImportedTransactions.Add(item: new ExpenseTransactions{Amount = randomAmount.Next(1,10000),Name = randomUserPayingBill ,PeopleInTransaction = SelectRandomPeopleToBeInTransaction(randomUserPayingBill) });
            }
            return listOfImportedTransactions;

        }

        private static IList<string> SelectRandomPeopleToBeInTransaction(string randomUserPayingBill)
        {
            var result = new List<string>();
            var randomPersonInTransactionIterator = new Random();
            var next = randomPersonInTransactionIterator.Next(1, ProbablePeopleNames.Length - 1);

            while (result.Count < next)
            {
                for (var i = 0; i < next; i++)
                {
                    var selectRandomPerson = SelectRandomPerson();
                    if (!result.Contains(selectRandomPerson) && selectRandomPerson!= randomUserPayingBill)
                        result.Add(selectRandomPerson);
                }
            }
            return result;
        }

        private static string SelectRandomPerson()
        {
            var randomPersonIterator = new Random();
            return ProbablePeopleNames[randomPersonIterator.Next(0, ProbablePeopleNames.Length-1)];
        }
    }
}