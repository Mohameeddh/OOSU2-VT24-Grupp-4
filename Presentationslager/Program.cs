using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using AffärsLager;
using DataLagret;
using EntitetLager;

namespace Presentationslager
{
    internal class Program
    {
        private static Kontroller kontroller;
        private static UnitOfWork unitOfWork;

        static void Main(string[] args)
        {
<<<<<<< HEAD
            Console.WriteLine("Välkommen till Patienthanteringssystemet\n");
            Console.WriteLine("Var god och logga in\n");
=======
            HuvudMeny();
        }

        private Program()
        {
             kontroller = new Kontroller();
             unitOfWork = new UnitOfWork();

        }

        private void Inloggning()
        {
            Console.WriteLine("Välkommen till Patienthanteringssystemet");
            Console.WriteLine();
            Console.WriteLine("Var god och logga in");
            Console.WriteLine();
>>>>>>> 7d2e5fa92fb5fdd20023674e1601ea8778cdf069

            bool logg = false;

            while (!logg)
            {
                try
                {
                    if (InLoggning())
                    {
                        Console.WriteLine(" Välkommen" + kontroller.loggadIn.Namn + " du är nu inloggad!\n");
                        logg = true;
                        HuvudMeny();
                    }
                    else
                    {
                        Console.WriteLine("Inloggning misslyckad, försök igen!\n");
                        Console.WriteLine();
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Felmeddelande: " + ex.Message);
                }
            }
        }

        private static bool InLoggning()
        {
            Console.Write("Ange anställningsnummer: ");
            int anställningsnummer = int.Parse(Console.ReadLine());

            Console.Write("Ange lösenord: ");
            int lösenord = int.Parse(Console.ReadLine());

            return kontroller.InLoggning(anställningsnummer, lösenord);
        }

        private static void HuvudMeny()
        {
            Console.WriteLine("----HuvudMeny----");
            Console.Write("Tryck 1 för att boka ett nytt läkarbesök:");
            Console.WriteLine("Tryck 2 ");
            Console.ReadLine();
        }
    }
}
