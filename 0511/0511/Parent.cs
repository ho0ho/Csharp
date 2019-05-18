using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace _0511
{
    class Parent                            // sealed class Parent {} => 클래스의 상속을 불가능하게 만듦
    {
        protected string name;
        public Parent()
        {
            name = "김철수";
            WriteLine($"{this.name}.Parent()");
        }

        public Parent(string name)
        {
            this.name = name;
            WriteLine($"{this.name}.Parent(string)");
        }

        ~Parent()
        {
            WriteLine($"{this.name}.~Parent()");
        }

        public void parentF()
        {
            WriteLine($"{this.name}.parentF()");
        }
    }

    class Child : Parent
    {
        public Child()
        {
            WriteLine($"{this.name}.Child()");
        }

        public Child(string name) : base(name)          // 본인생성자는 this(), 부모생성자는 base()
        {
            WriteLine($"{this.name}.Child(string)");
        }

        ~Child()
        {
            WriteLine($"{this.name}.~Child()");
        }

        public void childF()
        {
            WriteLine($"{this.name}.childF()");
        }
    }


}
