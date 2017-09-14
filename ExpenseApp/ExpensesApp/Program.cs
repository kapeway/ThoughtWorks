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
            Console.WriteLine("#***************************************#  GENERATING INPUT  #****************************************#\n");

            var listOfTransactions = DataImportHelper.ImportListOfTransactions();
            var dictionaryOfPersons=new Dictionary<string,Person>();

            var stopWatch=new Stopwatch();
            stopWatch.Start();
            foreach (var transaction in listOfTransactions)
            {
                ExpenseShareAppHelper.AddNewPersonToGroupFromTransaction(dictionaryOfPersons,transaction);
                //ExpenseShareAppHelper.PrintTransactionDetailsForDebugPurpose(dictionaryOfPersons, transaction);
                ExpenseShareAppHelper.UpdateLedgerOfPersonsInvolvedInTransaction(dictionaryOfPersons, transaction);
            }

            Console.WriteLine("#***************************************#  RESULT  #****************************************#\n");

            foreach (var item in dictionaryOfPersons)
            {
                Console.WriteLine(item.Value.PrintTotalAmountDueOrOwed());
                Console.WriteLine(item.Value.PrintAmountOwedOrDueByPerPerson());
            }
            stopWatch.Stop();
            Console.WriteLine($"The computation of each persons share took {stopWatch.Elapsed.TotalSeconds} for {listOfTransactions.Count} Transactions");
            var currentProcess = Process.GetCurrentProcess();
            Console.WriteLine($"Total Memory Used for {listOfTransactions.Count} Transactions is :: {currentProcess.WorkingSet64}");

        }
    }
}
