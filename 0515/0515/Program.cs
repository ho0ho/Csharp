//
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace _0515
{
    class Program
    {
        /// 형식 매개변수 제약(시험 3문제정도)
        // 1. where T : struct      => T는 값형식의 타입만 올 수 있게 제약이 걸림
        //  예) static void CopyArray<T>(T[] src, T[] trg)
        // 2. where T : class       => T는 참조형식의 타입만 올 수 있게 제약걸림
        //
        // 3. where T : new()       => T는 매개변수가 없는 생성자가 있어야 함
        //  예) public static T CreateInstance<T>() where T : new() { return new T(); }
        // 4. where T : Base 클래스명   => Base혹은 그 파생만 올수 있음
        //  예) static void CopyArray<T>(T[] src, T[] trg) where T : MyList {...}
        //      class ChildList : MyList {...}
        //      => ChildArray<ChildList>(src, trg) 
        // 5. where T : 인터페이스명  
        //   => T는 해당 인터페이스를 구현해야함
        //   static void CopyArrya<T>(T[] src, T[] trg) where T : ILogger
        //   class ConsoleLogger : ILogger
        //   CopyArray<ConsoleLogger>(srg, trg);
        // 6. where T : U => T는 U를 상속한 클래스여야함(4번과 유사)
        //   class BaseArray<U> { 
        //       public U[] Array { get; set; }
        //       public BaseArray(int size) { Array = new U[size]; }
        //       public void CopyArray<T>(T[] src) where T : U { src.CopyTo(Array, 0); } \
        //   }

        static void Main(string[] args)
        {
            /// List
            // 하는 기능은 ArrayList와 유사한데, Generics 스타일로 사용하는 타입
            List<int> list = new List<int>();
            for (int i = 0; i < 5; i++)
                list.Add(i);

            foreach (int i in list)
                Write($"{i}");

            list.RemoveAt(2);
            foreach (int i in list)
                Write($"{i}");
            WriteLine();

            list.Insert(2, 2);
            foreach (int i in list)
                Write($"{i}");
            WriteLine();


            /// HashTable의 Generics 버전
            Dictionary<string, int> dic = new Dictionary<string, int>();
            dic["국어"] = 90;
            dic["영어"] = 85;
            dic["수학"] = 95;
            dic["물리"] = 100;
            dic["화학"] = 95;


            /// Exception => 모든 예외는 Exception 클래스를 상속받는다.
            foreach (KeyValuePair<string, int> item in dic)
                WriteLine($"{item.Key} : {item:Value}");

            int[] arr = { 1, 2, 3 };
            try
            {
                for (int i = 0; i < 5; i++)
                    WriteLine(arr[i]);
            }
            catch (IndexOutOfRangeException e)
            {
                WriteLine($"예외 발생 : {e.Message}");
            }
            WriteLine("종료");

            // 예외
            try
            {
                SimpleFunc(5);
                SimpleFunc(12);
            }
            catch (Exception e)
            {
                WriteLine(e.Message);
            }

            // 예외
            try
            {
                int? a = null;          // nullable한 변수 a에 null 할당
                int b = a ?? throw new ArgumentNullException();     // a가 null이면 new ArgumentNullException() 객체 생성해서 throw
            }
            catch (ArgumentNullException e)
            {
                WriteLine(e);
            }

            try
            {
                int[] array = new[] { 1, 2, 3 };
                int idx = 4;
                int value = array[idx >= 0 && idx < 3 ? idx : throw new IndexOutOfRangeException()];
            }
            catch (IndexOutOfRangeException e)
            {
                WriteLine(e);
            }

            // 예외 - finally
            try
            {
                Write("제수 입력: ");
                string tmp = ReadLine();
                int divisor = Convert.ToInt32(tmp);

                Write("피제수 입력: ");
                tmp = ReadLine();
                int dividend = int.Parse(tmp);

                WriteLine($"{divisor} / {dividend} = {Divide(divisor, dividend)}");
            }
            catch (FormatException e)
            {
                WriteLine("에러 : " + e.Message);
            }
            catch (DivideByZeroException e)
            {
                WriteLine("에러 : " + e.Message);
            }
            finally
            {
                WriteLine("프로그램 종료");
            }

            // Excepction에 property
            try
            {
                WriteLine($"0x{MergeARGB(255, 100, 100, 100):X8}");
                WriteLine($"0x{MergeARGB(1, 165, 190, 125):X8}");
                WriteLine($"0x{MergeARGB(0, 255, 255, 260):X8}");
            }
            catch (InvalidArgumentException e)
            {
                WriteLine(e.Message);
                WriteLine($"Argument: {e.Argument}, Range: {e.Range}");

            }

            // 에러발생에 조건걸기
            Write("Enter number between 0~10: ");
            string input = ReadLine();
            try
            {
                int num = int.Parse(input);
                if (num < 0 || num > 10)
                    throw new FilteralblException() { ErrorNo = num };
                else
                    WriteLine($"Output: {num}");
            }
            catch (FilteralblException e) when (e.ErrorNo < 0)
            {
                WriteLine("음수는 허용되지 않습니다.");
            }
            catch (FilteralblException e) when (e.ErrorNo > 10)
            {
                WriteLine("10보다 큰 수는 허용되지 않습니다.");
            }


            /// Delegate => C++의 Functor 
            Calculator cal = new Calculator();
            MyDelegate Callback;

            Callback = new MyDelegate(cal.Plus);            // cal.Plus를 대신 호출해줌(like C의 함수포인터)
            WriteLine(Callback(3, 4));

            Callback = new MyDelegate(cal.Minus);         // Callback 객체를 cal.Minus함수 사용하듯 취급 => 함수객체
            WriteLine(Callback(8, 3));

            // delegate
            int[] ar = { 3, 7, 4, 2, 9 };
            WriteLine("Ascending Sort!");
            BubbleSort<int>(ar, new Compare<int>(AscendCompare));
            for (int i = 0; i < ar.Length; i++)
                Write($"{ar[i]} ");
            WriteLine();

            WriteLine("Descending Sort!");
            BubbleSort<int>(ar, new Compare<int>(DescendCompare));
            for (int i = 0; i < ar.Length; i++)
                Write($"{ar[i]} ");
            WriteLine();

            // delegate chain
            OnlineShopping shopper = new OnlineShopping(OrderGoods) + new OnlineShopping(SpecialOrder);         // 각각 연결하고
            shopper("우리집");     // OrderGoods("우리집") + SpecialOrder("우리집") 과 동일
            
            // delegate connect
            Notifier nf = new Notifier();

            EventListener l1 = new EventListener("Listener1");
            EventListener l2 = new EventListener("Listener2");
            EventListener l3 = new EventListener("Listener3");
            nf.EventOccured = l1.SomethingHappend;      // Notify 타입끼리 연결하고 있음 => Notifier
            nf.EventOccured += l2.SomethingHappend;
            nf.EventOccured += l3.SomethingHappend;
            nf.EventOccured("You've got mail");
            WriteLine();

            nf.EventOccured -= l2.SomethingHappend;
            nf.EventOccured("Download completed.");
            WriteLine();

            Notify nf1 = new Notify(l1.SomethingHappend);
            Notify nf2 = new Notify(l2.SomethingHappend);
            nf.EventOccured = (Notify)Delegate.Combine(nf1, nf2);
            nf.EventOccured("Fire!");
            WriteLine();

            nf.EventOccured = (Notify)Delegate.Remove(nf.EventOccured, nf2);
            nf.EventOccured("Game Over!");

            // 익명 delegate 메소드 => delegate랑 연결할 함수를 한번만 임시적으로 사용할 경우 사용
            Calculate calc = delegate (int a, int b) { return a + b; };
            WriteLine($"3 + 4 = {calc(3, 4)}");

            // C#에서는 익명객체를 표현하는 데에 람다식 문법을 도입함
            Calculate calc2 = (a, b) => a + b;
            WriteLine($"3 + 4 = {calc2(3, 4)}");

            /// lamda(with delegate)
            string[] strArr = { "Microsoft ", "C# ", "Language " };
            Concatenate concat = (arEx) =>
            {
                string result = "";
                foreach (string s in arEx)
                    result += s;
                return result;
            };
            WriteLine(concat(strArr));

            /// Func 대리자(with lamda) => 리턴값이 있는(void리턴이 아닌) 함수에 대해 사용가능
            /* Func 대리자 => lamda할때 lamada식은 쉬운데 일일이 delegate선언도 해줘야해서 미리 선언시켜놓음 
             * 인자 개수 15개용 delegate까지 만들어놓았으니까 내거 갖다가 쓰렴!
             * public delegate TResult Func<out TReulst>()
             * public delegate TResult Func<in T, out TReulst>(T arg)
             * public delegate TResult Func<in T1, in T2, out TReulst>(T1 arg1, T2 arg2) 
             * ... 
             */
            Func<int> func1 = () => 10;             // Func<int> => 인자없고 리턴이 int인 함수를 lamda식으로 표현해놓은 것
            WriteLine($"func1() : {func1()}");
            Func<int, int> func2 = (x) => x * 2;
            WriteLine($"func2(4) : {func2(4)}");
            Func<double, double, double> func3 = (x, y) => x/y;          // Func<a, b, c> => 인자: 타입a, 타입b / 리턴: c타입
            WriteLine($"func3(10, 3) : {func3(10, 3):F3}");
            // Func<int, int, void> func4 = (xx, yy) => WriteLine($"{xx}, {yy}");   // error. 리턴타입이 void인 형태의 Func대리자는 없음(사용불가)

            /// Action 대리자 => 리턴타입이 void인 형태인 경우만 사용할 수 있는 대리자
            /* public delegate Action()
             * public delegate Action<in T>(T arg) 
             * public delegate Action<in T1, in T2>(T1 arg1, T2 arg2)
             * ... 
             */
            Action act1 = () => WriteLine("Action()");
            act1();

            int res = 0;
            Action<int> act2 = (x) => res = x * x;
            act2(3);
            WriteLine($"result : {res}");

            Action<int, int> act3 = (x, y) => WriteLine($"{x}, {y}");
            act3(10, 3);


            
            // 익명 delegate 메소드 => BubbleSort 예제 수정
            /* int[] ar = { 3, 7, 4, 2, 9 };  // 위에 코드 있음 */
            WriteLine("Ascending Sort!");
            BubbleSort(ar, delegate(int a, int b) 
            {
                if (a > b) return 1;
                else if (a == b) return 0;
                else return -1;
            });
            //BubbleSort(ar,)
            for (int i = 0; i < ar.Length; i++)
                Write($"{ar[i]} ");
            WriteLine();

            WriteLine("Descending Sort!");
            BubbleSort<int>(ar, delegate (int a, int b)
            {
                if (a < b) return 1;
                else if (a == b) return 0;
                else return -1;
            });
            for (int i = 0; i < ar.Length; i++)
                Write($"{ar[i]} ");
            WriteLine();

            /// Event
            MyNotifier mnf = new MyNotifier();
            mnf.DoAlarm += new EventHandler(MyHandler);

            for (int i = 1; i < 30; i++)
                mnf.Get369(i);
            //mnf.DoAlarm("이거는 안됨!");           // 외부에서 호출은 안됨(event delegate본인이 선언된 클래스 내에서만 호출가능)

            var obj = new MyEnumerator();       
            foreach (int i in obj)      // foreach 안에서는 obj.GetEnumerator()이 계속 호출됨 
                WriteLine(i);

            /// IEnumerator, IEnumerable
            MyList ml = new MyList();
            for (int i = 0; i < 5; i++)
                ml[i] = i;
            for (int i = 0; i < ml.Length; i++)
                WriteLine(ml[i]);
            foreach (int e in ml)           // foreach문 안에서는 ml.GetEnumerator()가 호출됨
                WriteLine(e);
        }

        static void SimpleFunc(int arg)
        {
            if (arg <= 10)
                WriteLine($"arg: {arg}");
            else
                throw new Exception("인자값이 10보다 큽니다.");
        }

        static int Divide(int divisor, int dividend)
        {
            try
            {
                WriteLine("Divide() 시작");
                return divisor / dividend;
            }
            catch (DivideByZeroException e)
            {
                WriteLine("Divide() 예외발생");
                throw e;
            }
            finally
            {
                WriteLine("Divide() 종료");
            }
        }

        class InvalidArgumentException : Exception
        {
            public InvalidArgumentException() { }
            public InvalidArgumentException(string message) : base(message) { }
            public object Argument { get; set; }
            public string Range { get; set; }
        }

        static uint MergeARGB(uint alpha, uint red, uint green, uint blue)
        {
            uint[] args = new uint[] { alpha, red, green, blue };
            foreach (uint arg in args)
            {
                if (arg > 255)
                    throw new InvalidArgumentException() { Argument = args, Range = "0~255" };
            }
            return ((alpha << 24 & 0xFF000000) | (red << 16 & 0x00FF0000) | (green << 8 & 0x0000FF00) | (blue & 0x000000FF));
        }

        class FilteralblException : Exception
        {
            public int ErrorNo { get; set; }
        }

        /// <summary>
        ///  delegate: C의 function pointer, C++dml Functor
        ///  * 디폴트 제한자는 internal
        /// </summary>
        /// <param name="a"> 피연산자1 </param>
        /// <param name="b"> 피연산자2 </param>
        /// <returns> </returns>
        delegate int MyDelegate(int a, int b);
        public class Calculator
        {
            public int Plus(int a, int b) { return a + b; }
            public int Minus(int a, int b) { return a - b; }
        }

        /// <summary>
        ///  함수에 종속적인 함수객체/함수포인터로 사용하기 
        ///  + Functor에 Generic 같이 쓰기 => 기본 사칙연산을 타입에 상관없이 모두 사용하기 위해 where T : IComparable<T> 사용
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        delegate int Compare<T>(T a, T b);

        static int AscendCompare<T>(T a, T b) where T : IComparable<T>      // T에는 IComoparable을 구현한 클래스만 올수 있는데, 기본타입들은 모두 구현되어있음
        {
            return a.CompareTo(b);
            //if (a > b) return 1;
            //else if (a == b) return 0;
            //else return -1;
        }

        static int DescendCompare<T>(T a, T b) where T : IComparable<T>
        {
            return (-1 * AscendCompare(a, b));
        }

        static void BubbleSort<T>(T[] dataSet, Compare<T> compare)
        {
            int i, j;
            i = j = 0;
            for (i = 0; i < dataSet.Length; i++)
            {
                for (j = 0; j < dataSet.Length - (i + 1); j++)
                {
                    if (compare(dataSet[j], dataSet[j + 1]) > 0)
                        swap<T>(dataSet[j], dataSet[j + 1]);
                }
            }
        }

        static void swap<T>(T a, T b)
        {
            T tmp;
            tmp = a;
            a = b;
        }

        delegate void OnlineShopping(string location);
        static void OrderGoods(string location)
        {
            WriteLine($"장바구니 내 물건을 {location}으로 가져다 주세요!");
        }
        static void SpecialOrder(string location)
        {
            WriteLine($"{location}에 사람이 없으면 문앞에 두시고 문자주세요!");
        }

        delegate void Notify(string message);           // new Notify(Notify와 연결할 함수); 이렇게 사용할 예정

        class Notifier { public Notify EventOccured; }

        class EventListener
        {
            private string name;
            public EventListener(string name) { this.name = name; }
            public void SomethingHappend(string message) { WriteLine($"{name}.SomethingHappend : {message}"); }
        }

        delegate int Calculate(int a, int b);


        /// <summary>
        ///  이벤트 예제
        /// </summary>
        /// <param name="message"></param>
        delegate void EventHandler(string message);

        class MyNotifier
        {
            public event EventHandler DoAlarm;          /// event키워드 붙은 DoAlarm변수 : 해당 클래스 내에서만 호출가능
            public void Get369(int num)
            {
                int tmp = num % 10;
                if (tmp != 0 && tmp % 3 == 0) { DoAlarm(string.Format($"{num}: 짝!")); }
            }
        }

        static public void MyHandler(string message) { WriteLine(message); }

        // lamda
        delegate string Concatenate(string[] args);


        /// IEnumerable의 내부
        /// 즉 IEnumerable을 구현받으면(implements) 아래 함수를 구현해줘야 한다.
        /* int GetEnumerator() 
         */
        class MyEnumerator
        {
            private int[] numbers = { 1, 2, 3, 4 };
            public IEnumerator GetEnumerator()      // 한번 실행해주고 멈춤
            {
                yield return numbers[0];
                yield return numbers[1];
                yield return numbers[2];
                yield return numbers[3];
            }
        }


        /// IEnumerator의 내부
        /// 즉 IEnumerator를 구현받으면 아래 세개의 메소드를 구현해주면 됨
        /* boolean MoveNext(): 다음요소로 이동(성공시 true)
         * void Reset(): 첫번째 위치의 앞으로 이동
         * Object Current{get;} => 프로퍼티 => 컬렉션의 현재 요소를 반환
         */        

        class MyList : IEnumerable, IEnumerator           // 이렇게 상속으로 사용해주면 GetEnumerator를 구현해야 할 필요성이 생김
        {
            private int[] ar;
            private int pos = -1;       // C++과 다르게,C#에서는 필드를 선언하면서 초기화 해줘도 되는 모양..
            public MyList() { ar = new int[3]; /*pos = -1;*/ }
            public int this[int idx] { get { return ar[idx]; } set { ar[idx] = value; } }       // [] 연산 오버로딩
            public int Length { get { return ar.Length; } }
            public object Current {  get { return ar[pos]; } }
            public void Reset() { pos = -1; }
            public bool MoveNext()
            {
                if (pos == ar.Length - 1)
                {
                    Reset();
                    return false;
                }
                pos++;
                return pos < ar.Length;
            }

            public IEnumerator GetEnumerator()
            {
                for (int i = 0; i < ar.Length; i++)
                    yield return ar[i]:
            }
                    
        } 


  
        
    }
}
