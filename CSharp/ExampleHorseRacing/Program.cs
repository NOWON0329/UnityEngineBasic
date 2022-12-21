using System;
using System.Threading;

// 진행 방식
//
// 말 클래스 필요
// 말 클래스는 달린거리, 이동하기(달리기) 라는 함수를 가집니다.
// 
// 프로그램 시작시
// 말 다섯마리 만들고
// 각 말은 초당 10 ~ 20 (정수형) 범위의 거리를 랜덤하게 전진.
// 각각의 말은 거리 200에 도달하면 도착해서 더이상 전진하지 않고 
// 매초 각 말들이 아직 달리고 있다면 달린 거리를, 도착했다면 도착 상태를 콘솔창에 출력 해줍니다.
// 모든 말이 도착했다면 경주를 끝내고 등수 순서대로 말들의 이름을 콘솔창에 출력 해줍니다.
namespace Example1_HorseRacing
{
    internal class Program
    {
        class Horse
        {
            public string Name;
            public bool IsFinished = false;
            public int TotalDistance;

            public void Run(int distance)
            {
                TotalDistance += distance;
            }
        }

        static Random random;
        static int minSpeed = 10;
        static int maxSpeed = 20;
        static int goalPos = 200;

        static void Main(string[] args)
        {
            int j = 0;
            int sec = 0;
            Horse[] horse = new Horse[5];
            string[] name = new string[5];

            // 말 다섯마리 만들고 
            // 이름 다 설정 해줌 (이름 패턴은 경주마1, 경주마2, 경주마3 ... )
            for (int i = 0; i < 5; i++)
            {
                horse[i] = new Horse();
                horse[i].Name = "말" + (i + 1);
            }
            Console.WriteLine("=================경주 시작================");
            while (true)
            {
                Console.WriteLine("=================경주" + sec + "초 경과================");
                // 각 말은 초당 10 ~ 20 (정수형) 범위의 거리를 랜덤하게 전진.
                // 각각의 말은 거리 200에 도달하면 도착해서 더이상 전진하지 않고 
                // 매초 각 말들이 아직 달리고 있다면 달린 거리를, 도착했다면 도착 상태를 콘솔창에 출력 해줍니다.
                // 모든 말이 도착했으면 게임 끝냄

                for (int i = 0; i<5; i++)
                {
                    if(!horse[i].IsFinished)
                    {
                        random = new Random();
                        int tmpSpeed = random.Next(minSpeed, maxSpeed + 1);
                        horse[i].Run(tmpSpeed);
                        Console.WriteLine(horse[i].TotalDistance);
                        if (horse[i].TotalDistance >= goalPos)
                        {
                            name[j++] = horse[i].Name;
                            horse[i].IsFinished = true;
                        }
                    }
                }
                if (j>= 5)
                {
                    break;
                }

                Thread.Sleep(1000);
                sec++;
            }
            Console.WriteLine("=================경주 끝================");

            for (int i = 0; i<5; i++)
            {
                Console.WriteLine(name[i]);
            }
            // 각 말들을 등수 순서대로 이름을 출력해줌
        }
    }
}