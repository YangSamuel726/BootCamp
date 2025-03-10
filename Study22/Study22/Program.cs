using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Study22
{
    class Program
    {
        static void Main(string[] args)
        {
            //string path = Environment.GetEnvironmentVariable("PATH");
            //Console.WriteLine($"PATH : {path}");

            //Environment.Exit(0);

            //string input = "Hello, my phone number is 010-1234-5678.";
            //string pattern = @"\d{3}-\d{4}-\d{4}"; // 전화번호 패턴

            //bool isMatch = Regex.IsMatch(input, pattern);

            //Console.WriteLine($"전화번호가 존재하는가? {isMatch}");

            //object obj;
            //int i = 64;

            //obj = "123";
            //string s = obj as string;
            //if(obj as string is string)
            //{
            //    Console.Write(s);
            //}

            List<int> arr = new List<int>();
            arr.Add(1);
            arr.Add(2);
            arr.Add(3);

            arr.Insert(1, 100);
            Console.WriteLine(arr.Count);


            arr.Remove(2);

            int x = 5;
            //Console.WriteLine(arr.Count);
            //try
            //{
            //    for(int i = 0; i < x; i++)
            //    {
            //        Console.WriteLine(arr[i]);
            //    }
            //}
            //catch(Exception ex)
            //{
            //    Console.WriteLine($"오류발생 : {ex}");
                
            //}
            //finally
            //{
            //    x--;
            //}

            ArrayList list = new ArrayList();

            list.Add(1);
            list.Add(arr);
            list.Add(x);
            Console.WriteLine(list);

            int? i = null;
            string s = "";

            i = 10;
            int z = i == null ? 0 : i.Value;
            //i = null;
            Console.WriteLine(i ?? 5);

            Console.WriteLine(s?.Length);

            var asdf = from a in arr where a > 2 select a;
        }
    }
}
