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
        public int BesöksNummerId { get; set; }
        public DateTime BesöksDatum { get; set; }
        public int AnställningsNummer { get; set; }
        public string BesöksSyfte { get; set; }

        public List<Patient> Patienter = new List<Patient>();
        public List<LäkarBesök> hanteradeläkarbesök { get; set; }



        public LäkarBesök(int patientNummer, int besöksNummer, DateTime besöksDatum, int anställningsNummer, string besöksSyfte)
        {
            this.PatientNummer = patientNummer;
            this.BesöksNummerId = besöksNummer;
            this.BesöksDatum = besöksDatum;
            this.AnställningsNummer = anställningsNummer;
            this.BesöksSyfte = besöksSyfte;
            hanteradeläkarbesök = new List<LäkarBesök>();
        }

        public int BesöksTider(int patientnummer, int besöksNummer, DateTime datum, int anställningsNummer, string besöksSyfte)
        {
            return PatientNummer = patientnummer;
        }
    }
}
