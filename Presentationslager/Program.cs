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
        private Kontroller kontroller;
        private UnitOfWork unitOfWork;

        static void Main(string[] args)
        {
            new Program().Inloggning();
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

            bool logg = false;

            while(logg)
            {
                try
                {
                    if (InLoggning())
                    {
                        Console.WriteLine(" Välkommen" + kontroller.loggadIn.Namn + " du är nu inloggad!");
                        Console.WriteLine();
                        logg = true;
                        HuvudMeny();
                    }
                    else
                    {
                        Console.WriteLine("Inloggning misslyckad, försök igen!");
                        Console.WriteLine();
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Felmeddelande: " + ex.Message);
                }
            }

        }

        private bool InLoggning()
        {
            Console.Write("Ange anställningsnummer: ");
            string anställningsnummer = Console.ReadLine();

            Console.Write("Ange lösenord: ");
            string lösenord = Console.ReadLine();

            return kontroller.loggadIn(anställningsnummer, lösenord);
        }

        private static void HuvudMeny()
        {
            Console.WriteLine("----HuvudMeny----");

        }
    }
}
