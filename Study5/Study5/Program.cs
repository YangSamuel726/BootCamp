using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Study5
{
    class Program
    {
        static void Main(string[] args)
        {
            // 숫자 데이터 형식 : 정수와 실수를 다룰 때 사용하는 다양한 타입
            int integerNum = 0;
            float floatNum = 3.14f;
            double doubleNum = 3.14159;

            Write(integerNum); Write(floatNum); WriteLine(doubleNum);

            // 정수 데이터 형식 : 소수점이 없는 숫자를 표현
            int intValue = -100; // 4바이트 크기의 정수
            long longValue = 1234567890L; // 8바이트 크기의 정수

            Write(intValue); WriteLine(longValue);

            // 부호 있는 정수 : 음수와 양수를 모두 표현 가능
            sbyte signedByte = -50; // 1바이트 크기
            short signedShort = -32000; // 2바이트 크기
            int signedInt = -200000000; // 4바이트 크기

            Write(signedByte); Write(signedShort); WriteLine(signedInt);

            // 부호없는 정수 데이터 형식
            byte unsignedByte = 255; // 1바이트 크기
            ushort unsignedShort = 65000; // 2바이트 크기
            uint unsignedInt = 4000000000; // 4바이트 크기

            Write(unsignedByte); Write(unsignedShort); WriteLine(unsignedInt);

            // 실수형 데이터 형식 : 소수점을 포함한 숫자를 표현
            float singlePrecision = 3.14f; // 단정밀도 실수
            double doublePrecision = 3.1415926535; // 배정밀도 실수 (8바이트)
            decimal highPrecision = 3.141592146235623562356m; // 고정밀도 (16바이트)

            WriteLine(singlePrecision); WriteLine(doublePrecision); WriteLine(highPrecision);

            // char형식 : 단일 문자를 표현
            char letter = 'A';
            char symbol = '#';
            char number = '9'; // 숫자 9 아님

            WriteLine(letter); WriteLine(symbol); WriteLine(number);

            // string 형식 : 여러 문자를 저장
            string greeting = "Hello World";
            string name = "Alice";

            WriteLine(greeting); WriteLine(name);
            WriteLine(greeting + name);

            // bool형식 : 참(true) = 1, 거짓(false) = 0
            bool isRunning = true;
            bool isFinished = false;

            WriteLine(isRunning); WriteLine(isFinished);

            // 닷넷 형식 : 기본 형식의 닷넷표현
            System.Int32 sysNum = 32;
            System.String sysString = "Hello";
            System.Boolean sysBool = true;

            WriteLine(sysNum); WriteLine(sysString); WriteLine(sysBool);

            // int 래퍼 형식의 메서드 활용
            int rapInt = 123;

            string rapString = rapInt.ToString();

            // bool 래퍼 형식
            bool flag = true;
            string rapBool = flag.ToString();

            WriteLine(rapString); WriteLine(rapBool);
        }
    }
}
