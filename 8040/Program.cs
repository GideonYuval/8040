using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8040
{
    internal class Program //
    {
        static void Main(string[] args)
        {
            Cat c1 = new Cat();
            c1.MakeNoise();
            c1.MakeNoise(3);

            Animal a1 = new Dog(); //(Animal)new Dog(); isn't needed
            //Dog d2 = new Animal(); //can't do this
            //Dog d2 = (Dog)(new Animal());

            a1.MakeNoise();
            //a1.Growl(); //a1 doesn't have access to Growl



            //a1 is declared as an Animal, but it actually refers to a Dog object
            //The is operator checks the actual type of the object at runtime, not the reference type.
            Console.WriteLine(a1 is Dog);
            Console.WriteLine(a1.GetType().Name);


            ((Dog)a1).Growl(); //remember the double ((

            //Dog d1 = a1; //fails

            //a1.Jump(); //won't compile, a1 is an Animal, which doesn't implement Jump()
            a1.Jump(3); //calls the Animal method 
            ((Dog)a1).Jump(); //calls Dog's implentation, as we're downcasting a1 
            
            ((Dog)a1).Jump(3); //Dog inherits Jump(int jumps)




        }

        static void DoAnimalStuff(Animal a)
        {
            a.MakeNoise();

            if (a is Dog)
                ((Dog)a).Growl();
        }
    }

    public class Animal
    {
        string name;
        public virtual void MakeNoise()
        {
            Console.WriteLine("Animal Noise");
        }

        public void Jump(int jumps)
        {
            Console.WriteLine($"jump {jumps} times");
        }
    }

    public class Dog : Animal
    {
        public override void MakeNoise()
        {
            Console.WriteLine("Woof!");
        }

        public void Growl()
        {
            Console.WriteLine("Grrrr");
        }

        public void Jump()
        {
            Console.WriteLine("Jump!");
        }
    }

    public class Cat : Animal
    {
        public void MakeNoise(int times)
        {
            Console.WriteLine($"Meow {times} times");
        }
    }


}