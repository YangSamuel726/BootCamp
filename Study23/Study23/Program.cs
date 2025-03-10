using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study23
{
    class Program
    {
        static void Main(string[] args)
        {
            //Warrior warrior = new Warrior("멋사", 0, 15);
            //Console.WriteLine($"이름 : {warrior.Name} | 점수 : {warrior.Score} | 힘 : {warrior.Strength}");

            //string s = Console.ReadLine();
            //try
            //{
            //    int i = int.Parse(s);
            //    Console.WriteLine(i);
            //}
            //catch (FormatException ex)
            //{
            //    Console.WriteLine("올바른 숫자를 입력하세요! : " + ex);
            //}

            //List<string> arr = new List<string> { "사과", "바나나", "포도" };
            //Queue<string> queue = new Queue<string>();
            //queue.Enqueue("첫 번재 작업");
            //queue.Enqueue("두 번재 작업");
            //queue.Enqueue("세 번재 작업");

            //Stack<int> stack = new Stack<int>();
            //stack.Push(10);
            //stack.Push(20);
            //stack.Push(30);

            //foreach(string s in arr)
            //{
            //    Console.WriteLine(s);
            //}
            //foreach(string s in queue)
            //{
            //    Console.WriteLine(s);
            //}
            //foreach(int i in stack)
            //{
            //    Console.WriteLine(i);
            //}

            //string s = Console.ReadLine();
            //Console.WriteLine(s.ToUpper());
            //Console.WriteLine(s.Replace("C#", "CSharp"));
            //Console.WriteLine(s.Length);

            //int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            //var nums = numbers.Where(n => n % 2 == 0);
            //foreach(int num in nums)
            //{
            //    Console.WriteLine(num);
            //}

            //int sum = numbers.Sum();
            //Console.WriteLine(sum);
            

            Warrior warrior = new Warrior("asdf", 0, 0);
            Operation op = warrior.Sum;


            Console.WriteLine(op(10, 3));
            
        }
    }

    class Warrior
    {
        public string Name { get; set; }
        public int Score { get; set; }
        public float Strength { get; set; }

        public Warrior(string name, int score, float strength)
        {
            Name = name;
            Score = score;
            Strength = strength;
        }

        public int Sum(int x, int y)
        {
            return x + y;
        }
    }

    public delegate int Operation(int x, int y);
    // 대리자는 자료형처럼 존재하는가? 클래스를 선언하는 것처럼?
}
