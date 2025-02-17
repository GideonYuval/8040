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


            Animal a1 = new Dog(); //(Animal)new Dog(); isn't needed
            //Dog d2 = new Animal(); //Dog can't reference Animal, which is higher up
            //Dog d2 = (Dog)(new Animal()); //this will compile, but fail at runtime

            
            a1.MakeNoise();
            //a1.Growl(); //a1 doesn't have access to Growl

            Animal a3 = new Animal();
            ((Dog)a3).Growl();

            //a1 is declared as an Animal, but it actually refers to a Dog object
            //The is operator checks the actual type of the object at runtime, not the reference type.
            Console.WriteLine(a1 is Dog);
            Console.WriteLine(a1.GetType().Name);


            ((Dog)a1).Growl(); //remember the double ((

            //Dog d1 = a1; //fails

            Dog d1 = new Dog();
            d1.Jump(); //calls Dog's implementation
            d1.Jump(3); //Dog inherits Jump(int jumps)

            //a1.Jump(); //won't compile, a1 is an Animal, which doesn't implement Jump()
            a1.Jump(3); //calls the Animal method 
            ((Dog)a1).Jump(); //calls Dog's implentation, as we're downcasting a1 
            
            ((Dog)a1).Jump(3); //Dog inherits Jump(int jumps)

            
            Cat c1 = new Cat();
            c1.MakeNoise();
            c1.MakeNoise(3);

            d1.MakeNoise();
            //d1.MakeNoise(3); //no overload for this method takes one parameter

            Animal a2 = new Cat();
            a2.MakeNoise();
            //a2.MakeNoise(3);
            ((Cat)a2).MakeNoise(3);

            a1 = new Animal(d1); //OK, a1 refers to a new Animal
            //d1 = new Dog(a1); //compiler error - a1 references a dog, but the Dog ctor expects a dog, not an Animal
            d1 = new Dog((Dog)a1); //fixed

            Animal[] a = new Animal[5];
            a[0] = new Animal();
            a[1] = new Cat();
            a[2] = new Dog();
            a[4] = new Lion();
            int cats = 0, lions = 0, animals = 0, catsNotLions = 0;

            foreach (Animal animal in a)
            {
                if (animal is Lion) lions++;
                if (animal is Cat) cats++;
                if (animal is Animal) animals++;
                if (animal is Cat && !(animal is Lion))
                    catsNotLions++;
            }

            Console.WriteLine($"{lions} Lions, {cats} cats, {animals} Animals, {catsNotLions} catsNotLions");
        }

        static void DoAnimalStuff(Animal a)
        {
            a.MakeNoise();

            if (a is Dog)
                ((Dog)a).Growl();
        }

        static int SumLion(Object[] m)
        {
            int sum = 0;
            foreach (Object o in m)
                if (o is Lion) sum += ((Lion)o).Calc();

            return sum;
        }
    }

    public class Animal
    {
        protected string name;

        public Animal() 
        {
        }

        public virtual int Calc() { return 1; }

        public Animal(Animal other):this()
        { this.name = other.name; }

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

        public Dog() { }

        public Dog(Dog other) { }

        public override void MakeNoise() //override
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
        public void MakeNoise(int times) //overload
        {
            Console.WriteLine($"Meow {times} times"); 
        }
    }

    public class Lion : Cat
    {
        public override int Calc()
        {
            Random rnd = new Random();
            return rnd.Next(0,5) + base.Calc();
        }
    }


}