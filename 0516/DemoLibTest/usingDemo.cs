using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoLib;
using static System.Console;

namespace DemoLibTest
{
    class usingDemo
    {
        static void Main(string[] args)
        {
            DemoClass dc = new DemoClass();
            dc.Foo();

            ReadLine();     // .dll 삭제해도 실행됨을 알기 위해 메인스레드 멈춰놓음(프로글매 종료 후 .dll 자동으로 추가되기 때문)
        }
    }           // 빌드까지 하고나면, 실행파일(.exe)이 있는 곳과 같은 위치에 DemoLib.dll이 들어오게 된다.
                // 심지어 이 위치에서 DemoLib.dll 파일을 삭제하고 실행파일(.exe)을 직접 실행해도 문제없이 돌아간다 => 공용 어셈블리 파일이라서 가능
                
    
}

/* 단단형 주관식 3개 나머지 객관식
 * 토요일 오후 적당한 시간에 테스트
 * 1. 열거형 타입
 * 2. 보기 코드 (다음코드가 수행됐을 때 출력되는 코드를 고르시오 등)
 * - ? 관련(nullable, ??, 타입?)
 * 3. 가장 조상(최상위 상속)이 누군지?
 * 4. C#의 엔트리포인트인 Main()의 형태
 * 5. 교재 앞쪽 참고(C#과 .NET의 데이터타입 비교표)
 * 6. ?관련 
 * - int도 C#에서는 객체
 * - int.MinValue, int.MaxValue => 뜻하는게 무엇을 의미하는지(프로퍼티 예상)
 * 7. 인터페이스 구성요소에 무엇이 들어갈수 있는지
 * 8. IEnumerable.GetEnumerate()에서 하나씩 리턴해주던 문장 => yield 예상
 * 9. 접근제한자 
 * 10. 제네릭 타입변수 제한자 => where T 부분
 * 11. 익명타입 => 메인에서 직접 정의하던거
 * 12. new로 객체생성하는 문제 => 보기 읽는 순간 답이 있음
 * 13. 상속과 생성자에 대해 생각하면 나오는 문제(...)
 * 14. 스레드를 중지할 수 있는 세가지 방법 중 아닌 것을 고르시오
 * 15~20. 5문제=> 스레드 & Task 문제/ 나머지 1문제 어셈블리 문제
 * 
 * 
 * Task클래스: 비동기 지원하는 클래스
 * 일반 메소드를 비동기 메소드로 바꿔주는 < async, await > 
 * - async: 메소드, 이벤트처리기, 태스크,람다식에 async를 붙여주면 비동기로 동작
 * - async로 한정하는 메소드는 반환형식이 반드시 Task, Task<TResult> 또는 void여야 함 ==>=>=> 객관식 나올 예정
 * - Task, Task<TResult> 타입 메소드는 메소드 내부에 await 연산자를 만나면 호출자에게 제어권 넘김(await 연산자가 없으면 동기방식으로 진행)
 *  
 */
