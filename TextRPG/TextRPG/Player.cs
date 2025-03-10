using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    class Player
    {
        public INFO m_tInfo;

        public void SetDamage(int iAttack) { m_tInfo.iHp -= iAttack; }
        public INFO GetInfo() { return m_tInfo; }
        public void SetHp(int iHP) { m_tInfo.iHp = iHP; }

        public void Render()
        {
            Console.WriteLine("=======================");
            Console.WriteLine("직업 이름 : " + m_tInfo.strName);
            Console.WriteLine("체력 : " + m_tInfo.iHp + "\n공격력 : " +m_tInfo.iAttack);
        }

        public void SelectJob()
        {
            m_tInfo = new INFO();

            Console.WriteLine("직업을 선택하세요(1.기사 2.마법사 3.도둑) : ");
            int iInput = 0;

            iInput = int.Parse(Console.ReadLine());

            switch (iInput)
            {
                case 1:
                    m_tInfo.strName = "기사";
                    m_tInfo.iHp = 100;
                    m_tInfo.iAttack = 10;
                    break;
                case 2:
                    m_tInfo.strName = "마법사";
                    m_tInfo.iHp = 90;
                    m_tInfo.iAttack = 15;
                    break;
                case 3:
                    m_tInfo.strName = "도둑";
                    m_tInfo.iHp = 85;
                    m_tInfo.iAttack = 13;
                    break;
            }
        }

        public Player() { }
        ~Player() { }
    }
}
