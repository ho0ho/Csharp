using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0511
{
    /* 클래스의 속성이 static
     * => EnhancedInteger 타입의 객체는 생성할 수 없다 */
    public static class EnhancedInteger           // class의 기본속성은 internal
    {
        /* 메소드의 속성이 static 
         * => 함수외부에서 클래스명으로 호출해서 사용한다. */
        public static int Square(this int input)        // this 키워드: this붙은 인자를 이 함수의 호출객체인 것처럼 취급할 수 있다
        {                                               // 3^3 => EnhancedInteger.Square(3) => 3.Square();
            return input * input;
        }

        public static int Power(this int input, int exponent)   
        {
            int result = input;
            for (int i = 1; i < exponent; i++)
                result *= input;
            return result;
        }
    }
}
