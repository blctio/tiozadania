using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODataClient
{
    class Program
    {
        static void Main(string[] args)
        {
            string serviceUri = "http://localhost:49847/";
            var container = new ODataClientas.Default.Container(new Uri(serviceUri));

            Console.WriteLine("Lista wszystkich gier:");
            foreach (var game in container.Games)
            {
                Console.WriteLine("{0}", game.Title);
            }

            Console.WriteLine("Dodanie nowej gry");
            container.AddToGames(new ODataClientas.Library.Game() { Title = "game1", CreatorCompany = "comp1", Year = 2015, AgeRate = 18 });
            var serviceResponse = container.SaveChanges();

            Console.WriteLine("Lista wszystkich gier: ");
            foreach (var game in container.Games)
            {
                Console.WriteLine("{0}", game.Title);
            }

            Console.WriteLine("Lista wszystkich koszulek na karty: ");
            foreach (var card in container.GetAvailableCardShirts().ToList())
            {
                Console.WriteLine("{0}", card.Name);
            }

            Console.WriteLine("Lista wszystkich sklepow: ");
            foreach (var store in container.Stores)
            {
                Console.WriteLine("{0}", store.Name);
            }

            Console.WriteLine("Usun sklep :");
            container.Store.Where(x => x.Name == "store1").ToList().ForEach(x => container.DeleteObject(x));
            serviceResponse = container.SaveChanges();

            Console.WriteLine("Lista wszystkich sklepow: ");
            foreach (var store in container.Stores)
            {
                Console.WriteLine("{0}", store.Name);
            }

            Console.ReadKey();
        }
    }
}
