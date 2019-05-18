using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using static System.Console;        // 네임스페이스 System의 클래스 Console의 static한 메소드는 바로 사용하겠다.
using System.Globalization;         // DateTime을 위해 추가
using System.Collections;

namespace _0511
{
    class MainApp
    {
        enum ColorCode { RED = 100, BLUE, GREEN = 100, ORANGE }
        static void Main(string[] args)
        {
            //sbyte a = -10;
            //byte b = 40;
            //WriteLine($"A = {a}, B = {b}");     // $ --> 변수보관법

            //short c = -30000;
            //ushort d = 60000;
            //WriteLine($"C = {c}, D = {d}");

            //int e = -10_000_000;            // 숫자 사이의 _는 무시된다 => 자릿수 헤아리기에 편리함
            //uint f = 300_000_000;
            //WriteLine($"E = {e}, F = {f}");

            //long g = -500_000_000_000;
            //ulong h = 2_000_000_000_000_000_000;
            //WriteLine("G = {1}, H = {0}", h, g);

            //byte bin = 0b1111_0000;
            //float ff = 3.1415_9265_3589_7932f;      // 뒤에 f없으면 double형
            //decimal dc = 3.1415_9265_3589_7932m;    // decimal엔 m 붙여주기 
            //WriteLine($"Bin = {bin}, FF = {ff}, Decimal = {dc}");

            //string str = "독도는 우리땅";
            //WriteLine(str);

            //// object타입은 모든 타입의 최상위. 모든 타입에 대해 사용가능
            //object o1 = 123;            
            //object o2 = 3.14159m;
            //object o3 = true;
            //object o4 = "문자열"; 
            //WriteLine(o1);    
            //WriteLine(o2);    
            //WriteLine(o3);    
            //WriteLine(o4);
            
            //// 형변환
            //int i = 123;
            //string s = i.ToString();
            //WriteLine(s);

            //float fff = 3.14f;
            //string s2 = fff.ToString();
            //WriteLine(s2);

            //string s3 = "123456";
            //int i2 = int.Parse(s3);     // Parse(): s3내용이 숫자가 아니었으면 오류(예외처리)
            //WriteLine(i2);

            //string s4 = "1.2345";
            //float f4 = float.Parse(s4);
            //WriteLine(f4);

            //// 상수형
            //const int MAX_INT = 2147483647;
            //const int MIN_INT = -2147483647;
            //WriteLine(MAX_INT);
            //WriteLine(MIN_INT);

            //// 열거형 
            //WriteLine((int)ColorCode.RED);      // 0 
            //WriteLine((int)ColorCode.BLUE);     // 1
            //WriteLine(ColorCode.GREEN);         // GREEN
            //WriteLine(ColorCode.ORANGE);        // ORANGE 

            //ColorCode cCode = ColorCode.RED;
            //WriteLine(cCode == ColorCode.ORANGE);    // False
            //WriteLine(cCode == ColorCode.RED);       // True


            ///// < ? 의 사용 - 첫번째 >
            //// 기본타입뒤에 ?형식
            //// 기본타입은 기본적으로 null값을 가질수 없는데, 뒤에 ?형식을 붙여서 nullable타입(null값을 가질수 있는 타입)이 되게 한다.
            //int? qa = null;
            //WriteLine(qa.HasValue);     // False        // HasValue: C#의 property속성의 값
            //WriteLine(qa != null);      // False
            //// WriteLine(qa.Value);     // error! null상태에서 Value() 사용불가

            //qa = 3;         // int? 타입은 int와 동일하게 취급하나, null값을 가질 수 있다는 점만 다르다
            //WriteLine(qa.HasValue);     // True
            //WriteLine(qa != null);      // True
            //WriteLine(qa.Value);        // 3

            //// < var 타입 >
            //// 조건: 선언과 동시에 초기화 필요 & 로컬변수로만 사용가능  
            //// 특징: 모든 타입 받을 수 있고, 컴파일이 아닌 런타임에 결정됨  ==> 약간 auto같은 타입
            //var v1 = 20;
            //WriteLine($"Type: {v1.GetType()}, Value: {v1}");

            //var v2 = 3.141516;
            //WriteLine($"Type: {v2.GetType()}, Value: {v2}");

            //var v3 = "Hello World";
            //WriteLine($"Type: {v3.GetType()}, Value: {v3}");

            //var v4 = new int[] { 10, 20, 30 };
            //WriteLine($"Type: {v4.GetType()}");
            //foreach(int v in v4)
            //    WriteLine($"Value: {v}\t");

            //// string관련 멤버함수
            //string longStr = "    This is string search sample    ";
            //WriteLine($"Index of 'search' : {longStr.IndexOf("search")}");      // IndexOf() : 위치값
            //WriteLine($"StartsWith 'This' : {longStr.StartsWith("This")}");     // StartsWith() : T/F
            //WriteLine($"StartsWith 'sample' : {longStr.StartsWith("sample")}");
            //WriteLine($"EndsWith 'This' : {longStr.EndsWith("This")}");         // EndsWith() : T/F
            //WriteLine($"EndsWith 'sample' : {longStr.EndsWith("sample")}");
            //WriteLine($"Contains 'school' : {longStr.Contains("school")}");     // Contains() : T/F
            //WriteLine($"Replace 'sample' with 'example' : {longStr.Replace("sample", "example")}");               
            //WriteLine($"Replace 'school' with 'example' : {longStr.Replace("school", "example")}");      // 없는 단어로 replace하면 변화없이 리턴
            //WriteLine(longStr);

            //WriteLine($"ToLower() : {longStr.ToLower()}");
            //WriteLine($"ToUpper() : {longStr.ToUpper()}");
            //WriteLine($"Insert() : {longStr.Insert(6, "AAA")}");
            //WriteLine($"Remove() : {longStr.Remove(6, 3)}");
            //WriteLine($"Trim() : {longStr.Trim()}");                // Trim()      : 앞/뒤공백 삭제
            //WriteLine($"TrimStart() : {longStr.TrimStart()}");      // TrimStart() : 앞공백 삭제
            //WriteLine($"TrimEnd() : {longStr.TrimEnd()}");          // TrimEnd()   : 뒤공백 삭제  

            //string splitStr = "Welcome to the C# world!";
            //WriteLine(splitStr.Substring(15, 2));           
            //WriteLine(splitStr.Substring(8));

            //string[] arr = splitStr.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            //WriteLine($"Word count: {arr.Length}");
            //foreach (string e_str in arr)
            //    WriteLine($"{e_str}");

            //// 출력형식 지정
            //// {index, +/-width} => index번째 인수를 +/-정렬하고 width간격으로 출력 => 콤마(,)는 간격지정 연산자
            //string fmt = "{0, -10} | {1, -5} | {2, 20}";          // 0번째: 왼쪽(-)정렬로 10칸, 1번째: 왼쪽(-)정렬로 5칸, 2번째: 오른쪽(+)정렬로 20칸
            //WriteLine(fmt, "Type", "Size", "Explain");              
            //WriteLine(fmt, "byte", "1", "byte 타입");

            //WriteLine(fmt, "short", "2", "short 타입");
            //WriteLine(fmt, "int", "4", "int 타입");
            //// 셋 동일
            //WriteLine(fmt, "long", "8", "long 타입");
            //WriteLine("{0, -10} | {1, -5} | {2, 20}", "long", "8", "long 타입");
            //string f1 = "long", f2 = "8", f3 = "long 타입";
            //WriteLine($"{f1, -10} | {f2, -5} | {f3:20}");


            //// {index : format/width} => index번째 인수를 format형식으로 width간격으로 출력 => (:)는 형식지정 연산자
            //WriteLine("10진수: {0:D5}", 123);         
            //WriteLine("16진수: {0:X7}", 0xFF1234);
            //WriteLine("숫자: {0:N}", 123456789);      // 1,000단위 구분기호(,) 표시
            //WriteLine("숫자: {0:N0}", 123456789);
            //WriteLine("고정소수점: {0:F}", 123.456);
            //WriteLine("고정소수점: {0:F5}", 123.456);
            //WriteLine("공학: {0:E}", 123.456789);

            //// using System.Globalization => DateTime
            //DateTime dt = DateTime.Now;
            //WriteLine($"12시간 형식: {dt:yyyy-MM-dd tt hh:mm:ss (ddd)}");     // tt : 오전/오후
            //WriteLine($"24시간 형식: {dt:yyyy-MM-dd HH:mm:ss (dddd)}");       // ddd: (토), dddd: (토요일)

            //CultureInfo ciKR = new CultureInfo("ko-KR");        
            //WriteLine();
            //WriteLine(dt.ToString("yyyy-MM-dd tt hh:mm:ss (ddd)", ciKR));     // MM : month(minutes과 구분하려고 대문자)
            //WriteLine(dt.ToString("yyyy-MM-dd HH:mm:ss (dddd)", ciKR));       // mm : minutes
            //WriteLine(dt.ToString(ciKR));

            //CultureInfo ciUS = new CultureInfo("en-US");
            //WriteLine();
            //WriteLine(dt.ToString("yyyy-MM-dd tt hh:mm:ss (ddd)", ciUS));
            //WriteLine(dt.ToString("yyyy-MM-dd HH:mm:ss (dddd)", ciUS));
            //WriteLine(dt.ToString(ciUS));

            //// 형식지정자
            //string name = "홍길동";
            //int age = 25;
            //WriteLine($"{name, -10}, {age:D3}");        // 콤마(,): 정렬과 간격, (:) : 형식지정자와 함께쓰이는 간격지정자
            //WriteLine($"{name}, {age, -10:D3}");
            //WriteLine($"{name}, {(age > 20 ? "성인" : "미성년자"), 10}");

            //// using System.Collections
            ///// < ? 의 사용 - 두번째 >
            //// 기본타입이 아닌 변수에 ? => 해당 변수가 null인지 확인하고 진행하게 하는 연산
            //// 해당 변수가 null이면 그 문장자체를 null로 리턴, 즉 아무것도 하지않음(null이 아니면 문장수행)            
            //ArrayList list = null;
            //list?.Add("C++");                   // 아무작업 X
            //list?.Add("C#");                    // 아무작업 X
            //WriteLine($"Count: {list?.Count}");     // Count:
            //WriteLine($"{list?[0]}");               // 
            //WriteLine($"{list?[1]}");               // 

            //list = new ArrayList();
            //list?.Add("C++");
            //list?.Add("C#");
            //WriteLine($"Count: {list?.Count}");     // 
            //WriteLine($"{list?[0]}");
            //WriteLine($"{list?[1]}");

            ///// < ? 의 사용 - 세번째 >
            ///* null 병합 연산자: 삼항연산자의 더 편리한 버전
            // * num ?? def => num이 null이면 ??오른쪽값, null이 아니면 ??왼쪽값 */            
            //int? num = null;
            //WriteLine($"{num ?? 0}");   // num이 null이면 0(오른쪽 기본값) null이 아니면 num값

            //num = 10;
            //WriteLine($"{num ?? 0}");

            //string qstr = null;
            //WriteLine($"{qstr ?? "Default"}");

            //qstr = "I study C#";
            //WriteLine($"{qstr ?? "Default"}");

            //// C#의 swtich문 
            //// 정수뿐 아니라 문자열타입도 가능
            //Write("요일을 입력하세요(월, 화, 수, 목, 금, 토): ");
            //string day = ReadLine();        // stdin로부터 입력받기
            //switch(day)
            //{
            //    case "일":
            //        WriteLine("Sunday");
            //        break;
            //    case "월":
            //        WriteLine("Monday");
            //        break;
            //    case "화":
            //        WriteLine("Tuesday");
            //        break;
            //    case "수":
            //        WriteLine("Wendsday");
            //        break;
            //    case "목":
            //        WriteLine("Thursday");
            //        break;
            //    case "금":
            //        WriteLine("Friday");
            //        break;
            //    case "토":
            //        WriteLine("Saturday");
            //        break;
            //    default:
            //        WriteLine("입력하신 글자는 요일이 아닙니다.");
            //        break;
            //}

            ///// Parse(), TryParse() => 타입변환
            //// int.Parse(str, ...) => str내용이 int값이 아니었으면 오류! 예외처리되면서 프로그램 죽음
            //// int.TryParse(str, ...) => str 내용이 int값이 아니었으면 false 리턴! 
            //object obj = null;
            //string pstr = ReadLine();
            //if (int.TryParse(pstr, out int int_num))
            //    obj = int_num;
            //else if (float.TryParse(pstr, out float float_num))
            //    obj = float_num;
            //else
            //    obj = pstr;

            //switch(obj)
            //{
            //    case int pi:
            //        WriteLine($"{pi}는 int 타입입니다.");
            //        break;
            //    case float pf:
            //        WriteLine($"{pf}는 int 타입입니다.");
            //        break;
            //    default:
            //        WriteLine($"{obj}는 object타입입니다.");
            //        break;
            //}

            //int[] iarr = new int[] { 0, 1, 2, 3, 4 };
            //foreach (int itoi in iarr)
            //    WriteLine(itoi);


            //// C#에서 객체는 무조건 new연산자로 만들며, 항상 heap에 생긴다. => 로컬스택에 생기지 않음
            //// Person man; => man은 로컬스택에 생기는 지역변수 객체가 아니라, Person타입의 주소를 받을 수있는 레퍼런스 객체 혹은 포인터변수 
            //// 즉, Person man = new Person; 혹은 Person man = null 로 선언해야한다. (man은 단순객체가 아니라 레퍼런스객체이므로 초기화안하면 null줘야함)
            //// C#에는 포인터가 없음

            //WriteLine($"{Calculator.Add(3, 5)}");       // Calculator::Add()는 static함수이므로 클래스명으로 접근

            ///// 메모리영역
            //// static영역: 프로그램 코드영역, static멤버영역
            //// *Main()이 static인 이유: 프로그램 시작점이므로 인스턴스에 묶이지 않아야 함(즉 인스턴스르 만들지 않아도 호출할 수 있어야 함)
            //// stack 영역: 
            //// heap 영역:

            ///// 레퍼런스(&) 변수
            //// java -> 포인터, 레퍼런스 개념 X
            //// C# -> 포인터 X, 레퍼런스 개념 O
            //int valA = 3;
            //int valB = 6;
            //Calculator.swap(ref valA, ref valB);        // C++: Calculator.swap(valA, valB); 였을 것. C#에서는 인자 넘길 때도 ref 붙여서 넘겨준다
            //WriteLine($"{valA}, {valB}");

            //Product carrot = new Product();
            //ref int ref_price = ref carrot.GetPrice();
            //int normal_price = carrot.GetPrice();

            //carrot.PrintPrice();                                // 100
            //WriteLine($"Ref Price : {ref_price}");              // 100
            //WriteLine($"Normal Price : {normal_price}");        // 100

            //ref_price = 200;        
            //carrot.PrintPrice();                                // 200
            //WriteLine($"Ref Price : {ref_price}");              // 200
            //WriteLine($"Normal Price : {normal_price}");        // 100

            ////int valC, valD;
            ////Calculator.Div(valA, valB, out valC, out valD);
            //Calculator.Div(valA, valB, out int valC, out int valD); // 위 두문장과 동일함. 즉 함수에 사용하면서 선언한게 아니라, 위에서 선언하고 사용한 것과 동일한 효과
            //WriteLine($"{valA}, {valB}, {valC}, {valD}");           // 그래서 여기에서 써도 오류가 나지 않는 것

            //////////////////////////////////////////////////////////////  0513  ///////////////////////////////////////////////////////////////////////
            //// params : 가변인자 키워드
            //int sum = Calculator.Sum(1, 2, 3, 4, 5, 6, 7, 8, 9, 10);
            //WriteLine($"Sum: {sum}");

            //// 매개변수를 지정해서 전달(순서에 상관없게 됨)
            //Product.PrintProfile(name: "김유신", phone: "010-555-6666");

            //WriteLine(Product.TolowerString("Hello"));

            //Car car1 = new Car();
            //car1.ShowStatus();
            //Car car2 = new Car("멋진차", "멋진색");
            //car2.ShowStatus();


            ///// static 멤버
            ////  static 함수: 클래스명으로 호출
            ////  static 필드: 같은 타입의 인스턴스가 모두 공유함
            //StaticField.ShowCount();        // 0
            //CA ca = new CA();
            //StaticField.ShowCount();        // 1
            //CB cb = new CB();
            //StaticField.ShowCount();        // 0

            
            //Product source = new Product();
            //source.SetPrice(10);

            //Product target = source;            // C#의 객체는 heap에 있는 레퍼런스 객체이기 때문에 직접 변경됨
            //target.SetPrice(30);                // 주소받는 것과 같은 영향 => source.price값이 30으로 직접 변경됨        
            //WriteLine($"{source.GetPrice()} => {target.GetPrice()}");

            //Product deep_s = new Product();
            //deep_s.SetPrice(40);

            //Product deep_t = deep_s.DeepCopy();
            //deep_t.SetPrice(50);
            //WriteLine($"{deep_s.GetPrice()} => {deep_t.GetPrice()}");

            //// 멤버 필드의 디폴트값 
            //// 초기화없이도 디폴트값이 존재함(쓰레기값 X)
            //CClassEx c_ex = new CClassEx();     // 멤버필드를 초기화 안해도, 숫자는 0, 그외는 null로 자동초기화됨(안정)
            //c_ex.PrintField();
            //CClassEx c_ex2 = new CClassEx(10);      // :this() 없으면 va = 0; 있으면 va = 1;
            //c_ex2.PrintField();

            /// 접근제한자
            /* public: 클래스의 내/외부 모든 곳에서 접근 가능
            *  proteted: 클래스의 외부에서 접근 불가, 파생클래스에서만 접근가능
            *  private: 클래스의 내부에서만 접근 가능(제한자 없으면 디폴트가 private)
            *  internal: 같은 어셈블리에 있는 코드에서만 public으로 접근가능
            *  protected internal : 같은 어셈블리에 있는 코드에서 protected로 접근 가능 
            */

            /// 다형성
            // 타입의 다형성
            //Parent par = new Parent("홍길동아버지");
            //par.parentF();                      

            //Child ch = new Child("홍길동");
            //ch.parentF();           // Child타입의 객체가 Parent타입의 메소드인 parentF()에 접근가능 => 상속
            //ch.childF();

            // 실타입에 맞는 함수 호출 - 다형성
            // 방법 1: 부모함수: virtual,  자식함수: override (with 레퍼런스)
            Animal ani = new Animal();
            Animal cat = new Cat();     
            Animal dog = new Dog();
            cat.Eat();              // virtual & override 사용한 다형성(with 부모타입변수에 실타입은 자식타입으로 만든 객체)
            dog.Eat();              // 부모클래스도 내가 만든거라 수정이 가능할 때 이거나, 대부분의 파생클래스에서 재정의 해야하는 경우 부모에 virtual 고쳐서 사용
           
            Cat nCat = new Cat();   // virtual없이 & new속성 사용한 다형성(with 자식타입변수에 실타입도 자식타입으로 만든 객체)
            nCat.Eat2();            // 부모를 내가 만든게 아니라서 (virtual없는 상태 그대로)수정 못할 때나, 일부 파생타입에 대해서만 재정의가 필요한 경우 자식만 new붙여서 사용


            // 타입 체크
            // 방법2: is 연산 이용 => 타입을 확인(변환 X)
            if (cat is Cat)
            {
                // 변수 cat의 실타입이 Cat이면 그때서야 (강제)형변환 => 타입이 맞기 때문에 데이터손실X
                Cat realCat = (Cat)cat;
                cat.Eat();
            }

            // 방법3: as 연산 이용(부드러운 형변환) => 부드러운 형변환 진행
            Cat cat2 = ani as Cat;
            if (cat2 != null)
            {
                // 변수 cat2의 실타입이 Cat이 아니(어서 제대로 형변환이 되지 않았으)면 null 리턴 
                // null이 아니면 Cat타입으로 변환되었음을 의미
                cat.Eat();
            }

            /// inner 클래스
            Configuration cg = new Configuration();
            cg.SetConfig("Version", "v5.0");
            cg.SetConfig("Size", "655,324 KB");

            WriteLine(cg.GetConfig("Version"));
            WriteLine(cg.GetConfig("Size"));

            cg.SetConfig("Version", "v5.1");
            WriteLine(cg.GetConfig("Version"));

            /// Partial : 컴파일 단계에서 하나의 클래스로 인식하게 함
            Partial p = new Partial();
            p.Func1();
            p.Func2();

            /// 함수의 매개변수타입에 this 속성
            WriteLine($"3^2 : {3.Square()}");       // 인스턴스명없이 메소드로만 선언된 형태 => static 메소드
            WriteLine($"3^4 : {3.Power(4)}");       // EnhancedInteger.Power(3, 4); 와 동일
            WriteLine($"2^10 : {2.Power(10)}"); 
            

            /// C#의 구조체
            // 디폴트는 값형식(클래스는 참조형식이었음) - 스택에 할당됨
            // 선언만으로 생성가능
            // Deep Copy
            // 매개변수 없는 생성자 선언 불가능
            // 상속 불가능
            Point3D pt3D;           // 선언만으로 생성가능(값형식으로 생성된 상태-스택)
            pt3D.x = 3;
            pt3D.y = 4;
            pt3D.z = 5;
            WriteLine(pt3D.ToString());

            Point3D p_pt3D = new Point3D(5, 5, 10);         // Point3D타입의 객체를 레퍼런스형식(즉, 힙에 할당)으로 생성(즉 p_pt3D는 객체의 주소값)
            WriteLine(p_pt3D.ToString());

            Point3D pp_pt3D = p_pt3D;   
            WriteLine(p_pt3D.ToString());

            /// 튜플(Tuple)
            // 데이터를 쌍으로 한꺼번에 묶기
            // 1. Unnamed Tuple 
            var tp_a = ("홍길동", 20);                       /// ("홍길동", 20) 이라는 <이름없는 튜플>을 tp_a변수가 가리키게 할당한 것.
            WriteLine($"{tp_a.Item1}, {tp_a.Item2}");       // 튜플의 디폴트 멤버명은 Item1, Item2

            // 2. Named Tuple
            var tp_b = (Name: "이순신", Age: 40);             // 멤버명을 지정하면서 선언하기 
            WriteLine($"{tp_b.Name}, {tp_b.Age}");

            // 튜플 분해
            var(nm, ag) = tp_b;             // 튜플 tp_b안의 데이터쌍을 nm과 ag으로 분해받기
            WriteLine($"{nm}, {ag}");

            tp_b = tp_a;
            WriteLine($"{tp_b.Name}, {tp_b.Age}");
            
            /// 추상(abstract) 클래스
            // AbstractBase abBase = new AbstractBase();    // error. 추상클래스타입의 객체는 생성할 수 없다. (변수는 생성가능. 아래 참조)
            AbstractBase ab = new Derived();                // 가능. 객체자체는 Derived타입이므로 가능. 변수자체는 추상타입으로 선언할 수 있다.
            ab.AbstractFuncA();
        }
    }
}

