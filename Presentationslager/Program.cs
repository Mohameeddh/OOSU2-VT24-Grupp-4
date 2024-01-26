using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Net;
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
            kontroller = new Kontroller();
            unitOfWork = new UnitOfWork();
           
            Console.WriteLine("Välkommen till Patienthanteringssystemet\n");
            Console.WriteLine("Var god och logga in\n");

            bool logg = false;

            while (!logg)
            {
                try
                {
                    if (InLoggning())
                    {
                        Console.WriteLine(" Välkommen " + kontroller.loggadIn.Namn + " du är nu inloggad!\n");
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
            bool val = false;
            while (!val)
            Console.WriteLine("----HuvudMeny----");
            Console.WriteLine("Tryck 1 för att boka ett nytt läkarbesök");
            Console.WriteLine("Tryck 2 för att hantera läkarbesök");
            Console.WriteLine("Tryck 3 för att registrera patientuppgift");
            Console.WriteLine("Tryck 4 för att uppdatera patientuppgift");
            Console.WriteLine("Tryck 5 för att avsluta programmet");

            Console.Write("Välj ett av de alternativ ovanför: ");
            string val = Console.ReadLine();
            while (val != null) { }
            switch(val)
            {
                case "1":
                    BokaLäkarbesök();
                    break;

                case "2":
                    HanteraLäkarbesök();
                    break;

                case "3":
                    RegistreraPatientuppgift();
                    break;

                case "4":
                    UppdateraPatientuppgift();
                    break;

                case "5":
                    AvslutaProgram();
                    break;

                default:
                    Console.WriteLine("Ogiltig val, försök igen!");
                    break;

                
               
                    

                
            }
        }
    }
}
