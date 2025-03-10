using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using static System.Console;

namespace 모험가키우기
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();

            int gold = 500;
            int health = 100;
            int power = 10;
            int input;
            bool isAlive = true;

            WriteLine("모험가 키우기");
            Thread.Sleep(1000);

            while(isAlive)
            {
                Clear();
                WriteLine($"현재 상태 : 체력 {health} | 골드 {gold} | 공격력 {power}");
                WriteLine("1. 탐험하기 🏕️");
                WriteLine("2. 장비 뽑기 🎲 (1000골드)");
                WriteLine("3. 휴식하기 💤 (체력 + 20)");
                WriteLine("4. 게임 종료");
                Write("입력 : ");

                input = int.Parse(ReadLine());

                if (input == 1)
                {
                    Clear();
                    WriteLine("탐험을 떠납니다.");
                    Thread.Sleep(500);
                    Clear();
                    WriteLine("탐험을 떠납니다..");
                    Thread.Sleep(500);
                    Clear();
                    WriteLine("탐험을 떠납니다...");
                    Thread.Sleep(500);
                    Clear();
                    WriteLine("탐험을 떠납니다....");

                    int eventChance = rand.Next(1, 101);

                    if (eventChance <= 30)
                    {
                        int damage = rand.Next(5, 21);
                        WriteLine($"몬스터를 만났습니다! (체력 - {damage})");
                        health -= damage;
                    }
                    else if (eventChance <= 70)
                    {
                        int reward = rand.Next(100, 301);
                        WriteLine($"💰 보물을 발견했습니다! (+{reward} 골드)");
                        gold += reward;
                    }
                    else
                    {
                        int heal = rand.Next(10, 31);
                        WriteLine($"🌿 신비한 약초를 발견했습니다! (+{heal} 체력)");
                        health += heal;
                    }

                    if (health <= 0)
                    {
                        WriteLine("\n 체력이 0이 되어 사망했습니다... 게임 오버!");
                        isAlive = false;
                    }
                    ReadLine();
                }
                else if (input == 2)
                {
                    if(gold >= 1000)
                    {
                        gold -= 1000;
                        Clear();
                        WriteLine("🎲 장비를 뽑습니다...");
                        Thread.Sleep(1000);

                        int rnd = rand.Next(1, 101);

                        if(rnd ==1)
                        {
                            WriteLine("SSS급 전설의 검 (공격력 +50) 획득!");
                            power += 50;
                        }
                        else if (rnd <= 10)
                        {
                            WriteLine("SS급 희귀한 검 (공격력 +30) 획득!");
                            power += 30;
                        }
                        else if (rnd <= 30)
                        {
                            WriteLine("S급 강철 검 (공격력 +20) 획득!");
                            power += 20;
                        }
                        else
                        {
                            WriteLine("녹슨칼 (공격력 +5) 획득!");
                            power += 5;
                        }
                    }
                    else
                    {
                        WriteLine("골드가 부족합니다. (1000골드 필요!)");
                        Thread.Sleep(1000);
                    }
                    ReadLine();
                }
                else if (input == 3)
                {
                    WriteLine("휴식을 취합니다...(체력+20)");
                    health += 20;
                    Thread.Sleep(1000);
                }
                else if (input ==4)
                {
                    WriteLine("게임을 종료합니다.");
                    Environment.Exit(1);
                }
                else
                {
                    WriteLine("잘못된 입력입니다. 다시 선택해 주세요.");
                    Thread.Sleep(1000);
                }
            }
        }
    }
}
