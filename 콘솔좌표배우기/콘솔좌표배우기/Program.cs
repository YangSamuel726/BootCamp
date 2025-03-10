using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using static System.Console;
using System.Diagnostics.Contracts;

namespace 콘솔좌표배우기
{
    class Program
    {
        static string name = "멋사";
        static int maxHP = 200;
        static int curHP = 200;
        static int gold = 1000000000;
        static int att = 5;
        static int upgradeCount = 0;
        static bool isAlive = true;
        static void Main(string[] args)
        {
            // 콘솔 창 크기 설정
            SetWindowSize(80, 25);

            // 콘솔 버퍼 크기도 설정 (스크롤 없이 고정된 창 유지)
            SetBufferSize(80, 25);

            CursorVisible = false;

            Clear();
            SetCursorPosition(0, 0);
            WriteLine("┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓");
            SetCursorPosition(0, 1);
            WriteLine("┃                                                                              ┃");
            SetCursorPosition(0, 2);
            WriteLine("┃                                                                              ┃");
            SetCursorPosition(0, 3);
            WriteLine("┃                                                                              ┃");
            SetCursorPosition(0, 4);
            WriteLine("┃                                                                              ┃");
            SetCursorPosition(0, 5);
            WriteLine("┃                                                                              ┃");
            SetCursorPosition(0, 6);
            WriteLine("┃                                                                              ┃");
            SetCursorPosition(0, 7);
            WriteLine("┃                                                                              ┃");
            SetCursorPosition(0, 8);
            WriteLine("┃                                                                              ┃");
            SetCursorPosition(0, 9);
            WriteLine("┃                                                                              ┃");
            SetCursorPosition(0, 10);
            WriteLine("┃                                                                              ┃");
            SetCursorPosition(0, 11);
            WriteLine("┃                                                                              ┃");
            SetCursorPosition(0, 12);
            WriteLine("┃                              대장장이 키우기                                 ┃");
            SetCursorPosition(0, 13);
            WriteLine("┃                                                                              ┃");
            SetCursorPosition(0, 14);
            WriteLine("┃                                                                              ┃");
            SetCursorPosition(0, 15);
            WriteLine("┃                                                                              ┃");
            SetCursorPosition(0, 15);
            WriteLine("┃                                                                              ┃");
            SetCursorPosition(0, 16);
            WriteLine("┃                                                                              ┃");
            SetCursorPosition(0, 17);
            WriteLine("┃                                                                              ┃");
            SetCursorPosition(0, 18);
            WriteLine("┃                                                                              ┃");
            SetCursorPosition(0, 19);
            WriteLine("┃                                                                              ┃");
            SetCursorPosition(0, 20);
            WriteLine("┃                                                                              ┃");
            SetCursorPosition(0, 21);
            WriteLine("┃                                                                              ┃");
            SetCursorPosition(0, 22);
            WriteLine("┃                                                                              ┃");
            SetCursorPosition(0, 23);
            WriteLine("┃                                                                              ┃");
            SetCursorPosition(0, 24);
            Write("┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛");

            Thread.Sleep(5000);
            Clear();

            ChooseAct();
        }

        static void ChooseAct()
        {
            while (isAlive)
            {
                Clear();
                ShowState();
                WriteLine("숫자를 입력하여 행동을 결정해 주세요.");
                WriteLine("1. 탐험하기");
                WriteLine("2. 휴식하기");
                WriteLine("3. 강화하기");
                WriteLine("4. 종료하기");

                switch (GetInput())
                {
                    case 1:
                        Adventure();
                        break;
                    case 2:
                        Rest();
                        break;
                    case 3:
                        Upgrade();
                        break;
                    case 4:
                        LogOut();
                        break;
                    default:
                        WriteLine("올바른 입력이 아닙니다. 다시 입력해 주세요.");
                        ContinueToEnter();
                        break;
                }
            }
        }

