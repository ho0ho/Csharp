using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace _0511
{
    class Calculator
    {
        public static int Add(int a, int b)
        {
            return a + b;
        }

        public static int Sub(int a, int b)
        {
            return a - b;
        }

        public static void swap(ref int a, ref int b)       
        {
            int tmp = a;
            a = b;
            b = tmp;
        }

        public static void Div(int a, int b, out int q, out int rem)
        {
            q = a / b;
            rem = a % b;
        }

       public static int Sum(params int[] args) // 가변인자받는 배열 params 
        {
            int sum = 0;
            for(int i = 0; i < args.Length; i++)
            {
                if (i > 0) Write(", ");
                Write(args[i]);
                sum += args[i];
            }

            WriteLine();
            return sum;
        }
    }
}
