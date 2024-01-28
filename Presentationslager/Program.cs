using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
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

        

        public static void HuvudMeny()
        {
            
            bool val = false;
            while (!val)
            {
                int menyVal = 0;
                Console.WriteLine("----HuvudMeny----");
                Console.WriteLine("Tryck 1 för att boka ett nytt läkarbesök");
                Console.WriteLine("Tryck 2 för att hantera läkarbesök");
                Console.WriteLine("Tryck 3 för att registrera patientuppgift");
                Console.WriteLine("Tryck 4 för att uppdatera patientuppgift");
                Console.WriteLine("Tryck 5 för att avsluta programmet");
                Console.Write("Välj ett av de alternativ ovanför: ");
                Console.WriteLine("TEST");
                while (!int.TryParse(Console.ReadLine(), out menyVal))  
                {
                    Console.WriteLine("Fel inmatning! ange rätt input val: ");
                }

                switch (menyVal)
                {
                    case 1:
                        BokaLäkarbesök();
                        break;

                    case 2:
                        HanteraLäkarbesök();
                        break;

                    case 3:
                        RegistreraPatientuppgift();
                        break;

                    case 4:
                         UppdateraPatientuppgift();
                        break;
                    
                        case 5:Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Ogiltig val, försök igen!");
                        break;
                }
            }
        }
        private static void BokaLäkarbesök()//Denna är klar
        {
            Console.WriteLine("Boka ett nytt läkarbesök:\n");

            Console.Write("Ange patientens personnummer: ");
            int personnummer = int.Parse(Console.ReadLine());

            Console.Write("Ange patientens namn:");
            string namn = Console.ReadLine();

            Console.Write("Ange besöksnummer: ");
            int besöksNummer = int.Parse(Console.ReadLine());

            Console.Write("Ange datum (ÅÅÅÅ-MM-DD): ");
            DateTime datum = DateTime.Parse(Console.ReadLine());

            Console.Write("Ange tid (HH:mm): ");
            TimeSpan tid = TimeSpan.Parse(Console.ReadLine());

            Console.Write("Ange ditt anställningsnummer: ");
            int anställningsNummer = int.Parse(Console.ReadLine());

            Console.Write("Ange besökssyfte: ");
            string besöksSyfte = Console.ReadLine();

            Patient patient = kontroller.BokaBesök(personnummer,besöksNummer,datum,tid,anställningsNummer,besöksSyfte);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nLäkarbesöket har bokats framgångsrikt:");
            Console.WriteLine($"Patient: {namn}");
            Console.WriteLine($"Besöksdatum: {datum}");
            Console.WriteLine($"Besökstid: {tid}");
            Console.WriteLine($"Ditt anställningsnummer: {anställningsNummer}");
            Console.WriteLine($"Besökssyfte: {besöksSyfte}\n");
            Console.ResetColor();
        }

        private static void RegistreraPatientuppgift()//Denna är klar
        {
            Console.Write("Ange patientens namn: ");
            string namn = Console.ReadLine();

            Console.Write("Ange patientens personnummer: ");
            int personNummer = int.Parse(Console.ReadLine()) ;

            Console.Write("Ange patientens adress: ");
            string adress = Console.ReadLine();

            Console.Write("Ange patientens telefonnummer: ");
            int telefonNummer = int.Parse(Console.ReadLine());

            Console.Write("Ange patientens epost: ");
            string epost = Console.ReadLine();

            Console.Write("Ange patientens patientnummer: ");
            int patientNummer = int.Parse(Console.ReadLine());

            Patient nyaPatienter = kontroller.RegistreraNyPatient(namn, personNummer, adress, telefonNummer, epost, patientNummer);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\nFöljande patient har registrerats\n Namn: {namn}\n Personnummer: {personNummer}\n Adress: {adress}\n Telefeonnummer: {telefonNummer}\n E-post: {epost}\n Patientnummer: {patientNummer}\n");
            Console.ResetColor();
        }

        
        private static void HanteraLäkarbesök()
        {
            Console.Write("Ange patientnummer för att hantera läkarbesök: ");
            int patientNummer = int.Parse(Console.ReadLine());
            
            LäkarBesök besöket = kontroller.HämtaLäkarbesök(patientNummer);

            if ( besöket != null )
            {
                Console.WriteLine($"Patientinformation: \nNamn: {besöket.PatientNummer}, \nTelefonnummer: {besöket.BesöksNummer}, \nPersonnummer: {besöket.BesöksDatum}, \nAdress: {besöket.Tid}, \nEpost: {besöket.BesöksSyfte}");
                Console.Write("Ange besöksnummer för att ta bort läkarbesök: ");
                int besöksnummer = int.Parse(Console.ReadLine());
                
                    if (kontroller.Hanterabesök(besöket))
                    {
                        Console.WriteLine($"Läkarbesöket med besöksnummer {besöksnummer} är avbokat\n");
                    }
                
                else
                {
                    Console.WriteLine("Ogiltigt besöksnummer.");
                }
            }
            else
            {
                Console.WriteLine("Patienten kunde inte Hittas!");
            }
        }

        private static void UppdateraPatientuppgift()
        {
            Console.Write("Ange patientens personnummer för uppdatering: ");
            int personnummer = int.Parse(Console.ReadLine());

     
            Patient patient = kontroller.HämtaPatient(personnummer);

            if (patient != null)
            {
                Console.WriteLine($" Informationen för patient {patient.Namn}:");
                Console.WriteLine($"1. Namn: {patient.Namn}");
                Console.WriteLine($"2. Adress: {patient.Adress}");
                Console.WriteLine($"3. Telefonnummer: {patient.TelefonNummer}");
                Console.WriteLine($"4. E-post: {patient.Epost}");

                Console.Write("Välj vilken information du vill uppdatera genomatt välja mellan 1-4 ovanför: ");
                if (int.TryParse(Console.ReadLine(), out int val))
                {
                    switch (val)
                    {
                        case 1:
                            Console.Write("Ange nytt namn: ");
                            patient.Namn = Console.ReadLine();
                            break;

                        case 2:
                            Console.Write("Ange ny adress: ");
                            patient.Adress = Console.ReadLine();
                            break;

                        case 3:
                            Console.Write("Ange nytt telefonnummer: ");
                            patient.TelefonNummer = int.Parse(Console.ReadLine());
                            break;

                        case 4:
                            Console.Write("Ange ny e-post: ");
                            patient.Epost = Console.ReadLine();
                            break;

                        default:
                            Console.WriteLine("Ogiltigt val.");
                            break;
                    }

                    
                    if (kontroller.UppdateraPatient(patient))
                    {
                        Console.WriteLine("Patientinformation är uppdaterad!!.");
                    }
                    else
                    {
                        Console.WriteLine("Det finns ett fel vid uppdatering av patientinformation.");
                    }
                }
                else
                {
                    Console.WriteLine("Ogiltigt val.");
                }
            }
            else
            {
                Console.WriteLine("Patienten kunde inte hittas. Kontrollera personnumret och försök igen.");
            }
        }
    }
}
