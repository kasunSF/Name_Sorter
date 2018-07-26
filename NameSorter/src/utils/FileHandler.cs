using System;
using System.IO;
using System.Security;
using NameSorter.src;

namespace NameSorter.utils
{
    public class FileHandler : IFileHandler
    {
        public FileHandler()
        {
        }

        /**
         *Read whole file line by line and return as an array of strings
         *
         * @return Array of strings. Each element is a line of the file
         */
        public string[] readFile(string fileName)
        {
            if (isFileExists(fileName))
            {
                return File.ReadAllLines(fileName);
            }

            return null;
        }

        /**
         *Read whole file line by line and return as an array of strings
         *
         * @return True if file is written successfully. False otherwise
         */
        public bool writeFile(string fileName, string[] content)
        {
            if (content == null)
            {
                Console.WriteLine(NameSorterLogs.ERR_NULL_CONTENT);
                return false;
            }

            long timeStamp = DateTime.Now.Ticks;
            string newFileName = fileName + NameSorterDefs.UNDERSCORE_STRING + timeStamp;

            if (renameFile(fileName, newFileName) == NameSorterDefs.FileRenameStatus.Failed)
            {
                return false;
            }

            bool isSuccess = true;

            try
            {
                File.WriteAllLines(fileName, content);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(NameSorterLogs.ERR_ARGUMENT_EXCEPTION, fileName);
                Console.WriteLine(e);
                isSuccess = false;
            }
            catch (PathTooLongException e)
            {
                Console.WriteLine(e);
                Console.WriteLine(NameSorterLogs.ERR_PATH_TOO_LONG_EXCEPTION, fileName);
                isSuccess = false;
            }
            catch (IOException e)
            {
                Console.WriteLine(e);
                Console.WriteLine(NameSorterLogs.ERR_IO_EXCEPTION, fileName);
                isSuccess = false;
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine(e);
                Console.WriteLine(NameSorterLogs.ERR_UNAUTHORIZED_ACCESS_EXCEPTION, fileName);
                isSuccess = false;
            }
            catch (NotSupportedException e)
            {
                Console.WriteLine(e);
                Console.WriteLine(NameSorterLogs.ERR_NOT_SUPPORTED_EXCEPTION, fileName);
                isSuccess = false;
            }
            catch (SecurityException e)
            {
                Console.WriteLine(e);
                Console.WriteLine(NameSorterLogs.ERR_SECURITY_EXCEPTION, fileName);
                isSuccess = false;
            }

            return isSuccess;
        }

        /**
         * Rename file if exists appending current timestamp
         *
         * @return True if rename successful. False otherwise
         */
        public NameSorterDefs.FileRenameStatus renameFile(string fileName, string newFileName)
        {
            if (isFileExists(fileName))
            {
                NameSorterDefs.FileRenameStatus status = NameSorterDefs.FileRenameStatus.Success;

                try
                {
                    File.Move(fileName, newFileName);
                    Console.WriteLine(NameSorterLogs.INF_FILE_RENAME, fileName, newFileName);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(NameSorterLogs.ERR_ARGUMENT_EXCEPTION, fileName);
                    Console.WriteLine(e);
                    status = NameSorterDefs.FileRenameStatus.Failed;
                }
                catch (PathTooLongException e)
                {
                    Console.WriteLine(e);
                    Console.WriteLine(NameSorterLogs.ERR_PATH_TOO_LONG_EXCEPTION, fileName);
                    status = NameSorterDefs.FileRenameStatus.Failed;
                }
                catch (IOException e)
                {
                    Console.WriteLine(e);
                    Console.WriteLine(NameSorterLogs.ERR_IO_EXCEPTION, fileName);
                    status = NameSorterDefs.FileRenameStatus.Failed;
                }
                catch (UnauthorizedAccessException e)
                {
                    Console.WriteLine(e);
                    Console.WriteLine(NameSorterLogs.ERR_UNAUTHORIZED_ACCESS_EXCEPTION, fileName);
                    status = NameSorterDefs.FileRenameStatus.Failed;
                }
                catch (NotSupportedException e)
                {
                    Console.WriteLine(e);
                    Console.WriteLine(NameSorterLogs.ERR_NOT_SUPPORTED_EXCEPTION, fileName);
                    status = NameSorterDefs.FileRenameStatus.Failed;
                }

                return status;
            }
            else
            {
                return NameSorterDefs.FileRenameStatus.Skipped;
            }
        }

        /**
         * Check wheter specified file is available in the local disk
         *
         * @return True if file exists. False otherwise
         */
        private bool isFileExists(string fileName)
        {
            try
            {
                FileInfo file = new FileInfo(fileName);

                if (file.Exists == false)
                {
                    string currentDir = Directory.GetCurrentDirectory();
                    Console.WriteLine(NameSorterLogs.INF_FILE_NOT_AVAILABLE, fileName, currentDir);
                    return false;
                }

                return true;
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e);
                Console.WriteLine(NameSorterLogs.ERR_ARGUMENT_EXCEPTION, fileName);
            }
            catch (PathTooLongException e)
            {
                Console.WriteLine(e);
                Console.WriteLine(NameSorterLogs.ERR_PATH_TOO_LONG_EXCEPTION, fileName);
            }

            return false;
        }
    }
}