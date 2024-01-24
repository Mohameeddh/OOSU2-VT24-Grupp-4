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
        public Repository<VårdsPersonal> VårdsPersonalRepository
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
            FooRepository = new Repository<Foo>();
            BarRepository = new Repository<Bar>();
            // Initialize the tables if this is the first UnitOfWork.
            if (FooRepository.IsEmpty())
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
            FooRepository.Add(new Foo(/* ... */));
            FooRepository.Add(new Foo(/* ... */));
            FooRepository.Add(new Foo(/* ... */));
            FooRepository.Add(new Foo(/* ... */));
            BarRepository.Add(new Bar(/* ... */));
            BarRepository.Add(new Bar(/* ... */));
        }
    }
}
