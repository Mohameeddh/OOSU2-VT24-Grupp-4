using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EntitetLager
{
    public class LäkarBesök
    {
        public int PatientNummer { get; set; }
        public int BesöksNummer { get; set; }
        public DateTime BesöksDatum { get; set; }
        public TimeSpan Tid { get; set; }
        public int AnställningsNummer { get; set; }
        public string BesöksSyfte { get; set; }

        public List<Patient> Patienter = new List<Patient>();



        public LäkarBesök(int patientNummer, int besöksNummer, DateTime besöksDatum, TimeSpan tid, int anställningsNummer, string besöksSyfte)
        {
            this.PatientNummer = patientNummer;
            this.BesöksNummer = besöksNummer;
            this.BesöksDatum = besöksDatum;
            this.Tid = tid;
            this.AnställningsNummer = anställningsNummer;
            this.BesöksSyfte = besöksSyfte;
        }

        public int BesöksTider(int patientnummer, int besöksNummer, DateTime datum, TimeSpan tid, int anställningsNummer, string besöksSyfte)
        {
            return PatientNummer = patientnummer;
        }
    }
}
