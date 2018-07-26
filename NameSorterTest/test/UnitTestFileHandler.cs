using System;
using System.IO;
using System.Linq;
using NameSorter;
using NameSorter.utils;
using NUnit.Framework;

namespace NameSorterTest.test
{
    [TestFixture]
    public class UnitTestFileHandler
    {
        [Test]
        public void TestFileHandler_readFile_Non_Existing_File()
        {
            string fileName = "TestFile.txt";

            FileHandler fileHandler = new FileHandler();
            Assert.AreEqual(null, fileHandler.readFile(fileName));
        }

        [Test]
        public void TestFileHandler_readFile_Existing_File()
        {
            string fileName = "TestFile.txt";
            string content = "This is a test";
            File.WriteAllText(fileName, content);

            FileHandler fileHandler = new FileHandler();
            string[] result = fileHandler.readFile(fileName);
            File.Delete(fileName);

            Assert.AreNotEqual(null, result);
            Assert.AreEqual(1, result.Length);
            Assert.AreEqual(content, result[0]);
        }

        [Test]
        public void TestFileHandler_writeFile_Null_Content()
        {
            string fileName = "TestFile.txt";
            string[] content = null;

            FileHandler fileHandler = new FileHandler();
            bool result = fileHandler.writeFile(fileName, content);
            Assert.AreEqual(false, result);
        }

        [Test]
        public void TestFileHandler_writeFile_Not_Null_Content_Success()
        {
            string fileName = "TestFile.txt";
            string[] content = {"Test line 1", "Test line 2"};

            FileHandler fileHandler = new FileHandler();
            bool result = fileHandler.writeFile(fileName, content);
            File.Delete(fileName);

            Assert.AreEqual(true, result);
        }

        [Test]
        public void TestFileHandler_writeFile_Not_Null_Content_Fail()
        {
            string fileName = "TestFile1.txt";
            string[] content = {"Test line 1", "Test line 2"};
            File.WriteAllLines(fileName, content);

            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            string randomString =
                new string(Enumerable.Repeat(chars, 8795).Select(s => s[random.Next(s.Length)]).ToArray());

            FileHandler fileHandler = new FileHandler();
            bool result = fileHandler.writeFile(fileName + randomString, content);
            File.Delete(fileName);

            Assert.AreEqual(false, result);
        }

        [Test]
        public void TestFileHandler_renameFile_Non_Existing_File()
        {
            string fileName = "TestFile.txt";
            string newFileName = "TestFile2.txt";

            FileHandler fileHandler = new FileHandler();
            Assert.AreEqual(NameSorterDefs.FileRenameStatus.Skipped, fileHandler.renameFile(fileName, newFileName));
        }

        [Test]
        public void TestFileHandler_renameFile_Existing_File()
        {
            string fileName = "TestFile.txt";
            string content = "This is a test";
            string newFileName = "TestFile2.txt";
            File.WriteAllText(fileName, content);

            FileHandler fileHandler = new FileHandler();
            NameSorterDefs.FileRenameStatus status = fileHandler.renameFile(fileName, newFileName);
            File.Delete(newFileName);

            Assert.AreEqual(NameSorterDefs.FileRenameStatus.Success, status);
        }

        [Test]
        public void TestFileHandler_renameFile_Invalid_Output_File()
        {
            string fileName = "TestFile.txt";
            string content = "This is a test";
            string newFileName = "Test///@#/$/,/./<>)(*&^%$#@!~!@%File.txt";
            File.WriteAllText(fileName, content);

            FileHandler fileHandler = new FileHandler();
            NameSorterDefs.FileRenameStatus status = fileHandler.renameFile(fileName, newFileName);
            File.Delete(fileName);

            Assert.AreEqual(NameSorterDefs.FileRenameStatus.Failed, status);
        }

        [Test]
        public void TestFileHandler_renameFile_Invalid_Input_File()
        {
            string fileName = "Test@#$,.<>)(*&^%$#@!~!@%File.txt";
            string newFileName = "TestFile2.txt";

            FileHandler fileHandler = new FileHandler();
            Assert.AreEqual(NameSorterDefs.FileRenameStatus.Skipped, fileHandler.renameFile(fileName, newFileName));
        }
    }
}
