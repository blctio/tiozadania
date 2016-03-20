using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceClient.ServiceReference;

namespace SpaceClient
{
    class Program
    {
        static void PresentCrew(Starship _starship)
        {
            Console.WriteLine("Captain name is: " + _starship.Captain.Name + " and age is: " + _starship.Captain.Age);
            foreach (var person in _starship.Crew.ToList())
            {
                Console.WriteLine("Member of Crew: " + person.Name + " and age is: " + person.Age);
            }
        } 

        static void Main(string[] args)
        {
            Console.WriteLine("Client is running!");

            BlackHoleClient bhc = new BlackHoleClient();

            Starship starship = new Starship();
            starship.Captain = new Person() { Name = "Captain", Age = 37 };
            
            starship.Crew = new Person[] { new Person() { Name = "Person1", Age = 15 }, new Person() { Name = "Person2", Age = 20 }, new Person() { Name = "Person3", Age = 25 }, new Person() { Name = "Person4", Age = 30 }, new Person() { Name = "Person5", Age = 35 } };

            PresentCrew(starship);

            var newClass = bhc.PullStarship(starship);
            Console.WriteLine(bhc.UltimateAnswer());

            PresentCrew(newClass);

            Console.ReadLine();
       
            
        }       
    }
}

  