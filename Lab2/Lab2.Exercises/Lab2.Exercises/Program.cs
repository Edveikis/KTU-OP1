namespace Lab2.Exercises.Register
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string dataFileName = "Dogs.csv";
            DogsRegister register = InOutUtils.ReadDogs(@"Dogs.csv");
            List<Vaccination> VaccinationsData = InOutUtils.ReadVaccinations(@"Vaccinations.csv");
            if (VaccinationsData.Count != 0) register.UpdateVaccinationsInfo(VaccinationsData);
            else Console.WriteLine("[ERROR] No vaccination file or data");
            if (register.DogsCount() != 0)
            {
                Console.WriteLine("Registro informacija:");
                InOutUtils.PrintDogs(register);

                Console.WriteLine();

                Console.WriteLine("Is viso sunu: {0}", register.DogsCount());
                Console.WriteLine("Pateliu skaicius: {0}", register.CountByGender(Gender.Female));
                Console.WriteLine("Patinu skaicius: {0}", register.CountByGender(Gender.Male));

                Console.WriteLine();

                if (VaccinationsData.Count != 0)
                {
                    Console.WriteLine("Nevakcinuoti:");
                    DogsRegister unvaccinated = register.FilterByVaccinationExpired();
                    InOutUtils.PrintDogs(unvaccinated);
                }

                Console.WriteLine();

                Dog oldestDog = register.FindOldestDogs();
                Console.WriteLine("Seniausias suo:");
                Console.WriteLine("Vardas: {0}, Veisle: {1}, Amzius: {2}", oldestDog.GetName(), oldestDog.GetBreed(), oldestDog.Age);

                Console.WriteLine();

                List<string> allBreeds = register.FindBreeds();
                Console.WriteLine("Sunu veisles:");
                InOutUtils.PrintBreeds(allBreeds);

                //Console.WriteLine();

                //Console.WriteLine("Kokios veisles sunis atrinkti?");
                //string selectedBreed = Console.ReadLine();

                //if (!String.IsNullOrEmpty(selectedBreed))
                //{
                //    DogsRegister filteredDogs = register.FilterByBreed(selectedBreed);
                //    if (filteredDogs.DogsCount() != 0)
                //    {
                //        InOutUtils.PrintDogs(filteredDogs);

                //        string fileName = selectedBreed + ".csv";
                //        InOutUtils.PrintDogsToCSVFile(filteredDogs, fileName);
                //    }
                //    else Console.WriteLine("[ERROR] Veisle {0} nerasta duomenu bazeje!", selectedBreed);
                //}
                //else Console.WriteLine("[ERROR] bloga ivestis: {0}!", selectedBreed);
            }
            else Console.WriteLine("[ERROR] Duomenu failas {0} neegzistuoja arba duomenu nera!", dataFileName);
        }
    }
}