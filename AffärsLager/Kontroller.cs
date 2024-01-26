using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLagret;
using EntitetLager;

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
        public Patient BokaBesök(int patientNummer, int besöksNummer, DateTime datum, TimeSpan tid, int anställningsNummer, string besöksSyfte)
        {
            DateTime dateTime = DateTime.Now.AddDays(12);
            LäkarBesök besök = new LäkarBesök(patientNummer, besöksNummer, datum, tid, anställningsNummer, besöksSyfte);
            unitOfWork.LäkarBesökRepository.Add(besök);
            unitOfWork.Save();

            Patient patient = HämtaPatient(patientNummer);
            return patient;
        }

        public Patient HämtaPatient(int  patientNummer) 
        {
            Patient patient = unitOfWork.PatientRepository.FirstOrDefault(p => p.PatientNummer == patientNummer);
            unitOfWork.Save();
            return patient;
        }

       /* public Patient RegistreraNyPatient()
        {
            Patient NyPatient = new Patient();


        }*/
    }
}
