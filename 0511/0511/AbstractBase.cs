using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace _0511
{
    abstract class AbstractBase                 // AvstractBase 타입의 객체 생성할 수 없음 -> 추상클래스 
    {
        protected void PrivateFuncA()
        {
            WriteLine("Base.Private()");
        }

        public void PublicFuncA()
        {
            WriteLine("Base.Public()");
        }
        public abstract void AbstractFuncA();           // 추상멤버가 하나이상있으면 추상클래스로 정의해야한다.
    }

    class Derived : AbstractBase
    {
        public override void AbstractFuncA()            // Base의 PrivateFuncA(), PublicFuncA()은 상속받은 그대로 사용하고
        {                                               // AbstractFuncA()은 abstract이므로 재정의해서 사용함
            WriteLine("Derived.AbstractFuncA()");
        }


    }
}
