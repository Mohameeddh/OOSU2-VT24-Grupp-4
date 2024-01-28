using EntitetLager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLagret
{
    public class UnitOfWork
    {
        public Repository<Patient> PatientRepository
        {
            get; private set;
        }
        public Repository<Läkare> VårdsPersonalRepository
        {
            get; private set;
        }
        public Repository<Diagnos> DiagnosRepository
        {
            get; private set;
        }
        public Repository<LäkarBesök> LäkarBesökRepository
        {
            get; private set;
        }

        public Repository<Läkemedel> LäkemedelRepository
        {
            get; private set;
        }

        /// <summary>
        /// Create a new instance.
        /// </summary>
        public UnitOfWork()
        {
            PatientRepository = new Repository<Patient>();
            VårdsPersonalRepository = new Repository<Läkare>();
            LäkarBesökRepository = new Repository<LäkarBesök>();
            LäkemedelRepository = new Repository<Läkemedel>();
            DiagnosRepository = new Repository<Diagnos>();
            // Initialize the tables if this is the first UnitOfWork.
            if (PatientRepository.IsEmpty())
            {
                Fill();
            }
        }
        /// <summary>
        /// Save the changes made. Does nothing in this case.
        /// </summary>
        public void Save()
        { }
        
        private void Fill()
        {
            #region Patient
            PatientRepository.Add(new Patient("Kalle", 870212, "Biragatan", 0313657953, "Kalle@hotmail.com", 1221));
            PatientRepository.Add(new Patient("Ela", 761010, "toolstogatan", 0312734529, "Ela@hotmail.com", 1442));
            PatientRepository.Add(new Patient("Tom", 640808, "Bansatogatan", 0311134958, "Tom@hotmail.com", 1234));
            #endregion

            #region Läkare
            VårdsPersonalRepository.Add(new Läkare(122, "Jakob", "Psykolog", 3456, "Klinisk Psykologi"));
            VårdsPersonalRepository.Add(new Läkare(133, "Ali", "Kirurg", 4233, "Urologi"));
            VårdsPersonalRepository.Add(new Läkare(144, "Lina", "Specialistläkare", 654, "Kardiologi"));
            #endregion

            #region LäkarBesök
            LäkarBesökRepository.Add(new LäkarBesök(1221, 293, new DateTime(2023, 06, 07, 08,30,00), 122, "Mår psykiskt dåligt"));
            LäkarBesökRepository.Add(new LäkarBesök(1442, 353, new DateTime(2023, 09, 02), 133, "Problem med urinvägarna"));
            LäkarBesökRepository.Add(new LäkarBesök(1234, 371, new DateTime(2023, 12, 12), 144, "Smärta i bröstkorgen"));
            #endregion
        }
    }
}
