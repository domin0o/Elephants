using System;
using System.Collections.Generic;
using System.Linq;
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
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Elephant laura = new Elephant() { Name = "Laura", EarSize = 80 };
            Elephant lucek = new Elephant() { Name = "Lucek", EarSize = 100};
            Elephant zmiennaPomocnicza;
            Console.WriteLine("Wciśnij 1 (Lucek), 2 (Laura) lub 3 (przestawienie):");
            while (true) {
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
                            lucek.EarSize = 4321;
                            lucek.WhoAmI();
                            break;
                        default: return;
                    }
                }
            }
        }
    }
}
