using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitetsLager
{
    public class Läkemedel
    {
        public DateTime UtskrivningsDatum {  get; set; }
        public string MedicinNamn { get; set; }
        public string Dosering {  get; set; }

        public Patient PatientNummer { get; set; }

        public Läkemedel(DateTime utskrivningsDatum, string medicinNamn, string dosering, Patient patientNummer)
        {
            UtskrivningsDatum = utskrivningsDatum;
            MedicinNamn = medicinNamn;
            Dosering = dosering;
            PatientNummer = patientNummer;
        }
    }
}
