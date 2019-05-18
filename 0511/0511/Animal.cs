using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace _0511
{
    class Animal
    {
        protected string myType;
        public Animal()
        {
            myType = "Animal";
        }

        /* virtual & override 사용한 메소드 다형성 */
        virtual public void Eat()       
        {
            WriteLine("Animal eat");
        }

        /* new를 사용한 메소드 다형성 */
        public void Eat2()
        {
            WriteLine("Animal eat2");
        }

        public string GetType()
        {
            return myType;
        }
    }

    class Dog : Animal
    {
        public Dog() : base()
        {
            myType += " Dog";
        }

        /* virtual & override 사용한 메소드 다형성 */
        override public void Eat()      // C++과는 달리, 부모에는 virtual, 자식에게도 override 붙여야 함
        {
            WriteLine("Dog eat");
        }

        /* new를 사용한 메소드 다형성  => 부모를 수정할 수 없을 때 사용(= 부모의 메소드에 virtual 못 넣으므로) */
        public new void Eat2()
        {
            WriteLine("Dog eat2");
        }
    }

    class Cat : Animal
    {
        public Cat() : base()
        {
            myType += " Cat";
        }

        /* virtual & override 사용한 메소드 다형성 */
        override public void Eat()          // 하나의 base에 대한 대부분의 derived가 재정의(부모것 숨겨짐)해야할 때 사용
        {
            WriteLine("Cat eat");
        }

        /* new를 사용한 메소드 다형성  => 부모를 수정할 수 없을 때 사용(= 부모의 메소드에 virtual 못 넣으므로) */
        public new void Eat2()               // 일부의 derived만 재정의하려할 때 사용 
        {
            WriteLine("Cat eat2");
        }
    }
}
