using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace _0511
{
    class StaticField
    {
        public static int count = 0;
        public static void ShowCount()
        {
            WriteLine($"StaticField.count : {count}");
        }
        
    }

    class CA
    { 

        public CA()
        {
            StaticField.count++;
        }
    }

    class CB
    {
        public CB()
        {
            StaticField.count--;
        }
    }
}
