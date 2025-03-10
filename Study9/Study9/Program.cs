using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study9
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("캐릭터를 선택하세요. 1.검사, 2.마법사, 3.도적");
            //int choose = int.Parse(Console.ReadLine());

            //string name;
            //int att;
            //int def;

            //switch(choose)
            //{
            //    case 1:
            //        name = "검사"; att = 100; def = 90;
            //        break;
            //    case 2:
            //        name = "마법사"; att = 110; def = 80;
            //        break;
            //    case 3:
            //        name = "도적"; att = 115; def = 70;
            //        break;
            //    default:
            //        name = "오류"; att = 0; def = 0;
            //        Console.WriteLine("범위를 벗어났습니다.");
            //        break;
            //}

            //Console.WriteLine($"직업 : {name}");
            //Console.WriteLine($"공격력 : {att}");
            //Console.WriteLine($"방어력 : {def}");

            //int sum = 0;
            //for(int i = 0; i < 11; i++)
            //{
            //    sum += i;
            //}
            //    Console.WriteLine(sum);

            Random rand = new Random();
            while(true)
            {
                double f = rand.NextDouble();
                Console.WriteLine(f);
                string s = Console.ReadLine();
                if (int.Parse(s) == 1)
                {
                    break;
                }
            }
        }
    }
}
