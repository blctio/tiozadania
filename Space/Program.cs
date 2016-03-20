using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Description;


namespace Space
{
    class Program
    {
        static void Main(string[] args)
        {
            Uri address = new Uri("http://localhost:9000/BlackHole");
            ServiceHost host = new ServiceHost(typeof(BlackHole),address);
            try
            {
                host.AddServiceEndpoint(typeof(IBlackHole), new WSHttpBinding(), "BlackHoleServiceEndpoint");
                ServiceMetadataBehavior smd = new ServiceMetadataBehavior();
                smd.HttpGetEnabled = true;
                host.Description.Behaviors.Add(smd);

                host.Open();

                Console.WriteLine("Service is running!");
                Console.ReadLine();

                host.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                host.Abort();
            }
        }
    }

    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person(){}
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }

    public class Starship
    {
        public string Name { get; set; }
        public Person Captain;
        public List <Person> Crew { get; set; }

        public Starship() {
            this.Captain = new Person();
        }
    }

    public class Planet
    {
        public string Name { get; set; }
        public int Mass { get; set; }

        public Planet() { }
    }

    [ServiceContract]
    public interface IBlackHole
    {
        [OperationContract]
        Starship PullStarship(Starship ship);
        [OperationContract]
        string UltimateAnswer();
    }

    public class BlackHole : IBlackHole
    {

        public BlackHole() {}

        public Starship PullStarship(Starship ship)
        {
            if(ship.Captain.Age > 40)
            {
                //Nothing
            }
            else
            {
                foreach(var person in ship.Crew.ToList())
                {
                    person.Age += 20;
                }
            }
            return ship;
        }
        public string UltimateAnswer(){
            return 42.ToString();
        }
    }

}
