using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;

namespace Study7
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());

            float average = (float)(a + b + c) / 3;
            Console.WriteLine(average.ToString("F2"));

            int d = int.Parse(Console.ReadLine());
            Console.WriteLine($"원래 값 : {d}, 반전 값 : {~d}");
        }
    }
}
