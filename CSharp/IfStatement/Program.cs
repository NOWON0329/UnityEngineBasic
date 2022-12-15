using System;

namespace IfStatement
{
    internal class Program
    {
        static bool condition1 = false;
        static bool condition2 = false;
        static void Main(string[] args)
        {
            if(condition1)
            {
                Console.WriteLine("조건1이 참이다");
            }
            else if(condition2)
            {
                Console.WriteLine("조건1이 거짓이고 조건2가 참이다");
            }
            else
            {
                Console.WriteLine("조건1, 2 모두 거짓이다");
            }
        }
    }
}
