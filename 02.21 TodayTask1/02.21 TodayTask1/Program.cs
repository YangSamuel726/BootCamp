using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;

namespace _02._21_TodayTask1
{
    class Program
    {
        static void Main(string[] args)
        {
            // 로딩바 시작화면
            // 입력을 받으며 게임스토리를 작성해보기
            WriteLine("Loading : □□□□□□□□□□");
            Thread.Sleep(1000);
            Clear();
            WriteLine("Loading : ■□□□□□□□□□");
            Thread.Sleep(1000);
            Clear();
            WriteLine("Loading : ■■□□□□□□□□");
            Thread.Sleep(1000);
            Clear();
            WriteLine("Loading : ■■■□□□□□□□");
            Thread.Sleep(1000);
            Clear();
            WriteLine("Loading : ■■■■□□□□□□");
            Thread.Sleep(1000);
            Clear();
            WriteLine("Loading : ■■■■■□□□□□");
            Thread.Sleep(1000);
            Clear();
            WriteLine("Loading : ■■■■■■□□□□");
            Thread.Sleep(1000);
            Clear();
            WriteLine("Loading : ■■■■■■■□□□");
            Thread.Sleep(1000);
            Clear();
            WriteLine("Loading : ■■■■■■■■□□");
            Thread.Sleep(1000);
            Clear();
            WriteLine("Loading : ■■■■■■■■■□");
            Thread.Sleep(1000);
            Clear();
            WriteLine("Loading : ■■■■■■■■■■");
            Clear();
            WriteLine("아무 키나 눌러서 스토리 시작하기");
            ReadLine();
            Clear();

            WriteLine("이해하면 무서운 이야기");
            Thread.Sleep(3000);
            Clear();

            WLC("(야심한 밤.)");
            WLC("(누군가가 집 문을 두들긴다.)");
            WLC("이 시간에 집에 올 사람이 없는데...?");
            WLC("(밖에 있는 누군가가 저음의 목소리로 '계십니까?'라고 말한다.)");
            WLC("어떡하지? 지금은 혼자 있어서 열어주기가 좀 그런데..");
            WLC("(아무말 없이 서 있길 잠시)");
            WLC("(밖에서 대화하는 소리가 들린다.)");
            WLC("(아무래도 여러명 인듯 하다.)");
            WLC("(몇번 더 '계십니까?'라는 말이 들린다.)");
            WLC("(입을 다문채로 조용히 문을 응시했다.");
            WLC("(집에서 멀어져 가는 발 소리가 들린다.)");
            WLC("휴.....");
            WLC("분명히 이 시간에는 집 주변에 사람이 없을텐데..?");
            WLC("누가 부른거지?");
            WLC("빨리 여기서 나가야겠다.");

            WriteLine("끝");
        }

        static void WLC(string text)
        {
            Clear();
            WriteLine(text);
            Thread.Sleep(500);
            ReadLine();
        }
    }
}
