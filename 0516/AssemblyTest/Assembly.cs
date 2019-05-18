using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using MemberLib;        // 내가 만든 어셈블리

namespace AssemblyTest
{
    class Assembly
    {
        static void Main(string[] args)
        {
            Member mb = new Member("홍길동", "대한민국");
            WriteLine($"이름: {mb.Name}, 주소: {mb.Addr}");
        }
    }
}
