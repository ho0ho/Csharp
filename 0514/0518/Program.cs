using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using static System.Console;

namespace _0518
{
    class LINQ
    {
        static void Main(string[] args)
        {
            ///  LINQ
            /* Language INtegrated Query
             * from [범위변수query variable] int [원본데이터data source] 절부터 시작
             * (원본데이터는 IEnumerable<t> 인터페이스를ㄹ 상속하는 형식이어야 한다)
             * where [조건]
             * orderby [정렬기준] [ascending | descending]
             * select [추출데이터]
             */
            int[] numbers = { 9, 2, 6, 4, 5, 3, 7, 8, 1, 10 };
            var result = from n in numbers
                         where n % 2 == 0
                         orderby n
                         select n;
            foreach (int n in result)
                WriteLine($"짝수: {n}");

            
            // select 문장에 기존의 데이터의 변형/조건을 걸수가 있음 -> select new {...}
            Profile[] pfs = { new Profile() { Name = "김철수", Height = 186 },
                              new Profile() { Name = "바끄네", Height = 158 },
                              new Profile() { Name = "채순시", Height = 172 },
                              new Profile() { Name = "김기출", Height = 178 },
                              new Profile() { Name = "유병우", Height = 171 },       };

            var pfs_if = from profile in pfs
                     where profile.Height < 175
                     orderby profile.Height
                     select new { Name = profile.Name, InchHeight = profile.Height * 0.393 };
                   
            foreach (var profile in pfs_if)
                WriteLine($"{profile.Name}, {profile.InchHeight}");

            // 
            Class[] cls = {new Class() { Name = "장미반", Score = new int[] { 99, 80, 70, 24 } }
                         , new Class() { Name = "백합반", Score = new int[] { 60, 45, 87, 72 } }
                         , new Class() { Name = "개나리반", Score = new int[] { 92, 30, 85, 94 } }
                         , new Class() { Name = "갈대반", Score = new int[] { 90, 88, 0, 17 } } };

            var cls_if = from c in cls
                         from s in c.Score
                         where s < 60
                         orderby s
                         select new { c.Name, Lowest = s };

            foreach (var c in cls_if)
                WriteLine($"낙제: {c.Name}({c.Lowest})");

            // 
            Person[] persons = { new Person() { Name = "성나정", Sex = "여자" },
                                 new Person() { Name = "쓰레기", Sex = "남자" },
                                 new Person() { Name = "조윤진", Sex = "여자" },
                                 new Person() { Name = "삼천포", Sex = "남자" },      };

            var group = from person in persons
                        group person by person.Sex == "남자" into data
                        select new { SexCheck = data.Key, People = data };

            foreach (var element in group)
            {
                if (element.SexCheck)
                {
                    WriteLine("<남자 리스트>");
                    foreach (var person in element.People)
                        WriteLine($"이름: {person.Name}");
                }
                else
                {
                    WriteLine("<여자 리스트>");
                    foreach (var person in element.People)
                        WriteLine($"이름: {person.Name}");
                }
            }
        }

        public class Profile
        {
            public string Name { get; set; }
            public int Height { get; set; }
        }

        public class Class
        {
            public string Name { get; set; }
            public int[] Score { get; set; }
        }

        public class Person
        {
            public string Sex { get; set; }
            public string Name { get; set; }
        }
    }
}
