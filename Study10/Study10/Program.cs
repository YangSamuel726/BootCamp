using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study10
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[][] arr = new int[3][];
            //arr[2] = new int[5];
            //arr[2][4] = 4;

            //Console.WriteLine(arr[2][4]);

            //int student = 3;
            //int[] kor = new int[student];
            //int[] eng = new int[student];
            //int[] math = new int[student];
            //for(int i =0; i < student; i++)
            //{
            //    Console.WriteLine($"{i + 1}번째 학생의 국어, 영어, 수학 점수를 차례대로 입력해주세요.");
            //    kor[i] = int.Parse(Console.ReadLine());
            //    eng[i] = int.Parse(Console.ReadLine());
            //    math[i] = int.Parse(Console.ReadLine());
            //}

            //for(int i = 0; i < student; i++)
            //{
            //    float sum = kor[i] + eng[i] + math[i];
            //    Console.WriteLine($"{i + 1}번째 학생의 총점 : {sum} | 평균 {(sum / 3).ToString("F2")}");
            //}

            int[] iArray = new int[25];


            for (int i = 0; i < 25; i++)
            {
                iArray[i] = i + 1;
            }



            Random rand = new Random();
            //셔플
            for (int i = 0; i < 100; i++)
            {
                // 배열에서 값을 바꿀 두 수를 고르기 위한 인덱스 랜덤 값 가져오기
                int iA = rand.Next(0, 25);
                int iB = rand.Next(0, 25);
                int iT = 0;

                //랜덤 인덱스로 뽑힌 두 수의 위치를 바꾸기
                iT = iArray[iA];
                iArray[iA] = iArray[iB];
                iArray[iB] = iT;
            }


            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Console.Write(iArray[i * 5 + j].ToString("D2") + " ");

                }
                Console.WriteLine();
            }
        }
    }
}
