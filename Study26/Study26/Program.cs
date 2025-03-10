using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study26
{
    class Program
    {
        static void Main(string[] args)
        {
            ////메서드구문 , 쿼리 구문
            //int[] nums = { 5, 3, 8, 1 };

            ////메서드구문
            //var sortedMeshod = nums.OrderByDescending(n => n);

            ////쿼리 구문
            //var sortedQuery = from n in nums
            //                  orderby n
            //                  select n;


            //Console.WriteLine("Meshod syntax:");
            //foreach (var n in sortedMeshod)
            //    Console.WriteLine(n);

            //Console.WriteLine("Query syntax:");
            //foreach (var n in sortedQuery)
            //{
            //    Console.WriteLine(n);
            //}

            //Console.WriteLine("홀수 내림차순");
            //var asdf = nums.OrderBy(n => n);
            //foreach (int i in nums.Where(n => n % 2 == 1))
            //{
            //    Console.WriteLine(i);
            //}

            //string[] words = { "apple", "banana", "cherry" };

            //var lengths = words.Select(w => w.Length);

            //foreach(var length in lengths)
            //{
            //    Console.WriteLine(length);
            //}

            //var upperWords = words.Select(w => w.ToUpper());

            //foreach(var word in upperWords)
            //{
            //    Console.WriteLine(word);
            //}

            //int[] data = { 1, 2, 3, 4, 5 };

            //int sum = 0;

            //foreach (var d in data)
            //    sum += d;

            //Console.WriteLine($"Sum : {sum}");

            //count
            //int[] data = { 1, 2, 3, 4, 5 };

            //int count = data.Length;

            //Console.WriteLine($"Count : {count}");

            //CallbackExample call = new CallbackExample();
            //call.Run();

            //Worker worker = new Worker();

            //worker.DoWork(10, (msg) => Console.WriteLine(msg));

            string[] fruits = { "apple", "banana", "blueberry", "cherry", "apricot" };

            var groups = fruits.GroupBy(f => f[0]); //첫 글자로 그룹화

            foreach (var group in groups)
            {
                Console.WriteLine($"Key : {group.Key}");

                foreach (var item in group)
                {
                    Console.WriteLine($" {item}");
                }

            }
        }


        //public delegate void ProcessCompletedCallback(string message);

        //public class Worker
        //{
        //    public void DoWork(int input, ProcessCompletedCallback callback)
        //    {
        //        int result = input * 2;
        //        callback?.Invoke($"작업 완료 : 결과는 {result}");
        //    }
        //}

        //public delegate void ProcessCompletedCallback(int result);

        //public class Processor
        //{
        //    // 작업을 수행한 후 콜백을 호출하는 메서드
        //    public void ProcessData(int input, ProcessCompletedCallback callback)
        //    {
        //        // 예시: 어떤 계산을 수행
        //        int result = input * 2;
        //        // 작업이 완료된 후 콜백 호출
        //        callback?.Invoke(result);
        //    }
        //}

        //// 사용 예
        //public class CallbackExample
        //{
        //    public void Run()
        //    {
        //        Processor processor = new Processor();
        //        // 람다식을 사용해 콜백 메서드를 전달할 수 있음
        //        processor.ProcessData(5, result =>
        //        {
        //            Console.WriteLine("처리 결과: " + result);
        //        });
        //    }
        //}
    }
}
