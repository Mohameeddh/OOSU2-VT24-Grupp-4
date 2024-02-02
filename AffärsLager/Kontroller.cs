using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using DataLagret;
using EntitetLager;
using Microsoft.SqlServer.Server;

namespace AffärsLager
{
    public class Kontroller
    {
        private UnitOfWork unitOfWork;
        public Läkare loggadIn { get; private set; }

        public bool InLoggning(int anställningsNummer, int lösenord)
        {
            unitOfWork = new UnitOfWork();
            Läkare läkare = unitOfWork.VårdsPersonalRepository.FirstOrDefault(l => l.AnställningsNummer == anställningsNummer);
           
            if (läkare != null && läkare.LösenKontroll(lösenord))
            {
                loggadIn = läkare;
                return true;
            }
            else
            {
                loggadIn = null;
                return false;
            }
        }
        public LäkarBesök BokaBesök(LäkarBesök besök)
        {
            unitOfWork.LäkarBesökRepository.Add(besök);
            unitOfWork.Save();
            return besök;
        }

        public Patient HämtaPatient(int  patientNummer) 
        {
            Patient patient = unitOfWork.PatientRepository.FirstOrDefault(p => p.PatientNummer == patientNummer);
            unitOfWork.Save();
            return patient;
        }

        public Patient RegistreraNyPatient(Patient NyPatient)
        {
            unitOfWork.PatientRepository.Add(NyPatient);
            unitOfWork.Save();
            return NyPatient;
        }


        public LäkarBesök HämtaLäkarbesök(int besöksNummer)
        {
            LäkarBesök besöket = unitOfWork.LäkarBesökRepository.FirstOrDefault(b => b.BesöksNummer == besöksNummer);
            unitOfWork.Save();
            return besöket;
        }


        public bool Hanterabesök(LäkarBesök besöksnummer)
        {
            try
            {
                besöksnummer.hanteradeläkarbesök.Add(besöksnummer);
                unitOfWork.Save();
                //unitOfWork.LäkarBesökRepository.Remove(besöksnummer);
                unitOfWork.Save();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Kunde ej avboka läkarbesök, försök igen" + ex.Message);
                return false;
            }
        }

        public bool UppdateraPatient(Patient patient)
        {
            try
            {
                unitOfWork.PatientRepository.Update(patient);
                unitOfWork.Save();

                return true;
            }
            catch (Exception ex)
            {
                
                Console.WriteLine("Fel vid uppdatering av patient: " + ex.Message);
                return false;
            }
        }
    }
}
