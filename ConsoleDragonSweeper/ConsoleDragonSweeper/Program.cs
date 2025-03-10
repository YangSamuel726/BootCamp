using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using static System.Console;
using static System.Net.Mime.MediaTypeNames;
using System.Security.Cryptography;

namespace ConsoleDragonSweeper
{
    class Program
    {
        static Game Manager;
        static void Main(string[] args)
        {
            CursorVisible = false;
            SetWindowSize(100, 35);
            SetBufferSize(100, 35);

            // 타이틀 화면 재생

            ReadLine();

            // 선택 창 재생(바로 게임시작할지 룰을 읽어볼지)
            WriteLine("드래곤 스위퍼 게임에 오신 것을 환영합니다!");
            Thread.Sleep(3000);
            WriteLine("당신은 이제 드래곤의 둥지를 탐험하게 될 것입니다.");
            Thread.Sleep(3000);
            WriteLine("부디 드래곤을 무찌르고 무사히 돌아오시길 바랍니다.");
            Thread.Sleep(3000);

            while (true)
            {
                Clear();
                WriteLine("숫자를 입력하여 행동을 결정하세요.");
                WriteLine("1. 탐험 출발하기");
                WriteLine("2. 게임 규칙보기");
                WriteLine("3. 게임 종료하기");

                switch (GetInput())
                {
                    case ConsoleKey.D1: StartGame(); break;
                    case ConsoleKey.D2: ShowRule(); break;
                    case ConsoleKey.D3: GameExit(); break;
                    default: Clear(); WriteLine("잘못된 입력입니다. 다시 입력해주세요"); ContinueToEnter(); break;
                }

                // 로딩 창 화면 재생

                // 인게임 진입(지뢰판 화면과 키 입력 안내, 몬스터 도감)
            }

        }

        static void StartGame()
        {
            bool isReset = true;
            while (isReset)
            {
                Clear();
                Manager = new Game();
                Manager.SettingMonster();

                //for(int i = 0; i < 13; i++)
                //{
                //    for(int j = 0; j < 13; j++)
                //    {
                //        Write(Manager.blockGround[j, i, 0] == null);
                //    }
                //    WriteLine();
                //}
                //ContinueToEnter();

                Clear();
                Manager.DrawBlockGround();

                while (true)
                {
                    Manager.Move();
                    Manager.SumAgain();
                    Manager.DrawBlockGround();

                    if (Game.isEnd == true)
                    {
                        break;
                    }
                    if (Manager.player.isDead == true)
                    {
                        for (int i = 0; i < 13; i++)
                        {
                            for (int j = 0; j < 13; j++)
                            {
                                Manager.blockGround[i, j, 0].isChoosed = true;
                            }
                        }
                        Clear();
                        Manager.DrawBlockGround();
                        ContinueToEnter();
                        break;
                    }
                }

                if (Game.isEnd == true)
                {
                    Clear();
                    Game.isEnd = false;
                    WriteLine("당신은 모든 위협을 이겨내고 드래곤을 무찔렀습니다!");
                    Thread.Sleep(1000);
                    WriteLine("Win!");
                    Thread.Sleep(1000);
                    WriteLine($"획득한 점수 : {Manager.player.score} / 365");
                    Thread.Sleep(1000);
                    WriteLine($"레벨 : {Manager.player.level}");
                    Thread.Sleep(5000);
                    Clear();
                    WriteLine("플레이 해주셔서 감사합니다!");
                    WriteLine("다시 시작하시려면 R키를 눌러주세요.");
                    switch (GetInput())
                    {
                        case ConsoleKey.R: break;
                        default: isReset = false; break;
                    }
                }

                if (Manager.player.isDead == true)
                {
                    Clear();
                    WriteLine("적에게 당해 사망하셨습니다!");
                    Thread.Sleep(1000);
                    WriteLine("다시 시작하시려면 R키를 눌러주세요.");
                    switch (GetInput())
                    {
                        case ConsoleKey.R: break;
                        default: isReset = false; break;
                    }
                }
            }
        }

