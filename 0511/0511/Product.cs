using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static System.Console;

namespace _0511
{
    class Product
    {
        private int price = 100;
        public ref int GetPrice() { return ref price; }

        public void SetPrice(int price) { this.price = price; }

        public void PrintPrice()
        {
            WriteLine($"Price: {price}");
        }
        public static void PrintProfile(string name, string phone = "")
        {
            WriteLine($"Name = {name}, Phone = {phone}");
        }

        public static string TolowerString(string str)
        {
            var arr = str.ToCharArray();
            for (int i = 0; i < arr.Length; i++)
                arr[i] = ToLowerChar(i);

            // local method (함수안에 함수선언이 가능 => 부모함수의 변수에 접근할수 있다)
            char ToLowerChar(int i)
            {
                if (arr[i] < 65 || arr[i] > 90)
                    return arr[i];      // 그대로 리턴
                else return (char)(arr[i] + 32);
            }
            return new string(arr);
        }

        public Product DeepCopy()
        {
            Product cp = new Product();
            cp.SetPrice(price);
            return cp;  // cp의 레퍼런스 리턴
        }
    }
}
