using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study12
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("무기를 선택해주세요.");
            Console.WriteLine("1. 검");
            Console.WriteLine("2. 활");
            Console.WriteLine("3. 지팡이");

            int i = int.Parse(Console.ReadLine());
            WeaponType type = WeaponType.Sword;

            switch(i)
            {
                case 1:
                    type = WeaponType.Sword;
                    break;
                case 2:
                    type = WeaponType.Bow;
                    break;
                case 3:
                    type = WeaponType.Staff;
                    break;
            }

            ChooseWeapon(type);
        }

        static void ChooseWeapon(WeaponType type)
        {
            switch(type)
            {
                case WeaponType.Sword:
                    Console.WriteLine("검을 선택했습니다.");
                    break;
                case WeaponType.Bow:
                    Console.WriteLine("검을 선택했습니다.");
                    break;
                case WeaponType.Staff:
                    Console.WriteLine("검을 선택했습니다.");
                    break;
            }
        }
    }

    enum WeaponType
    {
        Sword = 1,
        Bow = 2,
        Staff = 3
    }
}
