using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace FindMine
{
    class Program
    {
        static bool[,] mineGround = new bool[10, 10];
        static bool[,] chooseGround = new bool[10, 10];
        static string[,] outGround = new string[10, 10];
        static string[,] inGround = new string[10, 10];
        static bool[,] flagGround = new bool[10, 10];
        static (int, int) myposition = (0, 0);
        static int mineCount = 10;
        static Random rand = new Random();
        static bool retry = true;
        static bool isEnd = false;
        static void Main(string[] args)
        {
            while (retry == true)
            {
                retry = false;
                isEnd = false;

                mineGround = new bool[10, 10];
                chooseGround = new bool[10, 10];
                outGround = new string[10, 10];
                inGround = new string[10, 10];
                flagGround = new bool[10, 10];
                myposition = (0, 0);

                // 보이는 지뢰판 초기화
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        outGround[i, j] = " ■";
                        inGround[i, j] = " -";
                    }
                }


                // 지뢰 개수 초기화
                while (true)
                {
                    Clear();
                    Write("원하는 지뢰 개수를 말씀해 주세요. (최소 1개, 최대 30개) : ");
                    if (int.TryParse(ReadLine(), out int result))
                    {
                        if (result > 30) { result = 30; }
                        if (result < 1) { result = 1; }
                        mineCount = result;
                        break;
                    }
                    else
                    {
                        WriteLine("올바르지 않은 지뢰 개수입니다.");
                        ContinueToEnter();
                    }
                }

                // 지뢰 배치
                for (int i = 0; i < mineCount; i++)
                {
                    while (true)
                    {
                        int a = rand.Next(0, 10);
                        int b = rand.Next(0, 10);

                        if (mineGround[a, b] == false)
                        {
                            mineGround[a, b] = true;
                            ForegroundColor = ConsoleColor.Red;
                            inGround[a, b] = " *";
                            ResetColor();
                            break;
                        }
                    }
                }

                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        int mine = 0;
                        if (i - 1 >= 0 && j - 1 >= 0 && mineGround[i - 1, j - 1] == true) { mine++; } // 좌 상단 지뢰 있는지 확인
                        if (i - 1 >= 0 && mineGround[i - 1, j] == true) { mine++; } // 중 상단 지뢰 있는지 확인
                        if (i - 1 >= 0 && j + 1 <= 9 && mineGround[i - 1, j + 1] == true) { mine++; } // 우 상단 지뢰 있는지 확인
                        if (j - 1 >= 0 && mineGround[i, j - 1] == true) { mine++; } // 좌 중단 지뢰 있는지 확인
                        if (j + 1 <= 9 && mineGround[i, j + 1] == true) { mine++; } // 우 중단 지뢰 있는지 확인
                        if (i + 1 <= 9 && j - 1 >= 0 && mineGround[i + 1, j - 1] == true) { mine++; } // 좌 하단 지뢰 있는지 확인
                        if (i + 1 <= 9 && mineGround[i + 1, j] == true) { mine++; } // 중 하단 지뢰 있는지 확인
                        if (i + 1 <= 9 && j + 1 <= 9 && mineGround[i + 1, j + 1] == true) { mine++; } // 우 하단 지뢰 있는지 확인
                        if (mine == 0)
                        {
                            if (inGround[i, j] != " *")
                            {
                                inGround[i, j] = " -";
                            }
                        }
                        else
                        {
                            if (inGround[i, j] != " *")
                            {
                                inGround[i, j] = $" {mine}";
                            }
                        }
                    }
                }

                DrawGround();

                while (retry == false && isEnd == false)
                {
                    Move();
                    if (isEnd == true) { break; }
                    DrawGround();
                    if(CheckGameEnd())
                    {
                        Win();
                        break;
                    }
                }
            }
        }

        static void DrawGround()
        {
            Clear();

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (i == myposition.Item1 && j == myposition.Item2)
                    {
                        Write(" ○");
                        continue;
                    }

                    if (flagGround[i, j] == true && chooseGround[i, j] == false)
                    {
                        ForegroundColor = ConsoleColor.Blue;
                        Write(" ?");
                        ResetColor();
                        continue;
                    }

                    if (chooseGround[i, j] == true)
                    {
                        Write(inGround[i, j]);
                    }
                    else
                    {
                        Write(outGround[i, j]);
                    }
                }
                WriteLine();
            }

            WriteLine("조작 방법 : WASD(움직임) | K(선택) | L(깃발) | R(다시 시작)");
        }

        static void DrawGameEnd()
        {
            Clear();
            isEnd = true;

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Write(inGround[i, j]);
                }
                WriteLine();
            }

            WriteLine("이런! 지뢰를 터트려버렸습니다.");
            WriteLine("다시 하시려면 R키를 눌러주세요.");
            Move();
        }

        static void Move()
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            switch (keyInfo.Key)
            {
                case ConsoleKey.W:
                    if (myposition.Item1 > 0)
                    {
                        myposition.Item1 -= 1;
                    }
                    break;
                case ConsoleKey.A:
                    if (myposition.Item2 > 0)
                    {
                        myposition.Item2 -= 1;
                    }
                    break;
                case ConsoleKey.S:
                    if (myposition.Item1 < 9)
                    {
                        myposition.Item1 += 1;
                    }
                    break;
                case ConsoleKey.D:
                    if (myposition.Item2 < 9)
                    {
                        myposition.Item2 += 1;
                    }
                    break;
                case ConsoleKey.K:
                    if (isEnd == true) { break; }
                    Choose();
                    break;
                case ConsoleKey.L:
                    Flag();
                    break;
                case ConsoleKey.R:
                    retry = true;
                    break;
                default:
                    break;
            }
        }

        static void Choose()
        {
            if (mineGround[myposition.Item1, myposition.Item2] == true)
            {
                DrawGameEnd();
                return;
            }

            if (chooseGround[myposition.Item1, myposition.Item2] == false)
            {
                IFNothing(myposition.Item1, myposition.Item2);
            }
        }

        static void Flag()
        {
            if (flagGround[myposition.Item1, myposition.Item2] == false)
            {
                flagGround[myposition.Item1, myposition.Item2] = true;
            }
            else
            {
                flagGround[myposition.Item1, myposition.Item2] = false;
            }
        }

        static void IFNothing(int i, int j)
        {
            chooseGround[i, j] = true;

            if (inGround[i, j] == " -")
            {
                if (i - 1 >= 0 && chooseGround[i - 1, j] == false)  // 위 검사
                {
                    if (inGround[i - 1, j] == " -")
                    {
                        IFNothing(i - 1, j);
                    }
                    else
                    {
                        chooseGround[i - 1, j] = true;
                    }
                }
                if (i + 1 < 10 && chooseGround[i + 1, j] == false) // 아래 검사
                {
                    if (inGround[i + 1, j] == " -")
                    {
                        IFNothing(i + 1, j);
                    }
                    else
                    {
                        chooseGround[i + 1, j] = true;
                    }
                }
                if (j - 1 >= 0 && chooseGround[i, j - 1] == false) // 왼쪽 검사
                {
                    if (inGround[i, j - 1] == " -")
                    {
                        IFNothing(i, j - 1);
                    }
                    else
                    {
                        chooseGround[i, j - 1] = true;
                    }
                }
                if (j + 1 < 10 && chooseGround[i, j + 1] == false) // 오른쪽 검사
                {
                    if (inGround[i, j + 1] == " -")
                    {
                        IFNothing(i, j + 1);
                    }
                    else
                    {
                        chooseGround[i, j + 1] = true;
                    }
                }

                if (i - 1 >= 0 && j - 1 >= 0 && chooseGround[i - 1, j - 1] == false)
                {
                    if (inGround[i - 1, j - 1] != " -" && inGround[i - 1, j - 1] != " *")
                    {
                        chooseGround[i - 1, j - 1] = true;
                    }
                }
                if (i - 1 >= 0 && j + 1 < 10 && chooseGround[i - 1, j + 1] == false)
                {
                    if (inGround[i - 1, j + 1] != " -" && inGround[i - 1, j + 1] != " *")
                    {
                        chooseGround[i - 1, j + 1] = true;
                    }
                }
                if (i + 1 < 10 && j - 1 >= 0 && chooseGround[i + 1, j - 1] == false)
                {
                    if (inGround[i + 1, j - 1] != " -" && inGround[i + 1, j - 1] != " *")
                    {
                        chooseGround[i + 1, j - 1] = true;
                    }
                }
                if (i + 1 < 10 && j + 1 < 10 && chooseGround[i + 1, j + 1] == false)
                {
                    if (inGround[i + 1, j + 1] != " -" && inGround[i + 1, j + 1] != " *")
                    {
                        chooseGround[i + 1, j + 1] = true;
                    }
                }
            }
        }

        static bool CheckGameEnd()
        {
            for(int i = 0; i < 10; i++)
            {
                for(int j = 0; j < 10; j++)
                {
                    if (mineGround[i,j] == true) { continue; }
                    else if (chooseGround[i,j] == false) { return false; }
                }
            }
            return true;
        }

        static void Win()
        {
            WriteLine("축하드립니다! 모든 지뢰를 찾는데 성공하셨습니다!");
            WriteLine("다시 시작하시려면 R키를 눌러주세요");
            Move();
        }

        static void ContinueToEnter()
        {
            WriteLine("아무 키나 눌러서 진행하세요.");
            ReadLine();
        }
    }
}
