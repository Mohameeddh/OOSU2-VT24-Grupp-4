using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitetsLager
{
    public class LäkarBesök
    {
        private Patient patient;
        private DateTime datum;

        public Patient PatientNummer { get; set; }
        public int BesöksNummer { get; set; }
        public DateTime BesöksDatum { get; set; }
        public TimeOnly Tid { get; set; }
        public int ålder { get; set; }
        public VårdPersonal AnställningsNummer { get; set; }
        public string BesöksSyfte { get; set; }
        public Patient Patienter {  get; set; }

       
        public LäkarBesök(Patient patientNummer, int besöksNummer, DateTime besöksDatum, TimeOnly tid, VårdPersonal anställningsNummer, string besöksSyfte)
        {
            this.PatientNummer = patientNummer;
            this.BesöksNummer = besöksNummer;
            this.BesöksDatum = besöksDatum;
            this.Tid = tid;
            this.AnställningsNummer = anställningsNummer;
            this.BesöksSyfte = besöksSyfte;
        }

        public LäkarBesök(int besöksNummer, Patient patient, DateTime datum, string besöksSyfte, VårdPersonal anställningsNummer)
        {
            BesöksNummer = besöksNummer;
            this.patient = patient;
            this.datum = datum;
            BesöksSyfte = besöksSyfte;
            AnställningsNummer = anställningsNummer;
        }
    }
}
