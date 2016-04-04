using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CRUDClient.ServiceReference1;
using CRUDClient.ServiceReference2;

namespace CRUDClient
{
    class Program
    {
        static void Main(string[] args)
        {
            CRUDClient.ServiceReference1.ObjectsServiceClient client1 = new CRUDClient.ServiceReference1.ObjectsServiceClient();
            CRUDClient.ServiceReference2.ObjectsServiceClient client2 = new CRUDClient.ServiceReference2.ObjectsServiceClient();

            int countPerson = 0, countReviwes = 0, countMovies = 0;

            if (client1.GetAllMovies().Count() == 0)
            {
                var movies = new[]
                {
                    new Movie() {Id = 1, Title = "Film1", Releaseyear = 2016},
                    new Movie() {Id = 2, Title = "Film2", Releaseyear = 2015},
                    new Movie() {Id = 3, Title = "Film3", Releaseyear = 2014},
                };
                countMovies += 3;
            }

            Console.WriteLine("Podaj imie: ");
            string imie = Console.ReadLine();
            Console.WriteLine("Podaj nazwisko: ");
            string nazwisko = Console.ReadLine();

            countPerson++;
            Person person = new Person() { Id = countPerson, Name = imie, Surname = nazwisko };
            client2.AddPerson(person);



            var key = Console.ReadKey();
            while (key.Key != ConsoleKey.Escape)
            {
                Console.WriteLine("\n MENU: ");
                Console.WriteLine("a) Dodanie recenzj ");
                Console.WriteLine("b) Edycja recenzji");
                Console.WriteLine("c) Usuniecie recenzji");
                Console.WriteLine("d) Zobacz recenzje dla filmu");
                Console.WriteLine("e) Dodaj film ");

                if (key.Key == ConsoleKey.A)
                {
                    List<Movie> list = client1.GetAllMovies().ToList();
                    foreach (var i in list)
                    {
                        Console.WriteLine(i.Id + ".  " + i.Title);
                    }
                    Console.WriteLine("Wpisz numer filmu który chcesz oceniac");
                    var keyy = Console.ReadKey();
                    int num = -1;
                    if (int.TryParse(keyy.KeyChar.ToString(), out num))
                    {
                        if (num <= countMovies)
                        {
                            Console.WriteLine("Wpisz swoja reenzje. Nacisniecie Enter konczy wpisywanie");
                            Review r = new Review();
                            countReviwes++;
                            r.Id = countReviwes;
                            r.MovieId = num;
                            r.Author = person;
                            r.Content = Console.ReadLine();
                            Console.WriteLine("Wpisz ocene filmu w skali 1-100");
                            int mark = -1;
                            var keyyy = Console.ReadLine();
                            int.TryParse(keyyy.ToString(), out mark);
                            r.Score = mark;
                            client2.AddReview(r);
                        }
                        else { Console.WriteLine("Zly argument"); }
                    }
                    else { Console.WriteLine("Zly argument"); }
                }
                if (key.Key == ConsoleKey.B)
                {
                    List<Review> list = client2.GetAllReviews().ToList();
                    foreach (var i in list)
                    {
                        if (i.Author == person)
                        {
                            Console.WriteLine(i.Id + "\n" + i.Content + "\n" + i.Score + "\n");
                        }
                    }
                    Console.WriteLine("Wpisz numer recenzji która chcesz edytowac");
                    var keyy = Console.ReadKey();
                    int num = -1;
                    if (int.TryParse(keyy.KeyChar.ToString(), out num))
                    {
                        if (num <= countReviwes)
                        {
                            Review r = client2.GetReview(num);
                            Console.WriteLine(client2.GetReview(num).Id + "\n" + client2.GetReview(num).Score + "\n" + client2.GetReview(num).Content + "\n");
                            Console.WriteLine("Wpisz swoja reenzje. Nacisniecie Enter konczy wpisywanie");
                            r.Content = Console.ReadLine();
                            Console.WriteLine("Wpisz ocene filmu w skali 1-100");
                            int mark = -1;
                            var keyyy = Console.ReadLine();
                            int.TryParse(keyyy.ToString(), out mark);
                            r.Score = mark;
                            client2.UpdateReview(r);
                        }
                        else { Console.WriteLine("Zly argument"); }
                    }
                    else { Console.WriteLine("Zly argument"); }


                }
                if (key.Key == ConsoleKey.C)
                {
                    List<Review> list = client2.GetAllReviews().ToList();
                    foreach (var i in list)
                    {
                        if (i.Author == person)
                        {
                            Console.WriteLine(i.Id + "\n" + i.Content + "\n" + i.Score + "\n");
                        }
                    }
                    Console.WriteLine("Wpisz numer recenzji która chcesz usunac");
                    var keyy = Console.ReadKey();
                    int num = -1;
                    if (int.TryParse(keyy.KeyChar.ToString(), out num))
                    {
                        if (num <= countReviwes)
                        {
                            Console.WriteLine("Czy na pewno chcesz usunac recenzje dla filmu{0}? Wpisz N/T(domyslnie N)", client1.GetMovie(client2.GetReview(num).MovieId).Title);
                        }
                        var key1 = Console.ReadKey();
                        if (key1.Key == ConsoleKey.Y)
                        {
                            client2.DeleteReview(num);
                        }
                        else {
                            //Nothing
                        }
                    }
                    else
                        Console.WriteLine("Zly argument");
                }
                else {
                    Console.WriteLine("Zly argument");
                }


                if (key.Key == ConsoleKey.D)
                {
                    List<Movie> list1 = client1.GetAllMovies().ToList();
                    List<Review> list2 = client2.GetAllReviews().ToList();

                    foreach(var i in list1){
                        Console.WriteLine(i.Id + " " + i.Title);
                    }
                    Console.WriteLine("Wpisz numer filmu, ktorego recenzje chcesz zobaczyć");
                    var keyy = Console.ReadKey();
                    int num = -1;
                    if (int.TryParse(keyy.KeyChar.ToString(), out num))
                    {
                        if (num <= countMovies)
                        {
                            int avg = 0,count = 0;
                            foreach (var j in list2) {
                                if (j.MovieId == num) {
                                    count++;
                                    avg += j.Score;
                                    Console.WriteLine(j.Content + " " + j.Score + " " +j.Author);
                                }
                            }
                            avg = avg / count;
                            Console.WriteLine("Srednia ocen: {0}", avg);
                        }
                    }
                }
                if (key.Key == ConsoleKey.E)
                {
                    string title;
                    int year = -1;
                    Console.WriteLine("Podaj tytul: ");
                    title = Console.ReadLine();
                    Console.WriteLine("Podaj rok wydania");                  
                    
                    var keyy = Console.ReadLine();
                    int.TryParse(keyy.ToString(), out year);
                    countMovies++;
                    Movie movie = new Movie() { Id = countMovies, Title = title, Releaseyear = year };
                }
            }
                Console.ReadKey();
            }
        }
    }

