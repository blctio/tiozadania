using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication3.ServiceReference1;
using ConsoleApplication3.ServiceReference2;

namespace ConsoleApplication3
{
    class Program
    {


        static void Main(string[] args)
        {

            List<Starship> _starships = new List<Starship>();
            bool _anySystem = true;
            int _gold = 1000;
            int _imperiumMoneyAskCount = 4;

            ServiceReference1.Service1Client cosmos = new ServiceReference1.Service1Client();
            cosmos.Initializegame();
            ServiceReference2.Service1Client firstOrder = new ServiceReference2.Service1Client();

            var key = Console.ReadKey();
            while ( key.Key != ConsoleKey.Escape)
            {
                Console.WriteLine();
                Console.WriteLine("Ilosc zlota: {0} ", _gold);
                Console.WriteLine("Ilosc prob o zloto do imperium: {0} ", _imperiumMoneyAskCount);
                Console.WriteLine();
                Console.WriteLine("MENU:");
                Console.WriteLine("a. Popros imperium o zloto");
                Console.WriteLine("b. Kup statek za zloto");
                Console.WriteLine("c. Wyslij statek do systemu");
                Console.WriteLine("d. Zakoncz gre");

                key = Console.ReadKey();

                if (key.Key == ConsoleKey.A)
                {
                    Console.WriteLine();
                    if (_imperiumMoneyAskCount > 0)
                    {
                        _gold += firstOrder.GetMoneyFromImperium();
                        _imperiumMoneyAskCount -= 1;
                    }
                    else
                    {
                        Console.WriteLine("Nie masz juz prosb o zloto");
                    }
                }

                if (key.Key == ConsoleKey.B)
                {
                    Console.WriteLine();
                    Console.WriteLine("Aktualne zloto: {0}, Wpisz ile zlota chcesz za statek", _gold);
                    var ileString = Console.ReadLine();
                    Console.WriteLine();
                    int ile = Int32.Parse(ileString);

                    if (ile <= _gold && ile > 0 && cosmos.GetStarship(ile) != null)
                    {
                        _starships.Add(cosmos.GetStarship(ile));
                        _gold -= ile;
                        Console.WriteLine("Statek kupiony:shipPower {0},gold {1}",_starships.First().ShipPower, _starships.First().Gold);
                        
                    }
                    else
                    {
                        Console.WriteLine("Zla kwota ");
                    }                   
                }
                if (key.Key == ConsoleKey.C)
                {
                    Console.WriteLine();
                   
                    if (cosmos.GetSystem() == null)
                    {
                        _anySystem = false;
                        Console.WriteLine("Brak systemow");
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("System {0}, odleglosc {1}", cosmos.GetSystem().Name, cosmos.GetSystem().BaseDistance);
                        Console.WriteLine("Statkow gotowych do podrozy: {0}", _starships.Count());

                        if (_starships.Count() == 0)
                        {
                            continue;
                        }
                        else {
                            Console.WriteLine("Wybierz statek wpisując jego numer(albo wyjdź wpisujac litere 'e'");
                            int shipsAmount = 0;                          
                            foreach (var ship in _starships)
                            {
                                 shipsAmount += 1;
                                 string crew = cosmos.showCrew(ship);
                                 Console.WriteLine("{0}. {1} {2}", shipsAmount, ship.ShipPower, crew);
                            }                           
                            key = Console.ReadKey();
                            if (key.Key == ConsoleKey.E)
                            {
                                continue;
                            }
                            else
                            {
                                int num = -1;
                                if (int.TryParse(key.KeyChar.ToString(), out num))
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("Wybrales statek: " + num.ToString());
                                    if(num <= shipsAmount && num > 0)
                                    {
                                        Starship shipToTravel = _starships.ElementAt(num-1);
                                        _starships.RemoveAt(num - 1);
                                        shipsAmount -= 1;
                                        shipToTravel = cosmos.SendStarship(shipToTravel, cosmos.GetSystem().Name);
                                        if (shipToTravel.Gold > 0)
                                        {
                                            _gold += shipToTravel.Gold;
                                        }
                                        if(shipToTravel.Crew.Count() > 0)
                                        {
                                            _starships.Add(shipToTravel);
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Zly numer statku");
                                    }
                                   
                                }
                                else 
                                {
                                    Console.WriteLine("Zly rodzaj parametru");
                                }
                                
                                   

                                
                            }
                            
                        }
                    }
                }
                if (key.Key == ConsoleKey.D)
                {
                    if(_anySystem == false)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Wygrana!!!");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine();                           
                        Console.WriteLine("Przegrana!!!");
                        Console.ReadKey();
                    }
                }

            }
            

        }
    }
}
