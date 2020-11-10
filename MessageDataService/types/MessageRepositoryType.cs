using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService
{
    [Flags]
    public enum MessageRepositoryType
    {
        None = 0,
        Console = 1,
        Database = 2,
        File = 4
    }
}
