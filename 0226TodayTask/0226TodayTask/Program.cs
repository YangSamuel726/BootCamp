using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace _0226TodayTask
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = new int[5];
            //WriteLine("1. 크기가 5인 정수 배열을 만들고, {10, 20, 30, 40, 50} 값을 저장한 후 출력하세요. ");
            //for(int i = 0; i < a.Length; i++)
            //{
            //    a[i] = (i + 1) * 10;
            //    Write(a[i] + " ");
            //}
            //WriteLine();

            //WriteLine("문제: 사용자가 5개의 정수를 입력하면 배열에 저장하고, 모든 수의 합을 출력하세요.");
            //int sum = 0;
            //for (int i = 0; i < 5; i++)
            //{
            //    a[i] = int.Parse(ReadLine());
            //    sum += a[i];
            //}
            //WriteLine("총 합 : " + sum);
            //WriteLine();

            //WriteLine("문제: 정수 배열 {3, 8, 15, 6, 2}에서 가장 큰 값을 찾아 출력하세요.");
            //a = new int[5] { 3, 8, 15, 6, 2 };
            //int max = 0;
            //for (int i = 0; i < a.Length; i++)
            //{
            //    if (a[i] > max)
            //    {
            //        max = a[i];
            //    }
            //}
            //WriteLine(max);
            //WriteLine();

            //WriteLine(" for문을 사용하여 1부터 10까지 출력하세요.");
            //for (int i = 0; i < 11; i++)
            //{
            //    Write(i + " ");
            //}
            //WriteLine();

            //WriteLine(" while문을 사용하여 1부터 10까지 중 짝수만 출력하세요.");
            //for (int i = 0; i < 11; i++)
            //{
            //    if (i != 0 && i % 2 == 0)
            //    {
            //        Write(i + " ");
            //    }
            //}
            //WriteLine();

            //WriteLine("foreach문을 사용하여 배열 {1, 2, 3, 4, 5}의 요소를 출력하세요.");
            //a = new int[5] { 1, 2, 3, 4, 5 };
            //foreach (int i in a)
            //{
            //    Write(i + " ");
            //}
            //WriteLine();

            //WriteLine("두 개의 정수를 입력받아 합을 반환하는 함수를 작성하세요.");
            //WriteLine(Sum(int.Parse(ReadLine()), int.Parse(ReadLine())));

            //WriteLine("문자열을 입력받아 길이를 반환하는 함수를 작성하세요.");
            //WriteLine(Length(ReadLine()));

            WriteLine("세 개의 정수를 입력받아 가장 큰 값을 반환하는 함수를 작성하세요.");
            WriteLine("가장 큰 수 : " + MaxValue(int.Parse(ReadLine()), int.Parse(ReadLine()), int.Parse(ReadLine())));
        }

        static int Sum(int a, int b)
        {
            return a + b;
        }

        static int Length(string s)
        {
            return s.Length;
        }

        static int MaxValue(int a, int b, int c)
        {
            int max = 0;
            if( a > max) { max = a; }
            if( b > max) { max = b; }
            if( c > max) { max = c; }
            return max;
        }
    }
}
