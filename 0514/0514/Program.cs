using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace _0514
{
    class MainApp
    {
        static void Main(string[] args)
        {

            /// C# 
            /// 1. 메서드(Method)
            /// 2. 인터페이스(Interface) 
            //  /* 인터페이스 다형성 */ -> 인터페이스 타입이 오는 자리에, 해당 인터페이스를 구현하는 클래스 타입이 올 수 있다.
            //  interface 키워드 붙이고 I로 시작하는 이름갖기
            //  내부 함수의 접근제한자는 없음 => public으로 하기 위해 
            //  interface 자체의 디폴트 접근제한자는 internal. (모두에게 개방하려면 public 붙여 사용)
            //  함수의 시그니처(선언)만 작성함 -> 추상클래스의 추상메소드와 같은 모양새 
            //  추상메소드와의 차이점 => 인터페이스는 다중상속을 지원한다.
            //  *C++, C#은 클래스의 다중상속 제공 X 
            //  인터페이스에 대해서는, 선언만 있는 메소드를 (인터페이스를 implements하는) 클래스에서 "구현"한다고 말한다
            //  (추상클래스로 구현한 경우에 대해서는, : 를 이용하여 "상속받는다"라고 말한다)
            //  Q. 그렇다면 인터페이스(혹은 추상클래스)를 왜 사용하는가? 
            //  A. 메소드는 "객체의 사용법"이라고 할수 있다. 사용방법은 정해져있는데(즉, 어떤 기능을 하는 메소드가 있어야 하고 등등이 있는데)
            //     내부 구현은 이 인터페이스를 갖다쓰는(재구현하는) 타입마다 자기 스타일에 맞게 구현하도록 처리를 미루는 것 (=> 추상클래스 이해하던것과 동일)
            //     (( 사용) 추상클래스에 추상메소드를 준비해놓고 이 클래스를 상속받고, 해당 메소드를 virtual로 재정의 )) => 인터페이스 라는 문법으로 빼자
            //     그럼 추상클래스와의 차이는? 클래스는 기본적으로 생성자, 소멸자, 멤버필드 를 챙겨야 하는 오버헤드! => 인터페이스는 이런거 필요없음 굉장히 light 
            /// 3. 프로퍼티(Property)
            //  멤버 필드에 대한 gettor, settoer를 하나의 구문으로 묶는 문법
            //  접근제한자: public, gettor역할도 처리하기 위한 리턴값이 필요. 프로퍼티명은 해당 필드와 동일한 이름으로 작성(대문자)
            //  객체명.프로퍼티명 => 이 하나의 구문으로 해당 필드에 대한 gettor, settor 두가지 역할을 모두 할수 있음
            //  *자동 프로퍼티 => {get; set;} 필드선언 없앨 수 있으며
            //   인터페이스 내부에도 프로퍼티를 규정할 수 있음 => 다만, 인터페이스 내부이기 때문에 선언만 했을 뿐 다른 클래스에서 구현해줘야 사용할 수 있다.
            /// 4. 이벤트(Event)
            /// 

            /// 인터페이스 
            WriteLine("FileLogger Start");
            ClimateMoniter mon = new ClimateMoniter(new FileLogger("C:/temp/MyLog.txt"));
            mon.Start();

            WriteLine("ConsoleLogger Start");
            ClimateMoniter mon2 = new ClimateMoniter(new ConsoleLogger());
            mon2.Start();

            IFormattableLogger logger = new ConsoleLogger();
            logger.WriteLog("This is the first WriteLog method.");
            logger.WriteLog("---{0}---", "This is the first WriteLog method.");

            /// 프로퍼티 
            BirtydayInfo birth = new BirtydayInfo();
            birth.Name = "홍길동";                             // birth객체의 name필드에 대한 settor 역할
            birth.Birthday = new DateTime(1900, 5, 10);        // birth객체의 birthday필드에 대한 settor 역할  
            WriteLine($"Name: {birth.Name}, Birthday: {birth.Birthday}, Age: {birth.Age}");     // birth객체에 대한 각 필드의 gettor역할
            // => birth.Name => 함수처럼 쓰이는데 ()없고, 대문자? => 프 로 퍼 티!

            // 프로퍼티 - 객체생성하면서 프로퍼티로 초기값 설정하기
            BirtydayInfo birth2 = new BirtydayInfo() { Name = "홍홍홍", Birthday = new DateTime(1990, 1, 23) };
            WriteLine($"Name: {birth2.Name}, Birthday: {birth2.Birthday}, Age: {birth2.Age}");

            // 프로퍼티 디폴트 값 => 초기값없이 출력해보기
            BirtydayInfo birth3 = new BirtydayInfo();
            WriteLine($"Name: {birth3.Name}, Birthday: {birth3.Birthday}, Age: {birth3.Age}");


            /// Anonymous Style 
            // 한번만 사용할 타입 만들고 싶을때 사용 
            // 선언후 값 재설정 X. 오직 read-only로만 사용가능
            var anyA = new { Name = "홍길동", Age = 20 };
            WriteLine($"{anyA.Name}, {anyA.Age}");          // writeLine은 개행포함해서 출력

            var anyB = new { Subject = "수학", Score = new int[] { 90, 85, 80, 75 } };
            Write($"{anyB.Subject}, ");
            foreach (var score in anyB.Score)
                Write($"{score}, ");                          // write은 개행없이 출력
            WriteLine();

            // interface내부에서 property 속성
            NamedValued name = new NamedValued() { Name = "이름", Value = "홍길동" };
            NamedValued height = new NamedValued() { Name = "키", Value = "120cm" };
            NamedValued weight = new NamedValued() { Name = "몸무게", Value = "80kg" };

            WriteLine($"{name.Name} : {name.Value}");
            WriteLine($"{height.Name} : {height.Value}");
            WriteLine($"{weight.Name} : {weight.Value}");


            // 추상클래스의 프로퍼티가 abstract로 설정되어 있는 경우
            Product prod1 = new MyProduct() { ProductDate = new DateTime(2018, 09, 09) };
            WriteLine($"Prodcut: {prod1.SerialID}, Product Data: {prod1.ProductDate}");

            Product prod2 = new MyProduct() { ProductDate = new DateTime(2018, 03, 05) };
            WriteLine($"Prodcut: {prod2.SerialID}, Product Data: {prod2.ProductDate}");

            // string객체의 표현법
            string[] arr1 = new string[3] {"C++", "C#","JAVA"};
            //string[] arr2 = new string[] { "C++", "C#", "JAVA" };       // arr1, arr2, arr2 모두 같은 표기법
            //string[] arr3 = { "C++", "C#", "JAVA" };
            foreach (string subj in arr1)
                Write($"{subj}");
            WriteLine();

            
            /// class System.Array 의 활용
            // 메소드: BinarySearch<T>(arr, value), IndexOf(arr, value), TrueForAll(arr, functor), GetLength(dim), Resize<T>(arr, sz) 등
            // property: Rank, Length 등 
            int[] scores = new int[] { 90, 75, 80, 94, 50 };
            foreach (int score in scores)
                Write($"{score}, ");
            WriteLine();

            Array.Sort(scores);
            foreach(int score in scores)
                Write($"{score}, ");
            WriteLine();

            WriteLine($"Number of dimension: {scores.Rank}");
            WriteLine($"Binary Search : 80 is at {Array.BinarySearch<int>(scores, 80)}");
            WriteLine($"Linear Search : 94 is at {Array.IndexOf(scores, 94)}");
            WriteLine($"Everyone passed ? : {Array.TrueForAll<int>(scores, CheckPassed)}");
            WriteLine($"Old length of scored : {scores.GetLength(0)}");

            Array.Resize<int>(ref scores, 10);
            WriteLine($"New length of scores : {scores.Length}");

            foreach (int score in scores)
                Write($"{score}, ");
            WriteLine();

            
            // 2차원 배열의 표현법 
            int[,] arr2D = new int[2, 3] { { 1, 2, 3 }, { 4, 5, 6 } };
            // int [,] arr2D = { { 1, 2, 3 }, { 4, 5, 6 } }; 와 동일함 
            for (int i = 0; i < arr2D.GetLength(0); i++)
            {
                for (int j = 0; j < arr2D.GetLength(1); j++)
                    Write($"[{i}, {j}] : {arr2D[i, j]}");
                WriteLine();
            }
            WriteLine();

            // 2차원 배열 -> 메모리 아끼고자 할때 사용하는 방법 
            int[][] jagged = new int[3][];
            jagged[0] = new int[5] { 1, 2, 3, 4, 5};
            jagged[1] = new int[] { 10, 20, 30 };
            jagged[2] = new int[] { 100, 200 };

            foreach(int[] arr in jagged)
            {
                Write($"Length: {arr.Length}, ");
                foreach (int e in arr)
                    Write($"{e} "); 
            }
            WriteLine();

            int[][] jagged2 = new int[2][] { new int[] { 100, 200 }, new int[4] { 6, 7, 8, 9 } };
            foreach(int[] arr in jagged2)
            {
                Write($"Length: {arr.Length}, ");
                foreach (int e in arr)
                    Write($"{e} ");
            }
            WriteLine();


            // ArrayList 
            // 가변길이 배열을 구현하는 클래스
            ArrayList list = new ArrayList();   // 저장받은 데이터타입 명시 X => 특정데이터에 종속되는 컨테이너가 아님
            for (int i = 0; i < 5; i++)
                list.Add(i);

            foreach (object obj in list)
                Write($"{obj} ");
            WriteLine();

            list.RemoveAt(2);
            foreach(object obj in list)
                Write($"{obj} ");
            WriteLine();

            list.Insert(2, 2);
            foreach(object obj in list)
                Write($"{obj} ");
            WriteLine();

            list.Add("abc");            // Add: 끝에 추가
            list.Add("def");            // 정수 넣다가 문자열 넣어도 문제 없이 동작
            for(int i = 0; i < list.Count; i++)
                Write($"{list[i]} ");
            WriteLine();

            // Queue
            Queue q = new Queue();
            q.Enqueue(1);
            q.Enqueue(2);
            q.Enqueue(3);
            q.Enqueue(4);
            q.Enqueue(5);

            while (q.Count > 0)
                WriteLine(q.Dequeue());


            // HashTable (언어별로 Map, dictionary 등)
            Hashtable ht = new Hashtable();
            ht["하나"] = "one";
            ht["둘"] = "two";
            ht["셋"] = "three";
            ht["넷"] = "four";
            ht["다섯"] = "five";

            WriteLine(ht["하나"]);
            WriteLine(ht["둘"]);
            WriteLine(ht["셋"]);
            WriteLine(ht["넷"]);
            WriteLine(ht["다섯"]);

            // Generics 
            int[] src = { 1, 2, 3, 4, 5 };
            int[] trg = new int[src.Length];
            CopyArray<int>(src, trg);
            // CopyArray(src, trg);             // 동일. int형 매개변수가 들어갔기 때문에 CopyArra<int>가 호출되는 듯
           
            foreach (int i in trg)
                WriteLine(i);

            string[] src2 = { "C++", "C#", "Java", "Python" };
            string[] trg2 = new string[src2.Length];
            CopyArray<string>(src2, trg2);
            foreach (string str in trg2)
                WriteLine(str);

            /// 3. 인덱서
            //  변수 mylist안의 실질적인 배열데이터인 array는 외부에서 숨기는 동시에 []연산을 통해 접근은 가능하게 함 => this를 통한 인덱스 오버로딩
            MyList<string> mylist = new MyList<string>();
            for (int i = 0; i < 5; i++)     // 변수 mylist는 3개짜리 배열인 array갖고 있는데 5개 저장 시도중 => Resize걸어놨기 때문에 문제없음
                list[i] = "a" + i;
            for (int i = 0; i < mylist.Length; i++)
                WriteLine(list[i]);


        }

        interface ILogger
        {
            void WriteLog(string message);
        }

        interface IFormattableLogger : ILogger      // 인터페이스를 상속받는 인터페이스
        {
            void WriteLog(string format, params Object[] args);
        }

        class ConsoleLogger : IFormattableLogger
        {
            public void WriteLog(string message)
            {
                WriteLine($"{DateTime.Now.ToLocalTime()}, {message}");
            }

            public void WriteLog(string format, params Object[] args)
            {
                string message = String.Format(format, args);
                WriteLine($"{DateTime.Now.ToLocalTime()}, {message}");
            }
        }

        class FileLogger : ILogger
        {
            private StreamWriter writer;
            public FileLogger(string path)
            {
                writer = File.CreateText(path);
                writer.AutoFlush = true;
            }
            public void WriteLog(string message)
            {
                writer.WriteLine($"{DateTime.Now.ToLocalTime()}, {message}");
            }
        }

        class ClimateMoniter
        {
            private ILogger logger;
            public ClimateMoniter(ILogger logger)       /// 인터페이스를 구현한 클래스 == 부모를 상속받은 클래스
            {                                           /// 즉 인터페이스타입이 오는 자리에 그 인터페이스를 구현한 클래스의 타입이 올수 있다 => 다형성
                this.logger = logger;
            }
            public void Start()
            {
                while (true)
                {
                    Write("온도 입력: ");
                    string temperature = ReadLine();
                    if (temperature == "")
                        break;
                    logger.WriteLog("현재 온도 : " + temperature);
                }
            }
        }

        class BirtydayInfo 
        {
            //private string name;
            //private DateTime birthday;
            public string Name                  // 객체.Name => 똑같은 구문으로 gettor로도, settor로도 역할할 수 있음
            {
                /// 프로퍼티 => 필드에 대한 gettor, settor를 정의하는 구문!
                // 이름: 필드명(첫대문자)
                // 접근제한자: public
                // 리턴값: gettor작성하는 느낌대로!

                /// 기본적인 방법  => 필드 선언 필요함(name)
                // get { return name; }     
                // set { name = value; }            // value라는 변수는 미리 예약된 변수로 멤버변수에 대입하는 값이 자동으로 들어간다
                                                
                get; set;                  // 자동 프로퍼티: 대신 클래스 내 다른 곳에서 필드 접근하려면 이제 프로퍼티로 접근해야함    
            } = "Default Name";            // 프로퍼티 디폴트값    

            public DateTime Birthday
            {
                /* get { return birthday; } */  get;
                /* set { birthday = value; } */ set;
                }

            public int Age              // age란 필드없지만 Age라는 프로퍼티를 만들수 있음
            {                           // Age라는 의미를 나타내는 gettor만 정의할 수 있고, age라는 필드는 없으므로 age에 값을 넣는 settor작업은 구현할 수 없음
                
                get
                {
                    return new DateTime(DateTime.Now.Subtract(Birthday).Ticks).Year;
                }
                // 자동프로퍼티만이 해당 필드멤버를 자동으로 추가해줌
                // 즉 get; set; 중 
            }

            public int Ag1
            {
                get;        
                set;
            }

            public int Ag2
            {
                get;            // 읽기 전용(set;만 있을 수는 없다)
            }
            private int ag4;

            public int Ag4
            {
                get { return ag4; }         // non-자동프로퍼티
                set { ag4 = value; }
            }

        }

        interface INamedValued
        {
            string Name
            {
                get; set;
            }

             string Value
            {
                get; set;
            }
        }

        class NamedValued : INamedValued
        {
            public string Name
            {
                get; set;
            }

          public string Value
            {
                get; set;
            }
        }

        abstract class Product
        {
            private static int serial = 0;
            public string SerialID
            {
                get { return string.Format($"{serial++:d5}"); }
            }

            abstract public DateTime ProductDate            // Product타입의 객체는 멤버필드로 serial, productDate로 총 2개
            {
                get;set;
            }
        }

        class MyProduct : Product
        {
            override public DateTime ProductDate
            {
                get; set;
            }
        }

        private static bool CheckPassed(int score)
        {
            if (score >= 60) return true;
            else return false;
        }

        static void CopyArray<T>(T[] src, T[] trg)
        {
            for (int i = 0; i < src.Length; i++)
                trg[i] = src[i];
        }

        class MyList<T>
        {
            private T[] array;
            public MyList()
            {
                array = new T[3];
            }

            public T this[int idx]            /// C#의 인덱서 => []연산 오버로딩과 같은...
            {
                get { return array[idx]; }
                set {
                    if (idx >= array.Length)
                    {
                        Array.Resize<T>(ref array, idx + 1);
                        WriteLine($"Array Resized : {array.Length}");
                    }
                    array[idx] = value;
                }
            }

            public int Length {  get { return array.Length; }   }
                
        }
    }
}