        static void ShowRule()
        {
            Clear();
            WriteLine("게임 규칙에 대해서 설명해 드리겠습니다!");
            ContinueToEnter();

            Clear();
            WriteLine("기본적으로 처음에는 모든 칸이 가려져 있습니다.");
            WriteLine("유일하게 주어진 정보는 드래곤의 위치와 처음 시작 지점입니다.");
            ContinueToEnter();

            Clear();
            WriteLine("빨간 글씨는 적의 위치이며 적의 데미지를 표시합니다.");
            WriteLine("하얀 글씨는 자신 주변 적의 데미지의 총합을 나타냅니다.");
            WriteLine("");
            ContinueToEnter();

            Clear();
            WriteLine("블록을 선택(K)하면 그 안에 있는 것에 따라 결과가 다릅니다.");
            WriteLine("블록 안에는 몬스터, 아이템, 일반 블록이 들어있습니다.");
            ContinueToEnter();

            Clear();
            WriteLine("선택한 자리에 몬스터가 있으면 그 즉시 몬스터의 피해량만큼 피해를 입습니다.");
            WriteLine("만약 플레이어가 살았남았다면 선택한 자리에 경험치 아이템이 남습니다.");
            WriteLine("특정 몬스터는 죽어서 경험치 아이템과 또 다른 특수 아이템을 남깁니다.");
            WriteLine("몬스터가 없어진 자리에는 일반 블록이 생깁니다.");
            ContinueToEnter();

            Clear();
            WriteLine("선택한 자리에 아이템이 있으면 다시 한번 선택하여 그 아이템을 사용할 수 있습니다.");
            WriteLine("아이템의 종류에는 다음것들이 있습니다.");
            WriteLine("경험치 아이템 : ${경험치}");
            WriteLine("회복 아이템 : ▷♥◁");
            WriteLine("상자 아이템 : ▤▣▤");
            WriteLine("몬스터 제거 후 나온 아이템 : ⊙※⊙");
            WriteLine("천리안 아이템 : ○◎○");
            WriteLine("승리 아이템 : §▲§");
            WriteLine("승리 아이템은 드래곤을 무찔러야만 생깁니다.");
            ContinueToEnter();

            Clear();
            WriteLine("플레이어는 경험치를 획득하여 레벨업(L)을 할 수 있습니다.");
            WriteLine("레벨업을 하면 그 즉시 피가 MaxHP로 회복됩니다.");
            WriteLine("(HP가 얼마나 남았든지 MaxHP가 되므로 HP를 알뜰하게 사용하시는 걸 추천합니다.)");
            WriteLine("(HP가 0이어도 살아있는 상태입니다! 0 아래로 내려가지만 않으면 됩니다.)");
            ContinueToEnter();

            Clear();
            WriteLine("WASD로 움직입니다.");
            WriteLine("J로 메모합니다.");
            WriteLine("K로 블록을 선택합니다.");
            WriteLine("L로 레벨업 합니다.(충분한 경험치가 있을 경우)");
            ContinueToEnter();

            Clear();
            WriteLine("위의 알려드린 것 외에도 이 게임에는 규칙성이 있습니다.");
            WriteLine("그 규칙들을 알게되면 조금더 플레이 하시는데 수월하게 되실 겁니다.");
            ContinueToEnter();
        }

        static void GameExit()
        {
            Clear();
            WriteLine("게임을 종료합니다. 안녕히 가십시요. :)");
            Environment.Exit(1);
        }

        static ConsoleKey GetInput()
        {
            ConsoleKeyInfo keyInfo = ReadKey();
            return keyInfo.Key;
        }

        static void ContinueToEnter()
        {
            WriteLine("아무키나 눌러서 진행하세요.");
            ReadKey();
        }
    }

    class Game
    {
        public static bool isEnd = false;
        public Block[,,] blockGround = new Block[13, 13, 3];
        public Player player = new Player();

        public void DrawBlockGround()
        {
            for (int y = 0; y < 27; y++)
            {
                for (int x = 0; x < 27; x++)
                {
                    if (x >= player.pos.Item1 * 2 && x <= player.pos.Item1 * 2 + 2 && y >= player.pos.Item2 * 2 && y <= player.pos.Item2 * 2 + 2)
                    { ForegroundColor = ConsoleColor.Red; }
                    if (y == 0) // 첫 줄인 경우
                    {
                        if (x == 0) { Write("┌"); }
                        else if (x == 26) { Write("┐"); }
                        else if (x % 2 == 1) { Write("───"); }
                        else { Write("┬"); }
                    }
                    else if (y == 26)
                    {
                        if (x == 0) { Write("└"); }
                        else if (x == 26) { Write("┘"); }
                        else if (x % 2 == 1) { Write("───"); }
                        else { Write("┴"); }
                    }
                    else if (y % 2 == 1)
                    {
                        if (x % 2 == 1) // 블록 내용 프린트 할것
                        {
                            blockGround[x / 2, y / 2, 0].PrintBlock();
                        }
                        else { Write("│"); }
                    }
                    else
                    {
                        if (x == 0) { Write("├"); }
                        else if (x == 26) { Write("┤"); }
                        else if (x % 2 == 1) { Write("───"); }
                        else { Write("┼"); }
                    }
                    ResetColor();
                }
                WriteLine();
            }

            WriteLine($"체력 : {player.curHP} / {player.maxHP} | 경험치 : {player.curExp} / {player.maxExp}");
            WriteLine("조작 방법 : WASD(이동) | J(메모) | K(선택) | L(레벨업)");
        }

        public void Move()
        {
            switch (GetInput())
            {
                case ConsoleKey.W: Clear(); if (player.pos.Item2 > 0) { player.pos.Item2--; } break;
                case ConsoleKey.A: Clear(); if (player.pos.Item1 > 0) { player.pos.Item1--; } break;
                case ConsoleKey.S: Clear(); if (player.pos.Item2 < 12) { player.pos.Item2++; } break;
                case ConsoleKey.D: Clear(); if (player.pos.Item1 < 12) { player.pos.Item1++; } break;
                case ConsoleKey.J: Note(player.pos.Item1, player.pos.Item2); break;
                case ConsoleKey.K: Clear(); Choose(player.pos.Item1, player.pos.Item2); break;
                case ConsoleKey.L: Clear(); player.LevelUpCheck(); break;
                default: Clear(); break;
            }
        }

        public void SumAgain()
        {
            for (int y = 0; y < 13; y++)
            {
                for (int x = 0; x < 13; x++)
                {
                    blockGround[x, y, 0].AroundSum(x, y);
                }
            }
        }

