using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study8
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("가지고 있는 소지금을 입력하세요. : ");
            float money = float.Parse(Console.ReadLine());
            string weaponName;
            float att;

            if(money < 0) { weaponName = "무기 없음"; att = 0; }
            else if(money <= 100) { weaponName = "무한의 대검"; att = 1; }
            else if(money <= 200) { weaponName = "카타나"; att = 2; }
            else if(money <= 300) { weaponName = "진은검"; att = 3; }
            else if(money <= 400) { weaponName = "집판검"; att = 4; }
            else if(money <= 500) { weaponName = "엑스칼리버"; att = 5; }
            else if(money <= 600) { weaponName = "유령검"; att = 6; }
            else { weaponName = "전설의 검";  att = 7; }

            Console.WriteLine("캐릭터 이름 : 멋사검존");
            Console.WriteLine($"무기 이름 : {weaponName}");
            Console.WriteLine($"공격력 : 100 + {att}");
        }
    }
}
