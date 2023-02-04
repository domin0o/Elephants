using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Elephants
{
    class Elephant
    {
        public string Name { get; set; }
        public int EarSize { get; set; }
        public void WhoAmI()
        {
            Console.WriteLine("Na imię mi " + Name);
            Console.WriteLine("Długość moich uszu to " + EarSize + " cm.");
        }

        public void HearMessage(string message, Elephant whoSaidIt)
        {
            Console.WriteLine(Name + " usłyszał(a) wiadomość.");
            Console.WriteLine(whoSaidIt.Name + " powiedział(a): " + message);
        }

        public void SpeakTo(Elephant whoToTalkTo, string message)
        {
            whoToTalkTo.HearMessage(message, this); // w tym wypadku this będzie odwołaniem do obiektu, który wywołuje funkcję SpeakTo.
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Elephant laura = new Elephant() { Name = "Laura", EarSize = 80 };
            Elephant lucek = new Elephant() { Name = "Lucek", EarSize = 100};
            Elephant zmiennaPomocnicza;
            while (true) {
                Console.WriteLine("Wciśnij 1 (Lucek), 2 (Laura), 3 (przestawienie),4 (wybranie liczby), 5 (przesłanie wiadomości):");
                Console.Write("Twój wybór: "); 
                string userAnswer = Console.ReadLine();
                if (int.TryParse(userAnswer, out int answer))
                {
                    Console.WriteLine("Wcisnąłeś " + answer + ".");
                    switch (answer)
                    {
                        case 1:
                            Console.WriteLine("Wywołanie lucek.WhoAmI().");
                            lucek.WhoAmI();
                            break;
                        case 2:
                            Console.WriteLine("Wywołanie laura.WhoAmI().");
                            laura.WhoAmI();
                            break;
                        case 3:
                            zmiennaPomocnicza = lucek;
                            lucek = laura;
                            laura = zmiennaPomocnicza;
                            Console.WriteLine("Referencje zostały przestawione.");
                            break;
                        case 4:
                            // Test jak działają referencje
                            lucek = laura;
                            Console.Write("Wpisz liczę: ");
                            string userEarSize = Console.ReadLine();
                            if(int.TryParse(userEarSize, out int userEarInt))
                            {
                                lucek.EarSize = userEarInt;
                            }
                            lucek.WhoAmI();
                            break;
                        case 5:
                            Console.Write("Wpisz wiadomość: ");
                            string userSpeakTo = Console.ReadLine();
                            laura.SpeakTo(lucek, userSpeakTo);
                            break;
                        default: return;
                    }
                }
            }
        }
    }
}
