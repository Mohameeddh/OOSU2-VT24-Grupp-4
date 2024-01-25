using System;
using EntitetLager;
using System.Diagnostics;

namespace DataLayer
{
    /// <summary>
    /// This class is used to access the storage in the application.
    /// </summary>
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
            PatientRepository.Add(new Patient("Mohamed", 870812, "Banstogatan", 0311134958, "Mohamed@hotmail.com", 1723));
            PatientRepository.Add(new Patient("Mohamed", 870812, "Banstogatan", 0311134958, "Mohamed@hotmail.com", 1221));
            PatientRepository.Add(new Patient("Mohamed", 870812, "Banstogatan", 0311134958, "Mohamed@hotmail.com", 144));
            PatientRepository.Add(new Patient("Mohamed", 870812, "Banstogatan", 0311134958, "Mohamed@hotmail.com", 123));
            VårdsPersonalRepository.Add(new Läkare(144, "Stefan", "Allmänläkare", 123456, "Muskelskador"));
            LäkarBesökRepository.Add(new LäkarBesök(1221, 12, new DateTime(2021, 09, 10), new TimeSpan(10, 10, 10), 19882, "Smärta i bröstkorgen"));
            //LäkarBesökRepository.Add(new LäkarBesök(/* ... */));
            //LäkarBesökRepository.Add(new LäkarBesök(/* ... */));
            //LäkarBesökRepository.Add(new LäkarBesök(/* ... */));
        }
    }
}
