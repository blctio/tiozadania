using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CosmicAdventureDTO
{
    [DataContract]
    public class SpaceSystem
    {
        public SpaceSystem(string _n, int _msp, int _bd, int _g)
        {
            this.Name = _n;
            this.MinShipPower = _msp;
            this.BaseDistance = _bd;
            this.Gold = _g;
        }
        [DataMember]
        public string Name { get; set; }
        private int MinShipPower;
        [DataMember]
        public int BaseDistance { get; set; }
        private int Gold;

        public int getMSP()
        {
            return this.MinShipPower;
        }

        public int getGold()
        {
            return this.Gold;
        }  

    }

    [DataContract]
    public class Starship
    {
        [DataMember]
        public List<Person> Crew { get; set; }
        [DataMember]
        public int Gold { get; set; }
        [DataMember]
        public int ShipPower { get; set; }

        public Starship(int _power)
        {
            Crew = new List<Person>();
            Crew.Add(new Person("Pirate1", "Nick1", 20));
            Crew.Add(new Person("Pirate2", "Nick2", 20));
            Crew.Add(new Person("Pirate3", "Nick3", 20));
            Crew.Add(new Person("Pirate4", "Nick4", 20));
            this.ShipPower = _power;
            this.Gold = 0;
        }
  
        public void addCrewAge(float additionalAge)
        {
            foreach (var person in this.Crew)
            {             
                    person.addAge(additionalAge);                                   
            }   
        }

        public string showCrewShip()
        {
            string CrewString = "";

            foreach(var element in Crew)
            {
                CrewString += ", ";
                CrewString += element.Name;
                CrewString += " ";
                CrewString += element.Nick;
                CrewString += " ";
                CrewString += element.Age;                
            }                   
            return CrewString;
        }

    }

    [DataContract]
    public class Person
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Nick { get; set; }
        [DataMember]
        public float Age { get; set; }

        public Person(string _name, string _nick, float _age)
        {
            this.Name = _name;
            this.Nick = _nick;
            this.Age = _age;
        }

        public void addAge(float _age)
        {
            this.Age += _age;
        }
    }
}
