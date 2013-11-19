using System;
using System.IO;
using MockingExample.Interfaces;
using MockingExample.Adapters;

namespace MockingExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "";
            TextReader reader;
            string onlineVersionString;
            IVersion localVersion, onlineVersion;
            bool isNewVersionAvailable;

            using (reader = new StreamReader(path))
            {
                ParseReader parser = new ParseReader();

                try
                {
                    onlineVersionString = parser.Parse(reader, 3); // throws OutOfMemoryException, IOException, FileToShortException
                    localVersion = new VersionAdapter(new Version("1.2.1"));
                    onlineVersion = new VersionAdapter(new Version(onlineVersionString)); // throws ArgumentException, ArgumentNullException, ArgumentOutOfRangeException, FormatException, OverflowException

                    CompareVersions comp = new CompareVersions();
                    comp.Compare(localVersion, onlineVersion);
                    isNewVersionAvailable = comp.IsNewerVersionAvailable;
                }
                catch (Exception e)
                {

                }
            }
        }
    }
}
