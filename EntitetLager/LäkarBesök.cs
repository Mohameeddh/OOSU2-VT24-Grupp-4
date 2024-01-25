using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitetLager
{
    public class LäkarBesök
    {
        public Patient PatientNummer { get; set; }
        public int BesöksNummer { get; set; }
        public DateTime BesöksDatum { get; set; }
        public TimeOnly Tid { get; set; }
        public VårdPersonal AnställningsNummer { get; set; }
        public string BesöksSyfte { get; set; }
        public List<Patient> Patienter = new List<Patient>();



        public LäkarBesök(Patient patientNummer, int besöksNummer, DateTime besöksDatum, TimeOnly tid, VårdPersonal anställningsNummer, string besöksSyfte)
        {
            this.PatientNummer = patientNummer;
            this.BesöksNummer = besöksNummer;
            this.BesöksDatum = besöksDatum;
            this.Tid = tid;
            this.AnställningsNummer = anställningsNummer;
            this.BesöksSyfte = besöksSyfte;
        }
    }
}
