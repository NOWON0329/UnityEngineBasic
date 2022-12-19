using System;

namespace Array2D
{
    internal class Program
    {
        //Inner class
        //클래스 내에 정의된 클래스
        class Player
        {
            public int x, y;

            //this 키워드
            //객체 자기자신 참조 키워드             

            public void SetPos(int x, int y)
            {
                this.x = x;
                this.y = y;
                Program.map[y, x] = 5;
                Program.DisplayMap();
                Console.WriteLine();
            }

            public void MoveDown()
            {
                //움직이면 맵의 경계를 벗어나는지 체크
                if (y >= map.GetLength(0) - 1)
                    return;

                //지나갈 수 없는 벽인지 체크
                if (map[y + 1, x] == 1)
                    return;

                map[y, x] = 0;
                SetPos(x, y + 1);
            }
            public void MoveUp()
            {
                if (y <= 0) 
                    return;

                if (map[y - 1, x] == 1)
                    return;

                map[y, x] = 0;
                SetPos(x, y - 1);
            }
            public void MoveRight()
            {
                if (x >= map.GetLength(1) - 1)
                    return;

                if (map[y, x + 1] == 1)
                    return;

                map[y, x] = 0;
                SetPos(x + 1, y);
            }
            public void MoveLeft()
            {
                if (x <= 0)
                    return;

                if (map[y, x - 1] == 1)
                    return;

                map[y, x] = 0;
                SetPos(x - 1, y);
            }
        } 

        //0은 지나갈 수 있는 길
        //1은 지나갈 수 없는 벽
        //2는 도착지점
        //5는 플레이어
        static int[,] map = new int[5, 5]
        {
            {0,1,1,1,1},
            {0,1,1,1,1},
            {0,0,0,1,1},
            {1,1,0,1,1},
            {1,1,0,0,2}
        };

        static void Main(string[] args)
        {
            Player player = new Player();
            player.SetPos(0, 0);
            player.MoveDown();
            player.MoveDown();
            player.MoveRight();
            player.MoveRight();
            player.MoveLeft();
        }

        static void DisplayMap()
        {
            for(int i = 0; i<map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (map[i,j] == 0)
                    {
                        Console.Write("0");
                    }
                    else if(map[i,j] == 1)
                    {
                        Console.Write("1");
                    }
                    else if (map[i, j] == 2)
                    {
                        Console.Write("2");
                    }
                    else if (map[i, j] == 5)
                    {
                        Console.Write("5");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
