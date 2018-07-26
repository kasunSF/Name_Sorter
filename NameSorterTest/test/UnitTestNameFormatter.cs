using Microsoft.VisualStudio.TestTools.UnitTesting;
using NameSorter.utils;

namespace NameSorterTest.test
{
    [TestClass]
    public class UnitTestNameFormatter
    {
        [TestMethod]
        public void TestNameFormatter_Format_Name_Invalid_Name()
        {
            string name = "Invalid_Name";
            string expectedName = "Invalid_Name";

            string result = NameFormatter.formatName(name);

            Assert.AreEqual(expectedName, result);
        }

        [TestMethod]
        public void TestNameFormatter_Format_Name_Valid_Name_1_Given()
        {
            string name = "First_Name Surname";
            string expectedName = "Surname First_Name";

            string result = NameFormatter.formatName(name);

            Assert.AreEqual(expectedName, result);
        }

        [TestMethod]
        public void TestNameFormatter_Format_Name_Valid_Name_2_Given()
        {
            string name = "First_Name Second_Name Surname";
            string expectedName = "Surname First_Name Second_Name";

            string result = NameFormatter.formatName(name);

            Assert.AreEqual(expectedName, result);
        }

        [TestMethod]
        public void TestNameFormatter_Format_Name_Valid_Name_3_Given()
        {
            string name = "First_Name Second_Name Third_Name Surname";
            string expectedName = "Surname First_Name Second_Name Third_Name";

            string result = NameFormatter.formatName(name);

            Assert.AreEqual(expectedName, result);
        }

        [TestMethod]
        public void TestNameFormatter_Restore_Name_Invalid_Name()
        {
            string name = "Invalid_Name";
            string expectedName = "Invalid_Name";

            string result = NameFormatter.restoreName(name);

            Assert.AreEqual(expectedName, result);
        }

        [TestMethod]
        public void TestNameFormatter_Restore_Name_Valid_Name_1_Given()
        {
            string name = "Surname First_Name";
            string expectedName = "First_Name Surname";

            string result = NameFormatter.restoreName(name);

            Assert.AreEqual(expectedName, result);
        }

        [TestMethod]
        public void TestNameFormatter_Restore_Name_Valid_Name_2_Given()
        {
            string name = "Surname First_Name Second_Name";
            string expectedName = "First_Name Second_Name Surname";

            string result = NameFormatter.restoreName(name);

            Assert.AreEqual(expectedName, result);
        }

        [TestMethod]
        public void TestNameFormatter_Restore_Name_Valid_Name_3_Given()
        {
            string name = "Surname First_Name Second_Name Third_Name";
            string expectedName = "First_Name Second_Name Third_Name Surname";

            string result = NameFormatter.restoreName(name);

            Assert.AreEqual(expectedName, result);
        }
    }
}
