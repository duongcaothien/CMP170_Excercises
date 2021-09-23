using System;

namespace Animalex
{
    class Program
    {
        static void Main(string[] args)
        {
            interface IAnimal
        {
            DateTime brithdate { get; set; }
            void Move();
            void Speak();

        }
        public abstract class BaseAnimal : IAnimal
        {
            public abstract DateTime brithdate { get; set; }
            public abstract void Move();
            public abstract void Speak();

        }
        public class Monkey : BaseAnimal
        {
            public override DateTime brithdate { get; set; }
            public override void Move()
            {
                Console.WriteLine("Monke move jump , climp");
            }
            public override void Speak()
            {
                Console.WriteLine("Monke say ki ki ka ka");
            }


        }


        public class Pets : BaseAnimal
        {
            public override DateTime brithdate { get; set; }
            public string name { get; set; }
            public string color { get; set; }
            public Pets(string name, string color)
            {
                this.name = name;
                this.color = color;
            }

            public override void Move()
            {
            }

            public override void Speak()
            {
            }
        }


        public class Dogs : Pets
        {
            public Dogs(string name, string color) : base(name, color)
            {
            }


            public override void Move()
            {
                Console.WriteLine(name + "(dog) move with 4 legs." + "color : " + color);
            }
            public override void Speak()
            {
                Console.WriteLine(name + "(dog) say gau gau ");
            }
        }


        public class Cats : Pets
        {

            public Cats(string name, string color) : base(name, color)
            {
            }


            public override void Move()
            {
                Console.WriteLine(name + " (cat) move with 4 legs." + "color : " + color);
            }
            public override void Speak()
            {
                Console.WriteLine(name + " (cat) say meo meo");
            }
            public void jump()
            {
                Console.WriteLine(name + " (cat) jump");
            }
        }

        class Program
        {
            static void Main(string[] args)
            {
                List<IAnimal> animals = new List<IAnimal>();
                animals.Add(new Dogs("Bach", "white"));
                animals.Add(new Monkey());
                animals.Add(new Cats("Bi", "black"));

                foreach (IAnimal animal in animals)
                {
                    animal.Move();
                    animal.Speak();
                }
                Console.ReadLine();
            }
    }
}
