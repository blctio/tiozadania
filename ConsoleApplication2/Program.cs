using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadania1
{
    public abstract class Animal
    {
        public string Name { get; set; }
        public float Weight { get; set; }
        public bool HaveFur { get; set; }

        public abstract string Sound();
        public abstract string Trick();
        public abstract int CountLegs();

    }

    public interface ICircus
    {
        string AnimalsIntroduction();
        string Show();
        int Patter(int howMuch);
    }

    public interface IZoo
    {
        string Sounds();
    }

    public class Circus : ICircus
    {
        public List<Animal> Animals;
        public string Name { get; set; }


        public Circus(string name)
        {
            Name = name;
            Animals = new List<Animal>();

            Animals.Add(new Cat("Cat1"));
            Animals.Add(new Cat("Cat2"));

            Animals.Add(new Pony("Pony1"));
            Animals.Add(new Pony("Pony2"));

            Animals.Add(new Ant("Ant1"));
            Animals.Add(new Ant("Ant2"));

            Animals.Add(new Elephant("Elephant1"));
            Animals.Add(new Elephant("Elephant2"));

            Animals.Add(new Giraffe("Giraffe1"));
            Animals.Add(new Giraffe("Giraffe2"));

        }

        public string AnimalsIntroduction()
        {
            string result = "";

            foreach (var i in Animals)
            {
                result += i.Sound() + "\n";
            }

            return result;
        }

        public string Show()
        {
            string result = "";

            foreach (var i in Animals)
            {
                result += i.Trick() + "\n";
            }

            return result;
        }

        public string ShowPresentation()
        {
            string result = "";

            foreach (var i in Animals)
            {
                result += i.Name + "\n";
            }

            return result;
        }       

        public int Patter(int howMuch)
        {
            int result = 0;

            foreach (var i in Animals)
            {
                result += i.CountLegs();
            }

            return result * howMuch;
        }

    }

    public class Zoo : IZoo
    {
        public List<Animal> Animals;
        public string Name { get; set; }

        public Zoo(string name)
        {
            Name = name;
            Animals = new List<Animal>();

            Animals.Add(new Elephant("Elephant11"));
            Animals.Add(new Elephant("Elephant12"));
            Animals.Add(new Elephant("Elephant13"));

            Animals.Add(new Giraffe("Giraffe11"));
            Animals.Add(new Giraffe("Giraffe12"));
            Animals.Add(new Giraffe("Giraffe13"));

            Animals.Add(new Pony("Pony11"));
            Animals.Add(new Pony("Pony12"));
            Animals.Add(new Pony("Pony13"));

        }
        public string Sounds()
        {
            string result = "";

            foreach (var i in Animals)
            {
                result += i.Sound() + "\n";
            }

            return result;
        }
    }

    public class Cat : Animal
    {
        string Color { get; set; }

        public Cat(string n)
        {
            Name = n;
            HaveFur = true;
        }
        public override string Sound()
        {
            return "miaaau";
        }

        public override string Trick()
        {
            return "Jumping with turning around itself";
        }
        public override int CountLegs()
        {
            return 4;
        }
    }

    public class Pony : Animal
    {
        public bool IsMagic { get; set; }

        public Pony(string n)
        {
            Name = n;
            HaveFur = true;
        }

        public override string Sound()
        {
            return "iooo";
        }

        public override string Trick()
        {
            return "Bowing in front of public";
        }
        public override int CountLegs()
        {
            return 4;
        }
    }

    public class Ant : Animal
    {
        public bool IsQueen { get; set; }

        public Ant(string n)
        {
            Name = n;
            HaveFur = false;
        }

        public override string Sound()
        {
            return " ";
        }

        public override string Trick()
        {
            return "Creating anthills";
        }
        public override int CountLegs()
        {
            return 6;
        }
    }

    public class Elephant : Animal
    {

        public Elephant(string n)
        {
            Name = n;
            HaveFur = false;
        }

        public override string Sound()
        {
            return "tuuu";
        }

        public override string Trick()
        {
            return "Tooting";
        }
        public override int CountLegs()
        {
            return 4;
        }
    }

    public class Giraffe : Animal
    {

        public Giraffe(string n)
        {
            Name = n;
            HaveFur = true;
        }
        public override string Sound()
        {
            return "eeeeeee";
        }

        public override string Trick()
        {
            return "Eating leaves on 15meters height";
        }
        public override int CountLegs()
        {
            return 4;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Circus Cyrk = new Circus("Cyrk1");
            Zoo zoo = new Zoo("Zoo1");

            var key = Console.ReadKey();

            while (key.Key != ConsoleKey.Escape)
            {
                Console.WriteLine("Wybierz opcje:");
                Console.WriteLine("'a' : Prezentacja Zwierząt w Cyrku {0}", Cyrk.Name);
                Console.WriteLine("'b' : Obejrzenie programu cyrku {0}", Cyrk.Name);
                Console.WriteLine("'c' : Posłuchanie dźwięków Zoo {0}", zoo.Name);
                Console.WriteLine("'d' : Wyświetla imie pierwszego znalezionego futrzaka w Zoo");
                Console.WriteLine("'e' : Wyświetla wszystkie imiona zwierzą w Cyrku");

                key = Console.ReadKey();
                Console.WriteLine();

                if (key.Key == ConsoleKey.A)
                {
                    Console.WriteLine(Cyrk.ShowPresentation());
                }
                else if (key.Key == ConsoleKey.B)
                {
                    Console.WriteLine(Cyrk.Show());
                }
                else if (key.Key == ConsoleKey.C)
                {
                    Console.WriteLine(zoo.Sounds());
                }
                else if (key.Key == ConsoleKey.D)
                {
                    foreach(var i in zoo.Animals)
                    {
                        if (i.HaveFur)
                        {
                            Console.WriteLine(i.Name);
                            break;
                        }
                    }
                }
                else if (key.Key == ConsoleKey.E)
                {
                    foreach(var i in Cyrk.Animals){
                        Console.WriteLine(i.Name);
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
