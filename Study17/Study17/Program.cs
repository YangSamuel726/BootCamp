using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Study17
{
    class Program
    {
        static void Main(string[] args)
        {

            int MyMineral = 500;

            Mineral[] mineral = new Mineral[7];
            for(int i = 0; i < mineral.Length; i++)
            {
                mineral[i] = new Mineral();
            }
            mineral[0].ShowMineralInfo();

            Marin marin = new Marin();
            Marin raynor = new Marin("짐 레이너", 500);

            marin.ShowMarinInfo();
            raynor.ShowMarinInfo();

            Barrack barrack = new Barrack();
            barrack.ShowBarrackInfo();
            barrack.MakeMarin(ref MyMineral, out Marin makedMarin);
            makedMarin.ShowMarinInfo();
        }
    }

    class Game
    {
        public static int mineral = 50;
        public static int gas = 0;
        public static int charCount = 0;

        public static void ShowGameInfo()
        {
            Console.WriteLine($"현재 미네랄 : {mineral} | 비용 : {gas}가스 | 현재 인구수 : {charCount}");
        }
    }

    class Marin
    {
        public string name { get; private set; }
        public int mineral { get; private set; }

        public Marin()
        {
            name = "졸병";
            mineral = 50;
        }

        public Marin(string name = "졸병", int mineral = 50)
        {
            this.name = name;
            this.mineral = mineral;
        }

        public void ShowMarinInfo()
        {
            Console.WriteLine($"이름 : {name} | 비용 : {mineral}미네랄");
        }
    }

    class Barrack
    {
        string name;
        int mineral;

        public Barrack()
        {
            name = "배럭";
            mineral = 150;
        }

        public Barrack(string name = "배럭", int mineral = 150)
        {
            this.name = name;
            this.mineral = mineral;
        }

        public void ShowBarrackInfo()
        {
            Console.WriteLine($"이름 : {name} | 비용 : {mineral}미네랄");
        }

        public void MakeMarin(ref int mineral, out Marin marin)
        {
            mineral -= 50;
            marin = new Marin();
        }
    }

    class Mineral
    {
        string name;
        int mineral;

        //public Mineral()
        //{
        //    name = "미네랄";
        //    mineral = 1500;
        //}

        public Mineral(string name = "미네랄", int mineral = 1500)
        {
            this.name = name;
            this.mineral = mineral;
        }

        public void ShowMineralInfo()
        {
            Console.WriteLine($"이름 : {name} | 현재 미네랄 : {mineral}");
        }
    }
}
