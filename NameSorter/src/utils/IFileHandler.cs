namespace NameSorter.utils
{
    interface IFileHandler
    {
        string[] readFile(string fileName);
        bool writeFile(string fileName, string[] content);
        NameSorterDefs.FileRenameStatus renameFile(string fileName, string newFileName);
    }
}