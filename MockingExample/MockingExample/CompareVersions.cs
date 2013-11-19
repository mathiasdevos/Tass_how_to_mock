using System;
using MockingExample.Interfaces;
using MockingExample.Exceptions;

namespace MockingExample
{
    public class CompareVersions
    {
        public bool IsNewerVersionAvailable { get; private set; }
        public void Compare(IVersion localVersion, IVersion onlineVersion)
        {
            int result = localVersion.CompareTo(onlineVersion);

            if(result < 0)
                IsNewerVersionAvailable = true;
            else if(result == 0)
                IsNewerVersionAvailable = false;
            else
            {
                throw new LocalVersionNewerException();
            }
        }
    }
}
