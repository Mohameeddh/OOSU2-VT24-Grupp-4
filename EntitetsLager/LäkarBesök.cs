﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitetsLager
{
    public class LäkarBesök
    {
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
    }
}
