using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace _0224Test2
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("1");
            VoidAsync();
            WriteLine("2");
        }

        static async void VoidAsync()
        {
            WriteLine("VoidAsync 작동 시작");
            await Task.Delay(1);
            WriteLine("VoidAsync 작동 종료");
        }

        static async Task TaskAsync()
        {
            WriteLine("TaskAsync 작동 시작");
            await Task.Delay(1000);
            WriteLine("TaskAsync 작동 종료");
        }
    }
}