        public void Choose(int x, int y)
        {
            Block block = blockGround[x, y, 0];
            if (block is Item)
            {
                Item item = (Item)block;
                if (item.isChoosed == true)
                {
                    item.Using(player);
                }
            }
            else if (block is Monster)
            {
                Monster monster = (Monster)block;
                monster.Attack(player);
            }
            block.isChoosed = true;
        }
        public void Note(int x, int y)
        {
            string s = "";
            SetCursorPosition(60, 3);
            Write("키를 입력하여 메모하세요.");
            SetCursorPosition(60, 4);
            Write("'`'키(숫자키 1 왼쪽) : '*'(별표)");
            SetCursorPosition(60, 5);
            Write("0~9 : (숫자메모)");
            SetCursorPosition(60, 6);
            Write("'-'키 : 10 (숫자 메모)");
            SetCursorPosition(60, 7);
            Write("'='키 : 11 (숫자 메모)");
            SetCursorPosition(60, 8);
            Write("메모를 지우려면 U키를 눌러주세요.");
            SetCursorPosition(60, 9);
            Write("취소하시려면 J키를 눌러주세요.");
            switch(GetInput())
            {
                case ConsoleKey.D0: s = " 0 "; break;
                case ConsoleKey.D1: s = " 1 "; break;
                case ConsoleKey.D2: s = " 2 "; break;
                case ConsoleKey.D3: s = " 3 "; break;
                case ConsoleKey.D4: s = " 4 "; break;
                case ConsoleKey.D5: s = " 5 "; break;
                case ConsoleKey.D6: s = " 6 "; break;
                case ConsoleKey.D7: s = " 7 "; break;
                case ConsoleKey.D8: s = " 8 "; break;
                case ConsoleKey.D9: s = " 9 "; break;
                case ConsoleKey.Subtract: s = " 10"; break;
                case ConsoleKey.OemPlus: s = " 11"; break;
                case ConsoleKey.Oem3: s = " * "; break;
                case ConsoleKey.U: blockGround[x, y, 0].isNoted = false; Clear(); return;
                case ConsoleKey.J: Clear(); return;
            }
            blockGround[x, y, 0].note = s;
            blockGround[x, y, 0].isNoted = true;
            Clear();
        }

        public ConsoleKey GetInput()
        {
            ConsoleKeyInfo Key = ReadKey();
            return Key.Key;
        }

