using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPGTest
{
    class Character : Unit
    {
        public Character(string _name, int _hp, int _aTT) : base(_name, _hp, _aTT)
        {

        }

        public override void Attack(Unit monster)
        {
            monster.Damaged(ATT);
            Console.WriteLine($"{Name}은(는) {ATT}만큼 {monster.Name}에게 피해를 입혔다.");
        }

        public override void Damaged(int damage)
        {
            curHP -= damage;
            Console.WriteLine($"{Name}은(는) {damage}의 데미지를 입었다.");
        }

        public virtual void Heal()
        {
            curHP = HP;
            Console.WriteLine($"{Name}은(는) 체력을 회복했다!");
        }
    }
}
