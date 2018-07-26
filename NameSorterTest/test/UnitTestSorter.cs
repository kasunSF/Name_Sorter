using System.IO;
using NameSorter;
using NameSorter.utils;
using NUnit.Framework;

namespace NameSorterTest.test
{
    [TestFixture]
    public class UnitTestSorter
    {
        [Test]
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