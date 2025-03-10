using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0224Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Animal db = new Animal("기본 동물");
            Animal animal = new Dog("진돗개");
            Animal animal2 = new Cat("삼색고양이");
            Animal chiwawa = new Chiwawa("치와와");

            chiwawa.Run();
            Dog dog = (Dog)chiwawa;

            dog.DogIndi();

            Chiwawa second = (Chiwawa)chiwawa;
            second.Run();
            second.Bark();
            second.DogIndi();
            second.ChiwawaIndi();


            //db.Run();

            //animal.Run();

            //animal2.Sound();
            //animal2.Run();

            //Cat cat = (Cat)animal2;
            //cat.Meow();
            Console.WriteLine(0.1 + 0.2 == 0.3);
            
        }

        class Animal
        {
            protected string name;

            public Animal(string name)
            {
                this.name = name;
            }

            public void Sound()
            {
                Console.WriteLine("울음소리");
            }

            public virtual void Run()
            {
                Console.WriteLine("열심히 달림");
            }
        }

        class Dog : Animal
        {
            public Dog(string name) : base(name)
            {
                
            }

            public virtual void Bark()
            {
                Console.WriteLine($"{name} : 왈왈");
            }

            public override void Run()
            {
                base.Run();
                Console.WriteLine("용맹하게 달림");
            }

            public void DogIndi()
            {
                Console.WriteLine("개 클래스 실험용 함수");
            }
        }

        class Cat : Animal
        {
            public Cat(string name) : base(name)
            {

            }

            public void Meow()
            {
                Console.WriteLine($"{name} : 냐옹");
            }

            public new void Run()
            {
                Console.WriteLine("귀엽게 달림");
            }
        }

        class Chiwawa : Dog
        {
            public Chiwawa(string name) : base(name)
            {

            }

            public override void Bark()
            {
                base.Bark();
                Console.WriteLine("왈뢍왈ㄹ와르라랄와알");
            }

            public override void Run()
            {
                base.Run();
                Console.WriteLine("지랄맞게 달림");
            }

            public void ChiwawaIndi()
            {
                Console.WriteLine("치와와 클래스 실험용 함수");
            }
        }
    }
}