        public void SettingMonster()
        {
            Random rand = new Random();
            List<(int, int)> aroundPos;
            (int, int) pos;
            int count = 0;
            int i;
            int x;
            int y;


            // 드래곤 배치
            blockGround[6, 6, 0] = new SpecialMonster("드래곤", 13, 13, new WinItem("승리", "§▲§"));
            blockGround[6, 6, 0].isShowed = true;
            InitBlock(6, 6);
            WriteLine("드래곤 배치 완료");

            // 드래곤 알 배치
            aroundPos = GetEmptyAround(6, 6);
            pos = aroundPos[rand.Next(0, aroundPos.Count)];
            blockGround[pos.Item1, pos.Item2, 0] = new Monster("용의 알", 0, 3);
            InitBlock(pos.Item1, pos.Item2);
            WriteLine("드래곤 알 배치 완료");

            // 첫 천리안 아이템 배치
            i = rand.Next(0, 4); // 어느 한 축을 0 아니면 12로 만들지 결정할 값을 랜덤으로 도출
            if (i == 0) { x = 3; y = rand.Next(3, 9); }
            else if (i == 1) { x = 9; y = rand.Next(3, 9); }
            else if (i == 2) { x = rand.Next(3, 9); y = 3; }
            else { x = rand.Next(3, 9); y = 9; }
            Item item = new FirstItem("시작 지점", "○◎○");
            blockGround[x, y, 0] = item;
            item.isShowed = true;
            item.isChoosed = true;
            InitBlock(x, y);
            WriteLine("시작 지점 배치 완료");

            // 지뢰 몬스터 배치
            x = rand.Next(0, 2) == 0 ? 0 : 12;
            y = rand.Next(0, 2) == 0 ? 0 : 12;
            blockGround[x, y, 0] = new SpecialMonster("지뢰병", 10, 10, new MineItem("지뢰 제거 아이템", "⊙※⊙"));
            InitBlock(x, y);
            WriteLine("지뢰 몬스터 배치 완료");

            //슬라임마녀 배치
            i = rand.Next(0, 4); // 어느 한 축을 0 아니면 12로 만들지 결정할 값을 랜덤으로 도출
            if (i == 0) { x = 0; y = rand.Next(2, 10); }
            else if (i == 1) { x = 12; y = rand.Next(2, 10); }
            else if (i == 2) { x = rand.Next(2, 10); y = 0; }
            else { x = rand.Next(2, 10); y = 12; }
            blockGround[x, y, 0] = new SpecialMonster("슬라임 마녀", 1, 1, new SlimeItem("슬라임 위치 아이템", "⊙※⊙"));
            InitBlock(x, y);
            WriteLine("슬라임 마녀 배치 완료");

            // 슬라임 마녀 주변에 정예 슬라임 생성
            aroundPos = GetEmptyAround(x, y);
            for (int a = 0; a < aroundPos.Count; a++)
            {
                blockGround[aroundPos[a].Item1, aroundPos[a].Item2, 0] = new Monster("정예 슬라임", 8, 8);
                InitBlock(aroundPos[a].Item1, aroundPos[a].Item2);
            }
            WriteLine("정예 슬라임 배치 완료");

            // 커플 몬스터 배치
            while (true)
            {
                pos = GetEmpty(1, 11);
                (int, int) pos2 = (12 - pos.Item1, pos.Item2);
                if (blockGround[pos2.Item1, pos2.Item2, 0] == null && (pos.Item1 != 6 || pos.Item2 != 6)) // 특정 위치 반대편도 공백이고 드래곤 위치가 아니라면
                {
                    blockGround[pos.Item1, pos.Item2, 0] = new SpecialMonster("커플 몬스터", 9, 9, new HPItem("회복 아이템", "▷♥◁"));
                    InitBlock(pos.Item1, pos.Item2);

                    blockGround[pos2.Item1, pos2.Item2, 0] = new SpecialMonster("커플 몬스터", 9, 9, new HPItem("회복 아이템", "▷♥◁"));
                    InitBlock(pos2.Item1, pos2.Item2);

                    break;
                }
            }
            WriteLine("커플 몬스터 배치 완료");

            // 쌍둥이 악마 배치
            while (true)
            {
                pos = GetEmpty(0, 13);

                if (blockGround[pos.Item1, pos.Item2, 0] == null && CheckCrossAround(pos.Item1, pos.Item2))
                {
                    // 첫 쌍둥이 배치
                    blockGround[pos.Item1, pos.Item2, 0] = new Monster("쌍둥이 악마", 4, 4, false);
                    InitBlock(pos.Item1, pos.Item2);

                    // 두번째 쌍둥이 배치
                    aroundPos = GetEmptyCrossAround(pos.Item1, pos.Item2);
                    (int, int) another = aroundPos[rand.Next(0, aroundPos.Count)];
                    blockGround[another.Item1, another.Item2, 0] = new Monster("쌍둥이 악마", 4, 4, false);
                    InitBlock(another.Item1, another.Item2);
                    count++;
                    if (count >= 4) { count = 0; break; }
                }
            }
            WriteLine("쌍둥이 악마 배치 완료");


            // 상자 수비병 배치가 될 때까지 반복
            count = 0;
            while (true)
            {
                pos = GetEmpty(0, 13);

                if (blockGround[pos.Item1, pos.Item2, 0] == null && CheckAround(pos.Item1, pos.Item2))
                {
                    // 상자 수비병 배치
                    blockGround[pos.Item1, pos.Item2, 0] = new Monster("상자 수비병", 6, 6, false);
                    InitBlock(pos.Item1, pos.Item2);

                    // 상자 배치
                    aroundPos = GetEmptyAround(pos.Item1, pos.Item2);
                    (int, int) box = aroundPos[rand.Next(0, aroundPos.Count)];
                    blockGround[box.Item1, box.Item2, 0] = new BoxItem("보물상자", "▤▣▤");
                    InitBlock(box.Item1, box.Item2);

                    count++;
                    if (count >= 5) { count = 0; break; }
                }
            }
            WriteLine("상자 수비병 배치 완료");

            // 쥐들의 왕 배치
            pos = GetEmpty(0, 13);
            blockGround[pos.Item1, pos.Item2, 0] = new SpecialMonster("쥐들의 왕", 5, 5, new MouseItem("쥐 위치 추적기", "⊙※⊙"));
            InitBlock(pos.Item1, pos.Item2);
            WriteLine("쥐들의 왕 배치 완료");

            // 천리안 아이템 배치
            pos = GetEmpty(0, 13);
            blockGround[pos.Item1, pos.Item2, 0] = new ShowItem("천리안", "○◎○");
            InitBlock(pos.Item1, pos.Item2);
            WriteLine("천리안 아이템 배치 완료");

            // 회복 아이템 배치
            while (true)
            {
                pos = GetEmpty(0, 13);
                blockGround[pos.Item1, pos.Item2, 0] = new HPItem("회복", "▷♥◁");
                InitBlock(pos.Item1, pos.Item2);
                count++;
                if (count >= 5) { count = 0; break; }
            }
            WriteLine("회복 아이템 배치 완료");

            // 함정 박스 배치
            pos = GetEmpty(0, 13);
            blockGround[pos.Item1, pos.Item2, 0] = new Mimic("미믹", 11, 11);
            InitBlock(pos.Item1, pos.Item2);
            WriteLine("함정 보물 상자 배치 완료");

            // 악마 검사 배치
            while (true)
            {
                pos = GetEmpty(0, 13);
                blockGround[pos.Item1, pos.Item2, 0] = new Monster("악마 검사", 7, 7);
                InitBlock(pos.Item1, pos.Item2);
                count++;
                if (count >= 4) { count = 0; break; }
            }
            WriteLine("악마 검사 배치 완료");

            // 일반 슬라임 배치
            while (true)
            {
                pos = GetEmpty(0, 13);
                blockGround[pos.Item1, pos.Item2, 0] = new Monster("일반 슬라임", 5, 5);
                InitBlock(pos.Item1, pos.Item2);
                count++;
                if (count >= 8) { count = 0; break; }
            }
            WriteLine("일반 슬라임 배치 완료");

            // 스켈레톤 병사 배치
            while (true)
            {
                pos = GetEmpty(0, 13);
                blockGround[pos.Item1, pos.Item2, 0] = new Monster("스켈레톤 병사", 3, 3);
                InitBlock(pos.Item1, pos.Item2);
                count++;
                if (count >= 10) { count = 0; break; }
            }
            WriteLine("스켈레톤 병사 배치 완료");

            // 박쥐 배치
            while (true)
            {
                pos = GetEmpty(0, 13);
                blockGround[pos.Item1, pos.Item2, 0] = new Monster("박쥐", 2, 2);
                InitBlock(pos.Item1, pos.Item2);
                count++;
                if (count >= 12) { count = 0; break; }
            }
            WriteLine("박쥐 배치 완료");

            // 쥐 배치
            while (true)
            {
                pos = GetEmpty(0, 13);
                blockGround[pos.Item1, pos.Item2, 0] = new Monster("쥐", 1, 1);
                InitBlock(pos.Item1, pos.Item2);
                count++;
                if (count >= 13) { count = 0; break; }
            }
            WriteLine("쥐 배치 완료");

            // 지뢰 배치
            while (true)
            {
                pos = GetEmpty(0, 13);
                blockGround[pos.Item1, pos.Item2, 0] = new Monster("지뢰", 100, 3);
                InitBlock(pos.Item1, pos.Item2);
                count++;
                if (count >= 13) { count = 0; break; }
            }
            WriteLine("지뢰 배치 완료");

            // 나머지 블럭 빈 블럭으로 채우기
            aroundPos = new List<(int, int)>();
            for (int a = 0; a < 13; a++)
            {
                for (int b = 0; b < 13; b++)
                {
                    if (blockGround[a, b, 0] == null)
                    {
                        aroundPos.Add((a, b));
                    }
                }
            }
            int sum = 0;
            foreach ((int, int) xy in aroundPos)
            {
                blockGround[xy.Item1, xy.Item2, 0] = new Block("-");
                InitBlock(xy.Item1, xy.Item2);
                sum++;
            }
            WriteLine(aroundPos.Count);
            WriteLine(sum);
            WriteLine("빈공간 블록 배치 완료");

            WriteLine("오류 없이 배치완료");
        }

