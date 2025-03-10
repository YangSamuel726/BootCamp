using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TextRPGTest
{
    class Monster : Unit
    {
        public Monster(string _name, int _hp, int _aTT) : base(_name, _hp, _aTT)
        {

        }

        public override void Attack(Unit unit)
        {
            unit.Damaged(ATT);
            Console.WriteLine($"{Name}은(는) {ATT}만큼 {unit.Name}에게 피해를 입혔다.");
        }

        public override void Damaged(int damage)
        {
            curHP -= damage;
        }
    }
}
