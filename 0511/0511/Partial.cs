using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace _0511
{
    partial class Partial       // Partial 키워드 : 컴파일시점에 하나로 합쳐서 컴파일
    {
        private int a;
        public void Func1()
        {
            WriteLine($"Func1(), {a}");
        }
    }

    partial class Partial
    {
        public void Func2()
        {
            WriteLine($"Func2(), {a}");
        }
    }
}