        static void Adventure()
        {
            bool isIn = true;
            while (isIn)
            {
                Clear();
                ShowState();

                WriteLine("던전에 입장하셨습니다.");
                WriteLine("1. 고블린 (HP : 5)");
                WriteLine("2. 스켈레톤 (HP : 15)");
                WriteLine("3. 오크 (HP : 30)");
                WriteLine("4. 듀라한 (HP : 40)");
                WriteLine("5. 사천왕 중 최약 (HP : 60)");
                WriteLine("6. 사천왕 중 최강 (HP : 80)");
                WriteLine("7. 마왕 (HP : 105)");
                WriteLine("8. 돌아가기");

                switch (GetInput())
                {
                    case 1:
                        Fight(5);
                        break;
                    case 2:
                        Fight(15);
                        break;
                    case 3:
                        Fight(30);
                        break;
                    case 4:
                        Fight(40);
                        break;
                    case 5:
                        Fight(60);
                        break;
                    case 6:
                        Fight(80);
                        break;
                    case 7:
                        Fight(105);
                        break;
                    case 8:
                        isIn = false;
                        break;
                    default:
                        WriteLine("올바른 입력이 아닙니다. 다시 입력해 주세요.");
                        ContinueToEnter();
                        break;
                }
            }
        }

        static void Rest()
        {
            Clear();
            WriteLine("쉬는 중.");
            Thread.Sleep(500);
            Clear();
            WriteLine("쉬는 중..");
            Thread.Sleep(500);
            Clear();
            WriteLine("쉬는 중...");
            Thread.Sleep(500);
            Clear();
            WriteLine("쉬는 중.");
            Thread.Sleep(500);
            Clear();
            WriteLine("쉬는 중..");
            Thread.Sleep(500);
            Clear();
            WriteLine("쉬는 중...");
            Thread.Sleep(500);
            Clear();
            curHP = maxHP;
            ShowState();
            WriteLine("푹 쉬어서 HP가 모두 회복되었습니다.");
            ContinueToEnter();
        }

        static void Upgrade()
        {
            if (upgradeCount >= 50)
            {
                WriteLine("이미 무기가 최대 강화 상태입니다.");
                ContinueToEnter();
                return;
            }

            bool isIn = true;
            double needProbability;
            double failed;
            while (isIn)
            {
                Clear();
                ShowState();

                needProbability = 100 - upgradeCount * 2;
                failed = upgradeCount * 2 - 38;

                WriteLine("강화소에 오신 것을 환영합니다.");
                WriteLine($"현재 강화 성공 확률은 {needProbability}%입니다.");
                WriteLine("20강 부터는 강화 실패시 강화 단계가 하락할 수도 있습니다.");
                WriteLine("1. 강화하기 (1000 골드 필요)");
                WriteLine("2. 돌아가기");

                switch (GetInput())
                {
                    case 1:
                        Clear();
                        WriteLine("강화 중.");
                        Thread.Sleep(500);
                        Clear();
                        WriteLine("강화 중..");
                        Thread.Sleep(500);
                        Clear();
                        WriteLine("강화 중...");
                        Thread.Sleep(500);
                        Clear();
                        WriteLine("강화 중.");
                        Thread.Sleep(500);
                        Clear();
                        WriteLine("강화 중..");
                        Thread.Sleep(500);
                        Clear();
                        WriteLine("강화 중...");
                        Thread.Sleep(500);
                        Clear();

                        gold -= 1000;
                        if (needProbability > GetRandomValue() * 100)
                        {
                            WriteLine("축하드립니다. 강화에 성공했습니다!");
                            upgradeCount++;
                        }
                        else
                        {
                            if (failed > GetRandomValue() * 100)
                            {
                                WriteLine("강화에 실패했습니다... 이런! 무기가 다운그레이드되었습니다 ㅠㅠ");
                                upgradeCount--;
                            }
                            else
                            {
                                if (upgradeCount < 20)
                                {
                                    WriteLine("강화에 실패했습니다.");
                                }
                                else
                                {
                                    WriteLine("강화에 실패했습니다... 하지만 무기는 무사합니다!");
                                }
                            }
                        }
                        ContinueToEnter();
                        break;
                    case 2:
                        isIn = false;
                        break;
                    default:
                        WriteLine("올바른 입력이 아닙니다. 다시 입력해 주세요.");
                        ContinueToEnter();
                        break;
                }
            }
        }

