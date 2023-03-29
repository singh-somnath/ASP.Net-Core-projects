using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFirstLibrary
{
    public partial class Author
    {
        public override string ToString()
        {
            return $"-- {Name} --";
        }
    }
}
