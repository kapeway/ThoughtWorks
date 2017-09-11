using System;
using System.Collections.Generic;

namespace ExpensesApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Expenses Share App \n");
            var listOfTransactions = DataImportHelper.ImportListOfTransactions();
            var dictionaryOfPersons=new Dictionary<string,Person>();

            foreach (var transaction in listOfTransactions)
            {
                ExpenseShareAppHelper.AddNewPersonToGroupFromTransaction(dictionaryOfPersons,transaction);
                ExpenseShareAppHelper.PrintTransactionDetailsForDebugPurpose(dictionaryOfPersons, transaction);
                ExpenseShareAppHelper.UpdateLedgerOfPersonsInvolvedInTransaction(dictionaryOfPersons, transaction);
            }

            Console.WriteLine("#***************************************#  RESULT  #****************************************#\n");

            foreach (var item in dictionaryOfPersons)
            {
                Console.WriteLine(item.Value.PrintTotalAmountDueOrOwed());
                Console.WriteLine(item.Value.PrintAmountOwedOrDueByPerPerson());
            }
        }
    }
}
