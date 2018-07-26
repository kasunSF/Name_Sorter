using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NameSorter;
using NameSorter.utils;

namespace NameSorterTest.test
{
    [TestClass]
    public class UnitTestSorter
    {
        [TestMethod]
        public void TestSorter()
        {
            string inputFile = "InputFile.txt";
            string outputFile = "OutputFile.txt";

            string[] names =
            {
                "Janet Parsons",
                "Vaughn Lewis",
                "Adonis Julius Archer",
                "Shelby Nathan Yoder",
                "Marin Alvarez"
            };
            string[] expected =
            {
                "Marin Alvarez",
                "Adonis Julius Archer",
                "Vaughn Lewis",
                "Janet Parsons",
                "Shelby Nathan Yoder"
            };

            File.WriteAllLines(inputFile, names);

            Sorter sorter = new Sorter(inputFile, outputFile);
            sorter.sort();

            string[] sortedNames = File.ReadAllLines(outputFile);
            File.Delete(inputFile);
            File.Delete(outputFile);

            CollectionAssert.AreEqual(expected, sortedNames);
        }
    }
}