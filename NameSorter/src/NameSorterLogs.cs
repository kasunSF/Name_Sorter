namespace NameSorter.src
{
    class NameSorterLogs
    {
        public const string ERR_ARGUMENT_EXCEPTION = "[ERROR] File name[{0}] is empty/null/contains invalid characters";
        public const string ERR_PATH_TOO_LONG_EXCEPTION = "[ERROR] File name[{0}] is too long";
        public const string ERR_IO_EXCEPTION = "[ERROR] An I/O error occurred while opening the file[{0}]";

        public const string ERR_UNAUTHORIZED_ACCESS_EXCEPTION =
            "[ERROR] Cannot create file[{0}]. Operation is not supported";

        public const string ERR_NOT_SUPPORTED_EXCEPTION = "[ERROR] File name[{0}] is in an invalid format";
        public const string ERR_SECURITY_EXCEPTION = "[ERROR] Cannot create file[{0}]. Permission denied";
        public const string ERR_FILE_UNAVAILABLE = "[ERROR] Input file is unavailable";
        public const string ERR_INVALID_NAME = "[ERROR] Name must have at least first name and surname";
        public const string ERR_NULL_CONTENT = "[ERROR] Content cannot be null";


        public const string INF_FILE_NOT_AVAILABLE =
            "[INFO] File path[{0}] is not available in the current directory[{1}]";

        public const string INF_FILE_RENAME = "[INFO] File[{0}] renamed as [{1}]";
    }
}