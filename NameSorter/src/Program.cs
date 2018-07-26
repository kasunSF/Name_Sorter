using System;
using System.Configuration;
using NameSorter.src;
using NameSorter.utils;

namespace NameSorter
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputFileName = ConfigurationManager.AppSettings.Get("Input_File_Name");
            string outputFileName = ConfigurationManager.AppSettings.Get("Output_File_Name");
            
            if (args.Length == 1)
            {
                inputFileName = args[0];// Override input file name with command-line argument
            }
            
            Sorter sorter = new Sorter(inputFileName, outputFileName);
            sorter.sort();

            Console.WriteLine("\nPress any key to exit.");
            Console.ReadKey();
        }
    }
}