        void InitBlock(int x, int y)
        {
            blockGround[x, y, 0].blockGround = blockGround;
            blockGround[x, y, 0].myPosition = (x, y);
        }

        bool CheckAround(int x, int y) // 특정 위치 주위에 빈 공간이 하나라도 있으면 true 반환
        {
            if (x - 1 >= 0 && y - 1 >= 0 && blockGround[x - 1, y - 1, 0] == null) { return true; }
            if (y - 1 >= 0 && blockGround[x, y - 1, 0] == null) { return true; }
            if (x + 1 <= 12 && y - 1 >= 0 && blockGround[x + 1, y - 1, 0] == null) { return true; }
            if (x - 1 >= 0 && blockGround[x - 1, y, 0] == null) { return true; }
            if (x + 1 <= 12 && blockGround[x + 1, y, 0] == null) { return true; }
            if (x - 1 >= 0 && y + 1 <= 12 && blockGround[x - 1, y + 1, 0] == null) { return true; }
            if (y + 1 <= 12 && blockGround[x, y + 1, 0] == null) { return true; }
            if (x + 1 <= 12 && y + 1 <= 12 && blockGround[x + 1, y + 1, 0] == null) { return true; }
            return false;

            //for(int a = -1; a < 2; x++)
            //{
            //    for(int b = -1; b < 2; y++)
            //    {
            //        if(a == 0 && b == 0) { continue; }
            //        if((x + a >= 0 && x+a <= 12) && (y + b >= 0 && y + b <= 12))
            //        {
            //            if (blockGround[x + a, y + b, 0] == null)
            //            {
            //                return true;
            //            }
            //        }
            //    }
            //}
            //return false;
        }

        bool CheckCrossAround(int x, int y) // 특정 좌표를 중심으로 십자 모양 범위에 한칸이라도 빈곳이 있으면 true 반환
        {
            if (y - 1 >= 0 && blockGround[x, y - 1, 0] == null) { return true; }
            if (x - 1 >= 0 && blockGround[x - 1, y, 0] == null) { return true; }
            if (x + 1 <= 12 && blockGround[x + 1, y, 0] == null) { return true; }
            if (y + 1 <= 12 && blockGround[x, y + 1, 0] == null) { return true; }
            WriteLine("?");
            return false;
        }

        List<(int, int)> GetEmptyAround(int x, int y) // 특정 좌표 주의의 빈 공간을 반환하는 함수
        {
            List<(int, int)> arr = new List<(int, int)>();
            for (int a = -1; a < 2; a++)
            {
                for (int b = -1; b < 2; b++)
                {
                    if (a == 0 && b == 0) { continue; }
                    if ((x + a >= 0 && x + a <= 12) && (y + b >= 0 && y + b <= 12))
                    {
                        if (blockGround[x + a, y + b, 0] == null)
                        {
                            arr.Add((x + a, y + b));
                        }
                    }
                }
            }
            return arr;
        }

