using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.VenuGopal.CSharp.Random
{
    public class DelegatesHelpers
    {
        //Delegate Definition One
        public delegate void WriteDateTimeCallback(object state);

        //Method for delegate
        public void WriteDateTimeMethodOne(object state)
        {
            Console.WriteLine("My First Callback from the Execution "+ DateTime.Now);
        }

        //Method for delegate Two
        public void WriteDateTimeMethodTwo(object state)
        {
            Console.WriteLine("My First Callback from the Execution " + DateTime.Now);
        }
    }
}
