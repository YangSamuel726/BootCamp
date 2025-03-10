using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Data;

namespace TextRPGTest
{
    class GameManager
    {
        Character player = new Character("이름 없음", 1, 0);
        public void GameStart()
        {
            Console.WriteLine("TextRPG에 오신 것을 환영합니다!");
            Thread.Sleep(1000);
            Console.WriteLine("여러 적들을 쓰러뜨리며 최강이 되시기를 바랍니다!");
            Thread.Sleep(3000);
        }

        public void ChooseMyJob()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("직업을 선택하세요!");
                Console.WriteLine("1. 전사, 2. 마법사, 3. 도둑");
                switch (GetInput())
                {
                    case ConsoleKey.D1:
                        player = new Character("전사", 200, 10); return;
                    case ConsoleKey.D2:
                        player = new Character("마법사", 150, 15); return;
                    case ConsoleKey.D3:
                        player = new Character("도둑", 100, 30); return;
                    default:
                        Console.WriteLine("잘못된 입력입니다! 다시 입력해주세요.");
                        break;
                }
            }
        }

        public void InVillage()
        {
            while(true)
            {
                Console.Clear();
                Console.WriteLine("어디로 가시겠습니까?");
                Console.WriteLine("1. 사냥터 2. 숙소 3. 종료");
                switch(GetInput())
                {
                    case ConsoleKey.D1:
                        InHuntingGround();
                        break;
                    case ConsoleKey.D2:
                        player.Heal();
                        break;
                    case ConsoleKey.D3:
                        Console.Clear();
                        Console.WriteLine("게임을 종료합니다. 안녕히 가세요. :)");
                        return;
                    default:
                        Console.Clear();
                        Console.WriteLine("잘못된 입력입니다! 다시 입력해주세요.");
                        break;
                }
            }
        }

        public void InHuntingGround()
        {
            while(true)
            {
                if(player.curHP <= 0) { return; }
                Console.Clear();
                Console.WriteLine("어떤 사냥터로 가시겠습니까?");
                Console.WriteLine("1. 초보 사냥터");
                Console.WriteLine("2. 중수 사냥터");
                Console.WriteLine("3. 고수 사냥터");
                Console.WriteLine("4. 지옥 사냥터");
                Console.WriteLine("5. 돌아가기");
                switch(GetInput())
                {
                    case ConsoleKey.D1:
                        Hunting(new Monster("슬라임", 30, 5));
                        break;
                    case ConsoleKey.D2:
                        Hunting(new Monster("오크", 80, 4));
                        break;
                    case ConsoleKey.D3:
                        Hunting(new Monster("사천왕", 120, 8));
                        break;
                    case ConsoleKey.D4:
                        Hunting(new Monster("마왕", 160, 10));
                        break;
                    case ConsoleKey.D5:
                        Console.Clear();
                        Console.WriteLine("마을로 돌아갑니다.");
                        EnterToContinue();
                        return;
                    default:
                        Console.Clear();
                        Console.WriteLine("잘못된 입력입니다! 다시 입력해주세요.");
                        break;
                }
            }
        }

        public void Hunting(Monster _monster)
        {
            Monster monster = _monster;
            while(true)
            {
                Console.Clear();
                PrintUnitInfo(player);
                PrintUnitInfo(monster);
                Console.WriteLine("다음 행동을 선택해주세요.");
                Console.WriteLine("1. 전투 2. 도망");
                switch(GetInput())
                {
                    case ConsoleKey.D1:
                        player.Attack(monster);
                        monster.Attack(player);
                        EnterToContinue();
                        break;
                    case ConsoleKey.D2:
                        Console.Clear();
                        Console.WriteLine("도망갑니다.");
                        return;
                    default:
                        Console.Clear();
                        Console.WriteLine("잘못된 입력입니다! 다시 입력해주세요.");
                        break;
                }
                if(player.curHP <= 0)
                {
                    Console.WriteLine("사망하셨습니다. ㅠㅠ");
                    EnterToContinue();
                    return;
                }
                if(monster.curHP <= 0)
                {
                    Console.WriteLine("전투에서 승리하셨습니다!");
                    EnterToContinue();
                    return;
                }
            }
        }

        public ConsoleKey GetInput()
        {
            return Console.ReadKey().Key;
        }

        public void EnterToContinue()
        {
            Console.WriteLine();
            Console.WriteLine("아무키나 눌러서 진행하세요.");
            Console.ReadKey();
        }

        public void PrintUnitInfo(Unit unit)
        {
            Console.WriteLine("=============================================");
            Console.WriteLine($"이름 : {unit.Name} | 생명력 : {unit.curHP} / {unit.HP} | 공격력 : {unit.ATT}");
            Console.WriteLine("=============================================");
        }
    }
}
