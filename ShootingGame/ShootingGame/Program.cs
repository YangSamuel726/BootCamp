using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ShootingGame1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(80, 25); // 콘솔 창 크기 설정 (가로 80, 세로 25)
            Console.SetBufferSize(80, 25); // 버퍼 크기도 동일하게 설정 (스크롤 방지)

            //int x = 10, y = 10;

            //ConsoleKeyInfo keyInfo;

            //Console.CursorVisible = false;

            //while(true)
            //{
            //    Console.Clear(); //화면 지우기

            //    Console.SetCursorPosition(x, y);

            //    Console.Write("●"); //현재 위치 출력

            //    keyInfo = Console.ReadKey(true); //키 입력 받기 (화면 출력 X)

            //    //방향키 입력에 따른 좌표 변경
            //    switch(keyInfo.Key)
            //    {
            //        case ConsoleKey.UpArrow: if (y > 0) y--;break;
            //        case ConsoleKey.DownArrow: if (y < Console.WindowHeight - 1) y++; break;
            //        case ConsoleKey.LeftArrow: if (x > 0) x--; break;
            //        case ConsoleKey.RightArrow: if (x < Console.WindowWidth - 1) x++; break;
            //        case ConsoleKey.Spacebar: Console.Write("미사일키"); break;
            //        case ConsoleKey.Escape: return; //ESC키로 종료 

            //    }


            //}


            //string[] player = new string[]
            //{
            //    "->",
            //    ">>>",
            //    "->",
            //}; //배열 문자열로 그리기

            Console.WriteLine("플레이어(전투기)의 몸체를 만듭니다. 한줄마다 그리기가 완성되면 Enter를 눌러주세요.");
            Console.WriteLine("총 3줄까지 가능합니다.");
            string a = Console.ReadLine();
            string b = Console.ReadLine();
            string c = Console.ReadLine();

            Player player = new Player("멋사", a, b, c);

            int playerX = 0;
            int playerY = 12;

            ConsoleKeyInfo keyInfo;

            Console.CursorVisible = false;


            //시간 1초루프
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            long prevSecond = stopwatch.ElapsedMilliseconds; // 1 /1000    1000일때 1초

            while (true)
            {
                long currentSecond = stopwatch.ElapsedMilliseconds; //현재시간 가져오기

                if (currentSecond - prevSecond >= 50)
                {
                    // Console.WriteLine("0.3초루프");
                    keyInfo = Console.ReadKey(true); //키 입력 받기 (화면 출력 X)
                    Console.Clear();



                    //방향키 입력에 따른 좌표 변경
                    switch (keyInfo.Key)
                    {
                        case ConsoleKey.UpArrow: if (playerY > 0) playerY--; break;
                        case ConsoleKey.DownArrow: if (playerY < Console.WindowHeight - 4) playerY++; break;
                        case ConsoleKey.LeftArrow: if (playerX > 0) playerX--; break;
                        case ConsoleKey.RightArrow: if (playerX < Console.WindowWidth - 1 - player.highBody) playerX++; break;
                        case ConsoleKey.Spacebar: Console.Write("미사일키"); break;
                        case ConsoleKey.Escape: return; //ESC키로 종료 

                    }

                    for (int i = 0; i < player.body.Length; i++)
                    {
                        //콘솔좌표 설정 플레이어X 플레이어Y
                        Console.SetCursorPosition(playerX, playerY + i);
                        //문자열배열 출력
                        Console.WriteLine(player.body[i]);
                    }

                    prevSecond = currentSecond;//이전 시간 업데이트
                }
            }
        }
    }

    public struct Player
    {
        public string[] body;
        public string name;
        public int highBody; //몸체 중에서 가장 길이가 긴 몸체의 길이, 몸체가 스크린 밖을 나가지 않게 하는 검사에 추가할 값

        public Player(string _name, string a, string b, string c)
        {
            name = _name;
            body = new string[]
            {
                //"->",
                //">>>",
                //"->",
                a,
                b,
                c
            };
            int max = 0;
            if(a.Length > max) { max = a.Length; }
            if(b.Length > max) { max = b.Length; }
            if(c.Length > max) { max = c.Length; }
            highBody = max;
        }
    }
}

