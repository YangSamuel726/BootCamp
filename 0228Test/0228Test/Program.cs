using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace _0228Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Animal[,,] arr = new Animal[13,13,3];
            arr[6, 6, 0] = new Dog();
            WriteLine(arr[6, 6, 0] == null);
            WriteLine(arr[6, 5, 0] == null);
            WriteLine(arr[6, 6, 0] is Dog);
            BackgroundColor = ConsoleColor.White;
            ForegroundColor = ConsoleColor.Black;
            WriteLine(" ■ ");
            WriteLine("┌---┐");
            WriteLine("|101|");
            ResetColor();

            Animal animal = new Dog();
            Re(animal);
            animal.Sound();

            Animal animal2 = new Animal();
            Re(animal2);
            animal2.Sound();
        }

        class Animal
        {
            public virtual void Sound()
            {
                Console.WriteLine("동물 울음소리");
                return;
            }
        }

        class Dog : Animal
        {
            public override void Sound()
            {
                base.Sound();
                WriteLine("멍멍");
            }
        }

        class Cat : Animal
        {
            public override void Sound()
            {
                WriteLine("냐옹");
            }
        }

        class Human
        {

        }

        static Animal Re(Animal ani)
        {
            if (ani is Dog)
            {
                return ani;
            }
            else if (ani is Cat)
            {
                return ani;
            }
            else
            {
                return ani;
            }

        }
    }
}
