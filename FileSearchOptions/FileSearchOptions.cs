namespace FileSearchOptions
{
    using System.Text.RegularExpressions;
    public struct FileSearchOptions
    {
        public Regex? regText;
        public DirectoryInfo dirInfo;
        public Regex regMask;
        public CancellationToken canTok;
    }
}
