using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Study4
{
    class Program
    {
        static void Main(string[] args)
        {
            // 문자열
            string greeting;
            greeting = "Hello, World!";

            Console.WriteLine(greeting);

            // 변수 선언과 초기화를 한번에 수행
            int score = 100;
            double temperature = 36.5;
            string city = "Seoul";

            Console.WriteLine(score);
            Console.WriteLine(temperature);
            Console.WriteLine(city);

            // 같은 데이터 타입의 변수를 쉼표로 구분해서 선언
            int x = 10, y = 20, z = 30;

            Console.WriteLine(x);
            Console.WriteLine(y);
            Console.WriteLine(z);

            const double pi = 3.14159;
            Console.WriteLine(pi);

            double Att = 16775;
            double maxHP = 78103;
            int critical = 36;
            int well = 1017;
            int jeab = 41;
            int speed = 611;
            int patient = 22;
            int practice = 39;

            WriteLine("공격력 : " + Att);
            WriteLine("최대 생명력 : " + maxHP);
            WriteLine("치명 : " + critical);
            WriteLine("특화 : " + well);
            WriteLine("제압 : " + jeab);
            WriteLine("신속 : " + speed);
            WriteLine("인내 : " + patient);
            WriteLine("숙련 : " + practice);
        }
    }
}
