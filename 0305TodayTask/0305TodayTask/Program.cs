using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0305TodayTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Champion samira = new Samira();
            Champion lux = new Lux();
            Console.WriteLine();

            samira.Move();
            samira.BaseAttack();
            samira.SecondSkill();
            samira.ThirdSkill();
            samira.FirstSkill();
            samira.UltimateSkill();

            Console.WriteLine();

            lux.Move();
            lux.FirstSkill();
            lux.ThirdSkill();
            lux.UltimateSkill();
            lux.BaseAttack();
        }
    }

    abstract class Unit
    {
        public string name { get; protected set; }
        public float hp { get; protected set; }
        public float speed { get; protected set; }
        public float att { get; protected set; }
        public float def { get; protected set; }
        public float attackSpeed { get; protected set; }

        public Unit(string _name, float _hp, float _speed, float _att, float _def, float _attackSpeed)
        {
            name = _name;
            hp = _hp;
            speed = _speed;
            att = _att;
            def = _def;
            attackSpeed = _attackSpeed;
            Console.WriteLine($"{name}이(가) 생성되었습니다.");
        }

        public virtual void Move()
        {
            Console.WriteLine($"이동속도만큼 {name}이(가) 움직입니다.");
        }


    }

    abstract class Champion : Unit
    {
        public float mp { get; protected set; }

        public Champion(string _name, float _hp, float _speed, float _att, float _def, float _attackSpeed, float _mp) : base(_name, _hp, _speed, _att, _def, _attackSpeed)
        {
            mp = _mp;
        }

        public abstract void Passive();
        public virtual void BaseAttack()
        {
            Console.WriteLine($"{name}이(가) {att}만큼 피해를 줍니다.");
        }

        public abstract void FirstSkill();
        public abstract void SecondSkill();
        public abstract void ThirdSkill();
        public abstract void UltimateSkill();
    }

    class Samira : Champion
    {

        public Samira() : base("Samira", 550, 325, 64, 50, 0.72f, 350)
        {

        }
        
        public override void Move()
        {
            Console.WriteLine("패시브 랭크에 따라 움직임이 빨라집니다.");
        }

        public override void Passive()
        {
            Console.WriteLine($"{name}가 패시브 랭크를 쌓습니다.");
        }
        public override void BaseAttack()
        {
            Console.WriteLine($"{name}가 일반공격을 했습니다.");
            base.BaseAttack();
            Passive();
        }
        public override void FirstSkill()
        {
            Console.WriteLine($"{name}가 첫번째 스킬을 사용했습니다.");
            Passive();
        }
        public override void SecondSkill()
        {
            Console.WriteLine($"{name}가 두번째 스킬을 사용했습니다.");
            Passive();
        }
        public override void ThirdSkill()
        {
            Console.WriteLine($"{name}가 세번째 스킬을 사용했습니다.");
            Passive();
        }
        public override void UltimateSkill()
        {
            Console.WriteLine($"{name}가 랭크를 소모해 궁극기를 사용했습니다.");
        }
    }

    class Lux : Champion
    {
        public Lux() : base("Lux", 500, 330, 56, 40, 0.66f, 500)
        {

        }

        public override void Move()
        {
            base.Move();
        }

        public override void Passive()
        {
            Console.WriteLine($"{name}가 패시브를 터트리고 추가 마법피해를 줍니다.");
        }
        public override void BaseAttack()
        {
            Console.WriteLine($"{name}가 일반공격을 했습니다.");
            base.BaseAttack();
            Passive();
        }
        public override void FirstSkill()
        {
            Console.WriteLine($"{name}가 첫번째 스킬을 사용했습니다.");
        }
        public override void SecondSkill()
        {
            Console.WriteLine($"{name}가 두번째 스킬을 사용했습니다.");
        }
        public override void ThirdSkill()
        {
            Console.WriteLine($"{name}가 세번째 스킬을 사용했습니다.");
        }
        public override void UltimateSkill()
        {
            Console.WriteLine($"{name}가 궁극기를 사용했습니다.");
            Passive();
        }
    }
}
