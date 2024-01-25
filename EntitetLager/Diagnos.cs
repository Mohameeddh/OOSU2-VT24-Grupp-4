using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitetLager
{
    public class Diagnos
    {
        public Patient PatientNummer { get; set; }
        public string DiagnosBeskrivning { get; set; }
        public DateTime Datum { get; set; }
        public string BehandlingsFörslag { get; set; }

        public Diagnos(Patient patientNummer, string diagnosBeskrivning, DateTime datum, string behandlingsFörslag)
        {
            this.PatientNummer = patientNummer;
            this.DiagnosBeskrivning = diagnosBeskrivning;
            this.Datum = datum;
            this.BehandlingsFörslag = behandlingsFörslag;
        }
    }
}