        List<(int, int)> GetEmptyCrossAround(int x, int y)
        {
            List<(int, int)> arr = new List<(int, int)>();
            if (y - 1 >= 0 && blockGround[x, y - 1, 0] == null) { arr.Add((x, y - 1)); }
            if (x - 1 >= 0 && blockGround[x - 1, y, 0] == null) { arr.Add((x - 1, y)); ; }
            if (x + 1 <= 12 && blockGround[x + 1, y, 0] == null) { arr.Add((x + 1, y)); }
            if (y + 1 <= 12 && blockGround[x, y + 1, 0] == null) { arr.Add((x, y + 1)); }
            return arr;
        }

        (int, int) GetEmpty(int a, int b) // 특정 범위내의 빈공간 중 하나를 가져오는 함수
        {
            List<(int, int)> arr = new List<(int, int)>();
            Random rand = new Random();
            for (int x = a; x < b; x++)
            {
                for (int y = a; y < b; y++)
                {
                    if (blockGround[x, y, 0] == null)
                    {
                        arr.Add((x, y));
                    }
                }
            }
            return arr[rand.Next(0, arr.Count)];
        }
    }

    class Player
    {
        public int maxHP = 5;
        public int curHP = 5;
        public int level = 1;
        public int maxExp = 4;
        public int curExp = 0;
        public int score = 0;
        public bool isDead = false;
        public (int, int) pos = (0, 0);


        public void LevelUp()
        {
            // 레벨에 따라 maxHP를 조정하고 curHP를 회복시켜주는 함수
            level++; // 레벨을 상승시킴
            curExp -= maxExp; // 레벨업에 필요한 경험치량만큼 현재 경험치를 차감시킴
            maxExp = LevelUpMaxExp(); // maxHP를 레벨에 따라 증가시킴
            maxHP = 5 + level / 2 - (level+1) % 2;
            Heal(); // 체력을 가득 채워 줌
        }

        public void LevelUpCheck()
        {
            if (curExp < maxExp) { return; } // 경험치가 부족하면 리턴시킴
            LevelUp();
        }

        public void EatEXP(int _exp)
        {
            curExp += _exp;
            score += _exp;
        }

        public void Damaged(int _damage)
        {
            curHP -= _damage;
            DeathCheck();
        }

        public void DeathCheck()
        {
            if (curHP < 0) { isDead = true; }
        }

        public void Heal()
        {
            curHP = maxHP;
        }

        public int LevelUpMaxExp()
        {
            if (level == 1) { return 4; }
            else if (level == 2) { return 5; }
            else if (level == 3) { return 7; }
            else if (level == 4) { return 9; }
            else if (level == 5) { return 9; }
            else if (level == 6) { return 10; }
            else if (level == 7) { return 12; }
            else if (level == 8) { return 12; }
            else if (level == 9) { return 12; }
            else if (level == 10) { return 15; }
            else if (level == 11) { return 18; }
            else if (level == 12) { return 21; }
            else if (level == 13) { return 21; }
            else { return 25; }
        }
    }

    class Block
    {
        public bool isChoosed = false;
        public bool isShowed = false;
        public string name;
        public Block[,,] blockGround;
        public (int x, int y) myPosition;
        public int aroundSum;
        public bool isNoted = false;
        public string note = "";

        public Block(string _name)
        {
            name = _name;
        }

        public virtual void PrintBlock()
        {
            if (isShowed == false && isNoted == true && isChoosed == false && note.Length != 0)
            {
                ResetColor();
                BackgroundColor = ConsoleColor.White;
                ForegroundColor = ConsoleColor.Blue;
                for (int i = 0; i < 3 - note.Length; i++)
                {
                    Write(" ");
                }
                Write(note);
                ResetColor();
            }
            else if (isChoosed == false && isShowed == false) // 맨 처음 상태
            {
                ResetColor();
                BackgroundColor = ConsoleColor.White;
                Write("   ");
                ResetColor();
            }
            else if (isChoosed == true && isShowed == false) // 보이지 않은 상태에서 선택한 경우
            {
                ResetColor();
                for (int i = 0; i < 3 - aroundSum.ToString().Length; i++)
                {
                    Write(" ");
                }
                Write(aroundSum);
                ResetColor();
            }
            else if (isShowed == true && isChoosed == true) // 보이고 선택한 경우
            {
                ResetColor();
                for (int i = 0; i < 3 - aroundSum.ToString().Length; i++)
                {
                    Write(" ");
                }
                Write(aroundSum);
                ResetColor();
            }
            else if (isChoosed == false && isShowed == true) // 보이지만 선택하지 않은 경우
            {
                ResetColor();
                for (int i = 0; i < 3 - aroundSum.ToString().Length; i++)
                {
                    Write(" ");
                }
                Write(aroundSum);
                ResetColor();
            }
        }

        public void AroundSum(int x, int y)
        {
            int i = 0;
            for (int a = -1; a < 2; a++)
            {
                for (int b = -1; b < 2; b++)
                {
                    if (a == 0 && b == 0) { continue; }
                    if ((x + a >= 0 && x + a <= 12) && (y + b >= 0 && y + b <= 12))
                    {
                        if (blockGround[x + a, y + b, 0] is Monster)
                        {
                            Monster monster = (Monster)blockGround[x + a, y + b, 0];
                            i += monster.hp == 0 ? 0 : monster.damage;

                        }
                    }
                }
            }
            aroundSum = i;
        }
    }

