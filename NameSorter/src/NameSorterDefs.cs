namespace NameSorter
{
    public class NameSorterDefs
    {
        public const char SPACE_CHARACTER = ' ';

        public const int ARRAY_BEGIN = 0;
        public const int ARRAY_END_OFFSET = 1; //Difference between array.Length and index of last element of the array
        public const int MIN_NAME_COUNT = 2;

        public const string SPACE_STRING = " ";
        public const string UNDERSCORE_STRING = "_";
        public const string EMPTY_STRING = "";

        public enum FileRenameStatus
        {
            Success,
            Failed,
            Skipped
        }
    }
}