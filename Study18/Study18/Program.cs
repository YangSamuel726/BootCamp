using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study18
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("학생 3명의 이름과 성적(국어 - 영어 - 수학)을 차례대로 입력해 주세요.");
            string[] s = Console.ReadLine().Split();
            Score a = new Score(s[0], int.Parse(s[1]), int.Parse(s[2]), int.Parse(s[3]));
            s = Console.ReadLine().Split();
            Score b = new Score(s[0], int.Parse(s[1]), int.Parse(s[2]), int.Parse(s[3]));
            s = Console.ReadLine().Split();
            Score c = new Score(s[0], int.Parse(s[1]), int.Parse(s[2]), int.Parse(s[3]));

            a.PrintScore();
            b.PrintScore();
            c.PrintScore();
        }
    }

    public struct Score
    {
        string name;
        int kor;
        int eng;
        int math;

        public Score(string _name, int _kor, int _eng, int _math)
        {
            name = _name;
            kor = _kor;
            eng = _eng;
            math = _math;
        }

        public void PrintScore()
        {
            Console.WriteLine($"이름 : {name} | 국어 : {kor}점 | 영어 : {eng}점 | 수학 : {math}점");
        }
    }
}