    class Monster : Block
    {
        public int damage;
        public int hp = 1;
        bool isSpecial;
        public Item expItem;

        public Monster(string _name, int _damage, int _exp, bool _isSpecial = false) : base(_name)
        {
            damage = _damage;
            expItem = new EXPItem("몬스터 경험치", _exp.ToString().Length == 1 ? "$ " + _exp : "$" + _exp, _exp);

        }

        public virtual void Attack(Player player)
        {
            if (damage == 0)
            {
                SetCursorPosition(0, 31);
                ForegroundColor = ConsoleColor.Blue;
                WriteLine($"{name}을 발견했습니다!.");
                ResetColor();
                SetCursorPosition(0, 0);
            }
            else
            {
                SetCursorPosition(0, 31);
                ForegroundColor = ConsoleColor.Blue;
                WriteLine($"{name}이(가) 당신을 공격했습니다!");
                ResetColor();
                SetCursorPosition(0, 0);
            }

            player.Damaged(damage);
            if (player.isDead == true) { return; }
            else
            {
                hp--;
                expItem.blockGround = blockGround;
                expItem.myPosition = myPosition;
                expItem.isChoosed = true;
                blockGround[myPosition.x, myPosition.y, 0] = expItem;
            }
        }

        public override void PrintBlock()
        {

            if (isChoosed == false && isShowed == false)
            {
                base.PrintBlock();
            }
            else if (isChoosed == false && isShowed == true)
            {
                ForegroundColor = ConsoleColor.Red;
                for (int i = 0; i < 3 - damage.ToString().Length; i++)
                {
                    Write(" ");
                }
                Write(damage);
                ResetColor();
            }
            else if (isChoosed == true)
            {
                ForegroundColor = ConsoleColor.Red;
                for (int i = 0; i < 3 - damage.ToString().Length; i++)
                {
                    Write(" ");
                }
                Write(damage);
                ResetColor();

            }
        }
    }

    class SpecialMonster : Monster
    {
        Item specialItem;
        public SpecialMonster(string _name, int _damage, int _exp, Item _item, bool _isSpecial = true) : base(_name, _damage, _exp, _isSpecial)
        {
            specialItem = _item;
            expItem.behindItem = specialItem;
        }

        public override void Attack(Player player)
        {
            base.Attack(player);
            blockGround[myPosition.x, myPosition.y, 2] = specialItem;
        }

        public override void PrintBlock()
        {
            base.PrintBlock();
        }
    }

    class Mimic : Monster
    {
        string mimicImage = "▤▣▤";
        public Mimic(string _name, int _damage, int _exp, bool _isSpecial = true) : base(_name, _damage, _exp, _isSpecial)
        {
            hp = 2;
        }

        public override void Attack(Player player)
        {
            if (hp >= 2) { hp--; }
            else
            {
                base.Attack(player);
            }
        }

        public override void PrintBlock()
        {
            if (hp >= 2 && isChoosed == false)
            {
                base.PrintBlock();
            }
            else if (hp == 1 && isChoosed == true)
            {
                ForegroundColor = ConsoleColor.Green;
                Write(mimicImage);
                ResetColor();
            }
            else if (hp < 1 && isChoosed == true)
            {
                base.PrintBlock();
            }
            else if (hp >= 2 && isChoosed == true)
            {
                base.PrintBlock();
            }
        }
    }

    class Item : Block
    {
        public string itemImage;
        public Item behindItem;
        public Item(string _name, string _itemImage) : base(_name)
        {
            itemImage = _itemImage;
        }
        public virtual void Using(Player player)
        {
            SetCursorPosition(0, 31);
            ForegroundColor = ConsoleColor.Blue;
            WriteLine($"{name} 아이템을 사용했습니다.");
            ResetColor();
            SetCursorPosition(0, 0);

            if (behindItem == null)
            {
                Block block = new Block("-");
                blockGround[myPosition.x, myPosition.y, 0] = block;
                block.isChoosed = true;
                block.myPosition = myPosition;
                block.blockGround = blockGround;
            }
            else
            {
                blockGround[myPosition.x, myPosition.y, 0] = behindItem;
                behindItem.isChoosed = true;
                behindItem.myPosition = myPosition;
                behindItem.blockGround = blockGround;
            }
        }

        public override void PrintBlock()
        {
            if (isChoosed == false && isShowed == false)
            {
                base.PrintBlock();
            }
            else if (isChoosed == false && isShowed == true)
            {
                ForegroundColor = ConsoleColor.Green;
                Write(itemImage);
                ResetColor();
            }
            else if (isChoosed == true)
            {
                ForegroundColor = ConsoleColor.Green;
                Write(itemImage);
                ResetColor();

            }
        }
    }

    class EXPItem : Item
    {
        public int exp;

        public EXPItem(string _name, string _itemImage, int _exp) : base(_name, _itemImage)
        {
            exp = _exp;
        }

        public override void Using(Player player)
        {
            base.Using(player);
            player.EatEXP(exp);
        }

        public override void PrintBlock()
        {
            base.PrintBlock();
        }
    }

    class HPItem : Item
    {
        public HPItem(string _name, string _itemImage) : base(_name, _itemImage)
        {

        }

        public override void Using(Player player)
        {
            base.Using(player);
            player.Heal();
        }
    }

    class BoxItem : Item
    {
        static int hpItem = 0;
        static int expItem = 0;
        Item myItem;

