using System;
using System.Diagnostics;
using NameSorter.src;

namespace NameSorter.utils
{
    public class NameFormatter
    {
        /**
         * Extract last word of the name and prepend it to the name
         * If input is "Name1 Name2", this will return "Name2 Name1"
         *
         * @param name Name to be formatted
         * @return Formatted name.
         */
        public static string formatName(string name)
        {
            string[] names = name.Split(NameSorterDefs.SPACE_CHARACTER);

            if (names.Length < NameSorterDefs.MIN_NAME_COUNT) //User error
            {
                Console.WriteLine(NameSorterLogs.ERR_INVALID_NAME);
                return name;
            }

            string surname = names[names.Length - NameSorterDefs.ARRAY_END_OFFSET];
            names[names.Length - NameSorterDefs.ARRAY_END_OFFSET] =
                NameSorterDefs.EMPTY_STRING; //Remove last part of the name

            string formattedName =
                (surname + NameSorterDefs.SPACE_CHARACTER + String.Join(NameSorterDefs.SPACE_STRING, names)).Trim();

            return formattedName;
        }

        /**
         * Extract first word of the name and append it to the name
         * If input is "Name2 Name1", this will return "Name1 Name2"
         *
         * @param name Name to be restored
         * @return Restored name.
         */
        public static string restoreName(string name)
        {
            string[] names = name.Split(NameSorterDefs.SPACE_CHARACTER);

            if (names.Length < NameSorterDefs.MIN_NAME_COUNT)
            {
                Console.WriteLine(NameSorterLogs.ERR_INVALID_NAME);
                return name;
            }

            string surname = names[NameSorterDefs.ARRAY_BEGIN];
            names[NameSorterDefs.ARRAY_BEGIN] = NameSorterDefs.EMPTY_STRING; //Remove first part of the name

            string restoredName =
                (String.Join(NameSorterDefs.SPACE_STRING, names) + NameSorterDefs.SPACE_CHARACTER + surname).Trim();

            return restoredName;
        }

        //Hidden constructor of static class
        private NameFormatter()
        {
        }
    }
}