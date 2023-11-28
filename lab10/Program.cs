using Lab10;
using System;
using System.Diagnostics;
using static Lab10.FilterParts;
using static Lab10.SortParts;


namespace lab10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string jsonPath = "storage_threads.json";
            Storage storage = new Storage();
            TaskManager.GeneratePartsInStorage(storage, jsonPath, 1000000, 4);

            
            //Console.WriteLine("-----------------------\nSort by Ascending Cost:\n");
            //TaskManager.ParallelSort(storage, CompareByAscendingCost);
            //Console.WriteLine(storage);


        }
    }
}