        static void LogOut()
        {
            Clear();
            WriteLine("게임을 종료합니다. 안녕히 가세요. :)");
            Thread.Sleep(3000);
            Environment.Exit(1);
        }

        static int GetInput()
        {
            int input = 0;

            Write("입력 : ");

            bool validInput = true;
            while (validInput)
            {
                string s = ReadLine();
                switch (s)
                {
                    case "1":
                        input = int.Parse(s);
                        validInput = false;
                        break;
                    case "2":
                        input = int.Parse(s);
                        validInput = false;
                        break;
                    case "3":
                        input = int.Parse(s);
                        validInput = false;
                        break;
                    case "4":
                        input = int.Parse(s);
                        validInput = false;
                        break;
                    case "5":
                        input = int.Parse(s);
                        validInput = false;
                        break;
                    case "6":
                        input = int.Parse(s);
                        validInput = false;
                        break;
                    case "7":
                        input = int.Parse(s);
                        validInput = false;
                        break;
                    case "8":
                        input = int.Parse(s);
                        validInput = false;
                        break;
                    default:
                        WriteLine("올바른 입력이 아닙니다. 다시 입력해 주세요.");
                        validInput = true;
                        break;
                }
            }

            return input;
        }

        static void ContinueToEnter()
        {
            WriteLine("아무키나 눌러서 계속 진행하기");
            ReadLine();
        }

        static void ShowState()
        {
            WriteLine("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
            WriteLine($"이름 : {name} | 소지 골드 : {gold}원");
            WriteLine($"현재 체력 : {curHP} / {maxHP} | 공격력 : {att + upgradeCount * 5} | 강화 단계 : {upgradeCount}강");
            WriteLine("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
            WriteLine();
        }

        static double GetRandomValue()
        {
            Random rand = new Random();
            return rand.NextDouble();
        }

        static void Fight(int monsterHP)
        {
            Clear();
            WriteLine("전투 중.");
            Thread.Sleep(500);
            Clear();
            WriteLine("전투 중..");
            Thread.Sleep(500);
            Clear();
            WriteLine("전투 중...");
            Thread.Sleep(500);
            Clear();
            WriteLine("전투 중.");
            Thread.Sleep(500);
            Clear();
            WriteLine("전투 중..");
            Thread.Sleep(500);
            Clear();
            WriteLine("전투 중...");
            Thread.Sleep(500);
            Clear();

            if (att + upgradeCount * 5 >= monsterHP)
            {
                Random rnd = new Random();
                int result = rnd.Next(10 * monsterHP, 100 * monsterHP);
                WriteLine("전투에서 승리하셨습니다!");
                if(monsterHP >= 105)
                {
                    GameEnd();
                }
                WriteLine($"{result}원을 획득하셨습니다.");
                gold += result;
                curHP -= monsterHP / 2;
            }
            else
            {
                WriteLine("전투에서 패배하셨습니다.");
                curHP -= monsterHP * 2;
            }
                ContinueToEnter();
            Die();
        }

        static void GameEnd()
        {
            Clear();
            WriteLine("마침내 당신은 무기를 최종 강화하고 마왕을 쓰러뜨렸습니다.");
            Thread.Sleep(5000);
            Clear();
            WriteLine("이제 세상은 평화로워질 것입니다.");
            Thread.Sleep(5000);
            Clear();
            WriteLine("Game End");
            WriteLine("플레이 해주셔서 감사합니다.");
            Thread.Sleep(5000);

            Environment.Exit(1);
        }

        static void Die()
        {
            Clear();
            if(curHP <= 0)
            {
                WriteLine("당신은 사망하셨습니다.");
                Thread.Sleep(2000);
                WriteLine("Bad End...");
                Thread.Sleep(3000);
                Environment.Exit(1);
            }
        }
    }
}
