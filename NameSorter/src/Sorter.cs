using System;
using NameSorter.src;
using NameSorter.utils;

namespace NameSorter
{
    public class Sorter
    {
        /**
         *Constructor of Sorter class
         *
         * @param inputFileName Name of the input file containing names
         * @param outputFileName Name of the output file where result should be written
         */
        public Sorter(string inputFileName, string outputFileName)
        {
            _inputFileName = inputFileName;
            _outputFileName = outputFileName;
            _fileHandler = new FileHandler();
        }

        /**
         * Sort names in the input file
         */
        public void sort()
        {
            string[] input = readFile();

            if (input == null)
            {
                return;
            }

            string[] formattedNames = formatNames(input);

            Array.Sort(formattedNames);

            string[] restoredNames = restoreNames(formattedNames);
            printSortedArray(restoredNames);
            persistSortedArray(restoredNames);
        }

        /**
         * Read file from local disck and retun result
         */
        private string[] readFile()
        {
            string[] input = _fileHandler.readFile(_inputFileName);

            if (input == null)
            {
                Console.WriteLine(NameSorterLogs.ERR_FILE_UNAVAILABLE);
            }

            return input;
        }

        /**
         * Format names so that surname will appear at the beginning
         *
         * @return File content as an array of strings
         */
        private string[] formatNames(string[] input)
        {
            string[] formattedNames = new string[input.Length];

            for (int i = NameSorterDefs.ARRAY_BEGIN; i < input.Length; ++i)
            {
                //Console.WriteLine("[DEBUG] Input name " + (i + 1) + ": " + input[i]);
                formattedNames[i] = NameFormatter.formatName(input[i]);
            }

            return formattedNames;
        }

        /**
         * Restore formatted names to original value
         *
         * @return Restored names as an array of strings
         */
        private string[] restoreNames(string[] formattedInput)
        {
            string[] restoredNames = new string[formattedInput.Length];

            for (int i = NameSorterDefs.ARRAY_BEGIN; i < formattedInput.Length; ++i)
            {
                restoredNames[i] = NameFormatter.restoreName(formattedInput[i]);
            }

            return restoredNames;
        }

        /**
         * Print sorted array on stdout
         */
        private void printSortedArray(string[] sortedArray)
        {
            foreach (string name in sortedArray)
            {
                Console.WriteLine(name);
            }
        }

        /**
         * Write sorted names in to the output file
         */
        private void persistSortedArray(string[] sortedArray)
        {
            _fileHandler.writeFile(_outputFileName, sortedArray);
        }

        private readonly string _inputFileName;
        private readonly string _outputFileName;
        private readonly FileHandler _fileHandler;
    }
}