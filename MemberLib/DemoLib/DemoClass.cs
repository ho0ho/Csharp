using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace DemoLib
{
    public class DemoClass
    {
        public void Foo() { WriteLine("Foo 1"); }
        // C:\Windows\Microsoft.NET\assembly\GAC_MSIL\DemoLib\v4.0_1.0.0.0__4588da40f4b24e02 밑에 있는 것 확인할 수 있음
        // => 글로벌 어셈블리 캐쉬(GAC)로 배포한 것 확인
    }
}
