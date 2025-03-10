using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory
{
    class Program
    {
        static void Main(string[] args)
        {
            Inventory inven = new Inventory();

            while(true)
            {
                Console.Clear();
                Console.WriteLine("하고 싶은 활동을 정해주세요.");
                Console.WriteLine("1. 아이템 추가");
                Console.WriteLine("2. 아이템 제거");
                Console.WriteLine("3. 인벤토리 보기");

                switch(Console.ReadKey().Key)
                {
                    case ConsoleKey.D1:
                        Console.Clear();
                        Console.WriteLine("넣고 싶은 아이템과 개수를 입력해주세요.");
                        Console.Write("아이템 이름 : ");
                        string name = Console.ReadLine();
                        Console.Write("아이템 개수 : ");
                        int count = int.Parse(Console.ReadLine());
                        Inventory.AddItem(name, count);
                        break;
                    case ConsoleKey.D2:
                        Console.Clear();
                        Console.WriteLine("빼고 싶은 아이템과 개수를 입력해주세요.");
                        Console.Write("아이템 이름 : ");
                        name = Console.ReadLine();
                        Console.Write("아이템 개수 : ");
                        count = int.Parse(Console.ReadLine());
                        Inventory.RemoveItem(name, count);
                        break;
                    case ConsoleKey.D3:
                        Console.Clear();
                        Console.WriteLine("인벤토리 창을 확인합니다.");
                        Inventory.ShowInventory();
                        break;
                }
            }


        }
    }

    public struct Inventory
    {
        const int MAX_ITEMS = 10;

        //아이템 배열 (이름 저장)
        static string[] itemNames = new string[MAX_ITEMS];
        static int[] itemCounts = new int[MAX_ITEMS];


        //아이템 추가 함수
        public static void AddItem(string name, int count)
        {
            for (int i = 0; i < MAX_ITEMS; i++)
            {
                if (itemNames[i] == name)  //이미 있는 아이템이면 개수 증가
                {
                    itemCounts[i] += count;
                    return;
                }
            }

            //빈 슬롯에 새로운 아이템 추가
            for (int i = 0; i < MAX_ITEMS; i++)
            {
                if (itemNames[i] == null)
                {
                    itemNames[i] = name;
                    itemCounts[i] = count;
                    return;
                }
            }
            Console.WriteLine("인벤토리가 가득 찼습니다.");

        }

        //아이템 제거 함수
        public static void RemoveItem(string name, int count)
        {
            for (int i = 0; i < MAX_ITEMS; i++)
            {
                if (itemNames[i] == name) //이름하고 같은지
                {
                    if (itemCounts[i] >= count) //개수가 충분하면 차감
                    {
                        itemCounts[i] -= count;
                        if (itemCounts[i] == 0) //개수가 0이면 삭제
                        {
                            itemNames[i] = null;
                        }
                        return;
                    }
                    else
                    {
                        Console.WriteLine("아이템 개수가 부족합니다!");
                        return;
                    }
                }
            }

            Console.WriteLine("아이템을 찾을 수 없습니다!");

        }


        //인벤토리 출력 함수
        public static void ShowInventory()
        {
            Console.WriteLine("현재 인벤토리 : ");
            bool isEmpty = true;

            for (int i = 0; i < MAX_ITEMS; i++)
            {
                if (itemNames[i] != null)
                {
                    Console.WriteLine($"{itemNames[i]} (x{itemCounts[i]})");
                    isEmpty = false;
                }
            }

            if (isEmpty)
            {
                Console.WriteLine("인벤토리가 비어 있습니다.");
            }

            Console.ReadLine();
        }
    }
}