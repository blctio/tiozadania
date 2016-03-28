using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using CosmicAdventureDTO;

namespace WcfServiceLibrary1
{

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)] 
    public class Service1 : IService1
    {
        private List<SpaceSystem> _systems = new List<SpaceSystem>();

        public void Initializegame()
        {
            Random rnd1 = new Random(DateTime.Now.Millisecond);
            SpaceSystem s1 = new SpaceSystem("system1",rnd1.Next(10,41),rnd1.Next(20,121),rnd1.Next(3000,7001));            
            _systems.Add(s1);

            Random rnd2 = new Random(DateTime.Now.Millisecond);
            SpaceSystem s2 = new SpaceSystem("system2", rnd2.Next(10, 41), rnd2.Next(20, 121), rnd2.Next(3000, 7001));
            _systems.Add(s2);

            Random rnd3 = new Random(DateTime.Now.Millisecond);
            SpaceSystem s3 = new SpaceSystem("system3", rnd3.Next(10, 41), rnd3.Next(20, 121), rnd3.Next(3000, 7001));
            _systems.Add(s3);

            Random rnd4 = new Random(DateTime.Now.Millisecond);
            SpaceSystem s4 = new SpaceSystem("system4", rnd4.Next(10, 41), rnd4.Next(20, 121), rnd4.Next(3000, 7001));
            _systems.Add(s4);


        }

        public Starship SendStarship(Starship starship, string systemName)
        {
            bool flag = true;
            int indexToDelete = -2;
            int index = 0;
            foreach(var element in _systems)
            {                
                if (element.Name == systemName)
                {
                    flag = false;

                    if(starship.ShipPower <= 20)
                    {
                        float additionalAge = (2 * element.BaseDistance) / 12;
                        starship.addCrewAge(additionalAge);

                        int j = 0;
                        for (int i = starship.Crew.Count()-1; i >= 0; i -= 1)
                        {
                            if (starship.Crew.ElementAt(i).Age > 90)
                            {
                                starship.Crew.RemoveAt(i);
                                j--;
                            }
                            j++;
                        }

                    }
                    else if(starship.ShipPower > 20 && starship.ShipPower <= 30)
                    {
                        float additionalAge = (2 * element.BaseDistance) / 6;
                        starship.addCrewAge(additionalAge);


                        int j = 0;
                        for (int i = starship.Crew.Count()-1; i >= 0; i -= 1)
                        {
                            if (starship.Crew.ElementAt(i).Age > 90)
                            {
                                starship.Crew.RemoveAt(i);
                                j--;
                            }
                            j++;
                        }

                    }
                    else if (starship.ShipPower > 30)
                    {
                        float additionalAge = (2 * element.BaseDistance) / 4;
                        starship.addCrewAge(additionalAge);


                        int j = 0;
                        for (int i = starship.Crew.Count()-1; i >= 0 ; i -= 1)
                        {
                            if (starship.Crew.ElementAt(i).Age > 90)
                            {
                                starship.Crew.RemoveAt(i);
                                j--;
                            }
                            j++;
                        }
                    }
                    else
                    {
                        //Nothing
                    }

                    if (starship.ShipPower >= element.getMSP())
                    {
                        starship.Gold = element.getGold();
                        //   _systems.Remove(element);
                        indexToDelete = index;
                    }
                    
                }
                index += 1;
            }
            if (indexToDelete > -2)
            {
                _systems.RemoveAt(indexToDelete);
            }
            
            if (flag)
            {
                starship.Crew.Clear();
            }
            return starship;
        }

        public SpaceSystem GetSystem()
        {
            if(_systems.Count() > 0)
            {
                return _systems.First();
            }
            else
            {
                return null;
            }
        }

        public Starship GetStarship(int money)
        {

            if (money > 1000 && money <= 3000)
            {
                Random rnd = new Random(DateTime.Now.Millisecond);
                Starship starship = new Starship(rnd.Next(10,26));
                return starship;
            }
            else if(money > 3001 && money <= 10000)
            {
                Random rnd = new Random(DateTime.Now.Millisecond);
                Starship starship = new Starship(rnd.Next(20, 36));
                return starship;
            }
            else if(money > 10000)
            {
                Random rnd = new Random(DateTime.Now.Millisecond);
                Starship starship = new Starship(rnd.Next(35, 61));
                return starship;
            }
            else
            {
                //Nothing
                return null;
            }
        }

        public string showCrew(Starship ship)
        {
            string Crew = "";
            Crew += ship.showCrewShip();
            return Crew;
        }
    }
}
