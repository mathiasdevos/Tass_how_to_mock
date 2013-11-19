using System;
using System.IO;
using MockingExample.Exceptions;

namespace MockingExample
{
    public class ParseReader
    {
        public string Parse(TextReader reader, int skipHeaderLines)
        {
            for(int i = 0; i < skipHeaderLines; i++)
                reader.ReadLine(); // throws OutOfMemoryException, IOException

            string line = reader.ReadLine(); // throws OutOfMemoryException, IOException

            if (line == null)
                throw new FileToShortException();

            return line;
        }
    }
}
