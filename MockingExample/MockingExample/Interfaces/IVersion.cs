using System;
using System.Collections.Generic;
using System.Text;

namespace MockingExample.Interfaces
{
    public interface IVersion
    {
        int CompareTo(IVersion version);
    }
}
