using System;

//Function : 연산을 수행할 수 있는 기능
//Method : 객체/클래스 단위로 호출되는 Function
//Method C Function
//
//함수 형태 3가지
//함수 선언, 정의, 호출
//함수 선언 : 이레 형태와 같은 함수를 사용하겠다 라고만 선언하는 것이고, 실제 함수가 어떤 연산을 하는지 구현부분이 없음
//반환형 함수이름 (파라미터):
//
//함수 정의
//반환형 함수이름 (파라미터)
//{
//    연산
//    return;
//}
//
//함수 호출 :
//함수이름 (인자):
namespace Method
{
    internal class Program
    {
        //전역 변수 (글로벌 변수)
        //초기화값이 있을 경우 데이터 영역에 할당, 초기화값이 없을 경우 BSS 영역에 할당
        static bool doPrintHelloWorld;

        //여기서 Main 함수는 함수 정의
        static void Main(string[] args)
        {
            //지역변수 - 함수 내에서 선언된 변수
            //지역변수는 함수 호출 스택에 같이 호출됨
            //해당 변수 공간에 어떤 데이터가 쓰여져 있는지 알 수 없기 때문에
            //초기화를 반드시 하고 데이터에 접근해야한다.
            bool somethingPrinted = false;
            Console.WriteLine(doPrintHelloWorld);
            Console.WriteLine(somethingPrinted);

            PrintHelloWorld();
            string name = "홍길동";
            PrintSomething(name);
        }

        static void PrintHelloWorld()
        {
            //여기 console.writeLine은 함수 호출
            Console.WriteLine("Hello World!");
            doPrintHelloWorld = true;
        }

        static void PrintSomething(string something)
        {
            Console.WriteLine(something);
        }
    }
}
