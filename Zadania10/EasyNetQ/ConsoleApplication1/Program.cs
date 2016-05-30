using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyNetQ;
using Library;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Podaj nick gracza: ");
            string nick_gracza = Console.ReadLine();
            //Publisher
            using (var bus = RabbitHutch.CreateBus("host=localhost"))
            {
                Random rnd = new Random();
                int unikalne_id = rnd.Next(999999);
                bus.Subscribe<Message>(unikalne_id.ToString(), HandleTextMessage);
                Console.WriteLine("Listening for messages. Hit <return> to quit.");
                Console.ReadLine();

                var input = "";
                Console.WriteLine("Enter a message. 'Quit' to quit.");
                while ((input = Console.ReadLine()) != "Quit")
                {
                    bus.Publish(new Message
                    {
                        Name = nick_gracza,
                        Text = input
                    });
                }
                

                Console.WriteLine("Listening for messages. Hit <return> to quit.");
                Console.ReadLine();
            }

            
               
            
        }

        static void HandleTextMessage(Message textMessage)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("{0} : {1}", textMessage.Name, textMessage.Text);
            Console.ResetColor();
        }
    }
}
