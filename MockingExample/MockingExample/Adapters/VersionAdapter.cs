using System;
using MockingExample.Interfaces;

namespace MockingExample.Adapters
{
    public class VersionAdapter: IVersion
    {
        private Version version;

        public VersionAdapter(Version version)
        {
            this.version = version;
        }

        public int CompareTo(IVersion version)
        {
            return this.version.CompareTo(version);
        }
    }
}
