﻿using System;

namespace EnumAndSwitch
{
    internal class Program
    {
        //enum 열거형 (사용자 정의 자료형)
        //32bit 정수형, 특정 요소에 값이 할당되어있지 않으면 바로 이전 요소의 값에 + 1한다.
        //첫 요소는 값이 할당되어있찌 않으면 0이다.
        enum State
        {
            Idle,
            Walk,
            Run,
            Jump,
            Attack
        }

        static State state; 

        static void Main(string[] args)
        {
            //switch (경우에 대한 인자)
            //{
            //    case 경우1:
            //        break;
            //    case 경우2:
            //        break;
            //    case 경우3:
            //        break;
            //    default:
            //        break;
            //}

            //캐릭터 상태
            //0 : idle
            //1 : walk
            //2 : run
            //3 : jump
            //4 : attack

            //형변환 (캐스팅)
            //어떤 값을 다른 자료형으로 변환하는 것.
            //
            //명시적 캐스팅
            //
            //암시적 캐스팅

            while(true)
            {
                state = (State)Int32.Parse(Console.ReadLine());
                //state = (State)Enum.Parse(typeof(State), Console.ReadLine());
                switch (state)   
                {
                    case State.Idle:
                        Console.WriteLine("캐릭터가 Idle 상태로 전환되었습니다");
                        break;
                    case State.Walk:
                        Console.WriteLine("캐릭터가 Walk 상태로 전환되었습니다");
                        break;
                    case State.Run:
                        Console.WriteLine("캐릭터가 Run 상태로 전환되었습니다");
                        break;
                    case State.Jump:
                        Console.WriteLine("캐릭터가 Jump 상태로 전환되었습니다");
                        break;
                    case State.Attack:
                        Console.WriteLine("캐릭터가 Attack 상태로 전환되었습니다");
                        break;
                    default:
                        Console.WriteLine("잘못된 입력입니다");
                        break;
                }
            }

            int numState;
            while(true)
            {
                numState = Int32.Parse(Console.ReadLine());
                switch(numState)
                {
                    case 0:
                        Console.WriteLine("캐릭터가 Idle 상태로 전환되었습니다");
                        break;
                    case 1:
                        Console.WriteLine("캐릭터가 Walk 상태로 전환되었습니다");
                        break;
                    case 2:
                        Console.WriteLine("캐릭터가 Run 상태로 전환되었습니다");
                        break;
                    case 3:
                        Console.WriteLine("캐릭터가 Jump 상태로 전환되었습니다");
                        break;
                    case 4:
                        Console.WriteLine("캐릭터가 Attack 상태로 전환되었습니다");
                        break;
                    default:
                        break;
                }
            }

            string fruit;
            while(true)
            {
                fruit = Console.ReadLine();

                switch (fruit)
                {
                    case "사과":
                        Console.WriteLine("이거 사관데여");
                        break;
                    case "바나나":
                        Console.WriteLine("이거는 바나나에여");
                        break;
                    case "수박":
                        Console.WriteLine("수박요");
                        break;
                    default:
                        Console.WriteLine("이건 뭔지 모르겠어여");
                        break;
                }
            }
        }
    }
}
