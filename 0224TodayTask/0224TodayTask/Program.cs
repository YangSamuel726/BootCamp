using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0224TodayTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ㅡㅡㅡㅡㅡ1번째 문제ㅡㅡㅡㅡㅡ");
            Console.WriteLine("값을 비교할 세 정수를 입력해주세요.");
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());

            int highest;

            if(a > b)
            {
                if (a > c) { highest = a; }
                else { highest = c; }
            }
            else if (b > c) { highest = b; }
            else { highest = c; }

            Console.WriteLine($"최대값 : {highest}");

            Console.WriteLine("ㅡㅡㅡㅡㅡ2번째 문제ㅡㅡㅡㅡㅡ");
            Console.Write("학생의 점수를 입력해 주세요. : ");
            float score = float.Parse(Console.ReadLine());
            char grade;

            if(score >= 90) { grade = 'A'; }
            else if(score >= 80) { grade = 'B'; }
            else if(score >= 80) { grade = 'C'; }
            else if(score >= 80) { grade = 'D'; }
            else { grade = 'F'; }

            Console.WriteLine($"{grade}학점");

            Console.WriteLine("ㅡㅡㅡㅡㅡ3번째 문제ㅡㅡㅡㅡㅡ");
            Console.WriteLine("계산을 할 두 숫자를 입력해 주세요.");
            float d = float.Parse(Console.ReadLine());
            float e = float.Parse(Console.ReadLine());

            Console.WriteLine("어떤 계산을 할 지 부호를 입력해 주세요.");
            string f = Console.ReadLine();

            bool error = false;
            float result = 0;

            switch(f)
            {
                case "+":
                    result = d + e;
                    break;
                case "-":
                    result = d - e;
                    break;
                case "*":
                    result = d * e;
                    break;
                case "/":
                    if(d == 0 || e == 0) { error = true; break; }
                    result = d / e;
                    break;
                case "%":
                    if (d == 0 || e == 0) { error = true; break; }
                    result = d % e;
                    break;
                default:
                    Console.WriteLine("입력하신 문자는 부호가 아닙니다.");
                    break;
            }

            if(error)
            {
                Console.WriteLine("결과 : X");
            }
            else
            {
                Console.WriteLine($"결과 : {result}");
            }
        }
    }
}
