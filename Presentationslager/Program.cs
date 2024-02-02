using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
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
        public static int ValideringAvInt()
        {
            int siffra;

            while (true)
            {

                string input = Console.ReadLine();

                if (int.TryParse(input, out siffra))
                {
                    return siffra;
                }

                else
                {

                    Console.Write("fel inmatning försök igen: ");

                }
            }
        }

        public static string ValideringAvTextSträng()
        {
            string inmatning;
            do
            {
                inmatning = Console.ReadLine();
                if (string.IsNullOrEmpty(inmatning) || inmatning.Any(char.IsDigit))
                {
                    Console.Write("Din inmatning är ogiltig försök igen: ");
                }

            }
            while (string.IsNullOrEmpty(inmatning) || inmatning.Any(char.IsDigit));
            {
                return inmatning;
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
                Console.WriteLine("Tryck 5 för att visa hanterade läkarbesök");
                Console.WriteLine("Tryck 6 för att avsluta programmet");
                Console.Write("Välj ett av de alternativ ovanför: ");
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

                    case 5:
                        HanteradeLäkarbesök();
                            break;


                        case 6:Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Ogiltig val, försök igen!");
                        break;
                }
            }
        }
        private static void BokaLäkarbesök()
        {
            Console.WriteLine("Boka ett nytt läkarbesök:\n");

            Console.Write("Ange patientens patientnummer: ");
            int patientnummer = ValideringAvInt();

            Console.Write("Ange besöksnummer: ");
            int besöksNummer = ValideringAvInt();

            Console.Write("Ange datum (ÅÅÅÅ-MM-DD HH:MM): ");
            DateTime datum = DateTime.Parse(Console.ReadLine());

            Console.Write("Ange ditt anställningsnummer: ");
            int anställningsNummer = ValideringAvInt();

            Console.Write("Ange besökssyfte: ");
            string besöksSyfte = ValideringAvTextSträng();

            LäkarBesök NyttBesök = new LäkarBesök(patientnummer, besöksNummer, datum, anställningsNummer, besöksSyfte);
            LäkarBesök besöken = kontroller.BokaBesök(NyttBesök);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nLäkarbesöket har bokats framgångsrikt:");
            Console.WriteLine($"Patientnummer: {patientnummer}");
            Console.WriteLine($"Besöksnummer: {besöksNummer}");
            Console.WriteLine($"Besöksdatum: {datum}");
            Console.WriteLine($"Ditt anställningsnummer: {anställningsNummer}");
            Console.WriteLine($"Besökssyfte: {besöksSyfte}\n");
            Console.ResetColor();
        }

        public static void RegistreraPatientuppgift()
        {
            Console.Write("Ange patientens namn: ");
            string namn = ValideringAvTextSträng();

            Console.Write("Ange patientens personnummer: ");
            int personNummer = ValideringAvInt();

            Console.Write("Ange patientens adress: ");
            string adress = ValideringAvTextSträng();

            Console.Write("Ange patientens telefonnummer: ");
            int telefonNummer = ValideringAvInt();

            Console.Write("Ange patientens epost: ");
            string epost = ValideringAvTextSträng();

            Console.Write("Ange patientens patientnummer: ");
            int patientNummer = ValideringAvInt();

            Patient NyPatient = new Patient(namn, personNummer, adress, telefonNummer, epost, patientNummer);

            Patient nyaPatienter = kontroller.RegistreraNyPatient(NyPatient);
            

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\nFöljande patient har registrerats\n Namn: {namn}\n Personnummer: {personNummer}\n Adress: {adress}\n Telefeonnummer: {telefonNummer}\n E-post: {epost}\n Patientnummer: {patientNummer}\n");
            Console.ResetColor();
        }

        
        private static void HanteraLäkarbesök()
        {
            Console.Write("Ange besöksnummer för att hantera läkarbesök: ");
            int besöksnummer = ValideringAvInt();
            LäkarBesök besöket = kontroller.HämtaLäkarbesök(besöksnummer);

            if ( besöket != null )
            {
                Console.WriteLine($"Besöksinformation: \nPatientnummer: {besöket.PatientNummer} \nBesöksnummer: {besöket.BesöksNummer} \nBeöksdatum: {besöket.BesöksDatum} \nBesökssyfte: {besöket.BesöksSyfte}");
                Console.Write("Ange besöksnummer för att ta bort läkarbesök: ");
                int besöksNummer = ValideringAvInt();

                if (besöksNummer == besöksnummer && kontroller.Hanterabesök(besöket))
                {
                 Console.WriteLine($"\nLäkarbesöket med besöksnummer {besöksnummer} är hanterat och borttaget från systemet\n");
                }
                
                else
                {
                    Console.WriteLine("Ogiltigt besöksnummer.");
                }
            }
            else
            {
                Console.WriteLine("Det finns inget läkarbesök med det angivna besöksnummret!\n");
            }
        }

        public static void HanteradeLäkarbesök()
        {

            Console.Write("Ange besöksnumret: ");
            int Besök = ValideringAvInt();

            //for(int i = 0; i < Besök; i++)
            //{
                LäkarBesök besöken = kontroller.HämtaLäkarbesök(Besök);
                if (besöken != null && besöken.hanteradeläkarbesök.Count>0)
                {
                        Console.WriteLine("Dessa läkarbesök är behandlade");
                        Console.WriteLine($"Namn: {besöken.PatientNummer}");
                        Console.WriteLine($"Patientnummer: {besöken.BesöksDatum},");
                        Console.WriteLine($"Adress: {besöken.BesöksNummer}");
                        Console.WriteLine($"Adress: {besöken.BesöksSyfte}");
                    
                }

                else
                {
                    Console.WriteLine("Det finns inga hanterade läkarbesök");
                }
            //}
        }

        private static void UppdateraPatientuppgift()
        {
            Console.Write("Ange patientens patientnummer för uppdatering: ");
            int patientnummer = ValideringAvInt();


            Patient patient = kontroller.HämtaPatient(patientnummer);

            if (patient != null)
            {
                Console.WriteLine($" Informationen för patient {patient.Namn}:");
                Console.WriteLine($"1. Namn: {patient.Namn}");
                Console.WriteLine($"2. Adress: {patient.Adress}");
                Console.WriteLine($"3. Telefonnummer: {patient.TelefonNummer}");
                Console.WriteLine($"4. E-post: {patient.Epost}");

                Console.Write("Välj vilken information du vill uppdatera genomatt välja mellan 1-4 ovanför eller tryck 5 för att avsluta: ");
                if (int.TryParse(Console.ReadLine(), out int val) && val >= 1 && val <= 5)
                {
                    switch (val)
                    {
                        case 1:
                            Console.Write("Ange nytt namn: ");
                            patient.Namn = ValideringAvTextSträng();
                            break;

                        case 2:
                            Console.Write("Ange ny adress: ");
                            patient.Adress = ValideringAvTextSträng();
                            break;

                        case 3:
                            Console.Write("Ange nytt telefonnummer: ");
                            patient.TelefonNummer = ValideringAvInt();
                            break;

                        case 4:
                            Console.Write("Ange ny e-post: ");
                            patient.Epost = ValideringAvTextSträng();
                            break;

                        case 5: 
                            Environment.Exit(0);
                            break;

                        default:
                            Console.WriteLine("Ogiltigt val.");
                            break;
                    }
                    
                    if (kontroller.UppdateraPatient(patient))
                    {
                        Console.WriteLine("Patientuppgifter är sparade!");
                    }
                    else
                    {
                        Console.WriteLine("Kunde inte spara");
                    }
                }
                else
                {
                    Console.WriteLine("Fel input ange val mellan 1 till 4");
                }
            }
           
            else
            {
              Console.WriteLine("Patienten kunde inte hittas. Kontrollera personnumret och försök igen.");
            }
                   
        }
    }
}
