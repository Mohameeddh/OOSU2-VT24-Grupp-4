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
        public LäkarBesök BokaBesök(int patient, int besöksNummer, DateTime datum, TimeSpan tid, int anställningsNummer, string besöksSyfte)
        {
            DateTime dateTime = DateTime.Now.AddDays(12);
            LäkarBesök besök = new LäkarBesök(patient, besöksNummer, datum, tid, anställningsNummer, besöksSyfte);
            unitOfWork.LäkarBesökRepository.Add(besök);
            unitOfWork.Save();
            return besök;
        }

        public Patient HämtaPatient(int  patientNummer) 
        {
            Patient patient = unitOfWork.PatientRepository.FirstOrDefault(p => p.PatientNummer == patientNummer);
            return patient;
        }
    }
}
