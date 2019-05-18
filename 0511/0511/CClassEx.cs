using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace _0511
{
    class CClassEx
    {
        private int va, vb;
        public CClassEx()
        {
            this.va = 1;
        }

        public CClassEx(int vb) : this()     // C#은 초기화섹션에 자기(this)혹은 부모(base)의 생성자외엔 지원 X
        {
            this.vb = vb;
        }

        public void PrintField()
        {
            WriteLine($"{va}, {vb}");
        }
    }
}
