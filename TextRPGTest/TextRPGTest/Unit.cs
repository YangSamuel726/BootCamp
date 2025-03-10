using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPGTest
{
    abstract class Unit
    {
        public string Name { get; protected set; }
        public int HP { get; protected set; }
        public int curHP { get; protected set; }
        public int ATT { get; protected set; }

        public Unit(string name, int hP = 1, int aTT = 0)
        {
            Name = name;
            HP = hP;
            ATT = aTT;
            curHP = hP;
        }

        public abstract void Attack(Unit unit);
        public abstract void Damaged(int damage);
    }
}