        public BoxItem(string _name, string _itemImage) : base(_name, _itemImage)
        {
            Random rand = new Random();
            int x = 0;
            if ((hpItem < 2 && expItem < 3) || (hpItem >= 2 && expItem >= 3)) { x = rand.Next(0, 2); }
            else if (hpItem >= 2) { x = 1; }
            else if (expItem >= 3) { x = 0; }

            if (x == 0)
            {
                hpItem += 1;
                myItem = new HPItem("상자에서 나온 회복 아이템", "▷♥◁");
            }
            else
            {
                expItem += 1;
                myItem = new EXPItem("상자에서 나온 경험치", "$ 5", 5);
            }
        }

        public override void Using(Player player)
        {
            Item block = myItem;
            blockGround[myPosition.x, myPosition.y, 0] = block;
            block.isChoosed = true;
            block.myPosition = myPosition;
            block.blockGround = blockGround;
        }
    }

    class ShowItem : Item
    {
        public ShowItem(string _name, string _itemImage) : base(_name, _itemImage)
        {

        }

        public override void Using(Player player)
        {
            base.Using(player);

            Random rand = new Random();
            List<Block> arr = new List<Block>();
            for (int a = 0; a < 12; a++)
            {
                for (int b = 0; b < 12; b++)
                {
                    if (blockGround[a, b, 0].isChoosed == false)
                    {
                        arr.Add(blockGround[a, b, 0]);
                    }
                }
            }

            (int, int) pos = arr[rand.Next(0, arr.Count)].myPosition;
            for (int a = -1; a < 2; a++)
            {
                for (int b = -1; b < 2; b++)
                {
                    if ((pos.Item1 + a >= 0 && pos.Item1 + a <= 12) && (pos.Item2 + b >= 0 && pos.Item2 + b <= 12))
                    {
                        blockGround[pos.Item1 + a, pos.Item2 + b, 0].isShowed = true;

                    }
                }
            }
        }
    }

    class MineItem : Item
    {
        public MineItem(string _name, string _itemImage) : base(_name, _itemImage)
        {

        }

        public override void Using(Player player)
        {
            base.Using(player);

            List<Block> arr = new List<Block>();
            for (int a = 0; a < 12; a++)
            {
                for (int b = 0; b < 12; b++)
                {
                    if (blockGround[a, b, 0] is Monster)
                    {
                        Monster monster = (Monster)blockGround[a, b, 0];
                        if (monster.damage == 100)
                        {
                            EXPItem item = new EXPItem("지뢰 경험치", "$ 3", 3);
                            blockGround[a, b, 0] = item;
                            item.myPosition = (a, b);
                            item.blockGround = blockGround;
                        }
                    }
                }
            }
        }
    }

    class SlimeItem : Item
    {
        public SlimeItem(string _name, string _itemImage) : base(_name, _itemImage)
        {

        }

        public override void Using(Player player)
        {
            base.Using(player);

            List<Block> arr = new List<Block>();
            for (int a = 0; a < 12; a++)
            {
                for (int b = 0; b < 12; b++)
                {
                    if (blockGround[a, b, 0] is Monster)
                    {
                        Monster monster = (Monster)blockGround[a, b, 0];
                        if ((monster.damage == 5 || monster.damage == 8) && monster.name != "쥐들의 왕")
                        {
                            monster.isShowed = true;
                        }
                    }
                }
            }
        }
    }

    class MouseItem : Item
    {
        public MouseItem(string _name, string _itemImage) : base(_name, _itemImage)
        {

        }

        public override void Using(Player player)
        {
            base.Using(player);

            for (int a = 0; a < 12; a++)
            {
                for (int b = 0; b < 12; b++)
                {
                    if (blockGround[a, b, 0] is Monster)
                    {
                        Monster monster = (Monster)blockGround[a, b, 0];
                        if (monster.damage == 1)
                        {
                            monster.isShowed = true;
                        }
                    }
                }
            }
        }
    }

    class FirstItem : Item
    {
        public FirstItem(string _name, string _itemImage) : base(_name, _itemImage)
        {

        }

        public override void Using(Player player)
        {
            base.Using(player);

            for (int a = -1; a < 2; a++)
            {
                for (int b = -1; b < 2; b++)
                {
                    blockGround[myPosition.Item1 + a, myPosition.Item2 + b, 0].isChoosed = true;
                }
            }
            blockGround[myPosition.Item1 - 2, myPosition.Item2, 0].isChoosed = true;
            blockGround[myPosition.Item1 + 2, myPosition.Item2, 0].isChoosed = true;
            blockGround[myPosition.Item1, myPosition.Item2 - 2, 0].isChoosed = true;
            blockGround[myPosition.Item1, myPosition.Item2 + 2, 0].isChoosed = true;
        }
    }

    class WinItem : Item
    {
        public WinItem(string _name, string _itemImage) : base(_name, _itemImage)
        {

        }

        public override void Using(Player player)
        {
            base.Using(player);
            Game.isEnd = true;
        }
    }

    class Random
    {
        public int Next(int min, int max)
        {
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                byte[] data = new byte[4];
                rng.GetBytes(data);
                int value = BitConverter.ToInt32(data, 0) & int.MaxValue; // 양수 변환
                return min + (value % (max - min));
            }
        }
    }
}
