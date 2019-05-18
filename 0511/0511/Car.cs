using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace _0511
{
    class Car
    {
        private string model;
        private string color;


        public Car()        // constructor
        {
            model = "세단";
            color = "White";
        }

        public Car(string m, string c)
        {
            model = m;
            color = c;
        }

        public void ShowStatus()
        {
            WriteLine($"Model : {model}, Color : {color}");
        }

        ~Car()      // delete 연산없어도 Garbage Collector에 의해서 알아서 소멸자 호출함
        {           // 그렇지만 확실한 실행이 보장되지 않기 때문에 가급적 중요코드는 작성하지 않는다.
            WriteLine($"{model},{color} 소멸자 실행");
        }
    }
}
