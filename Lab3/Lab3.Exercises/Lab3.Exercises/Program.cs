﻿/*
 
* Išrikiuokite šunis pagal veislę ir lytį;
* Atspausdinkite sąrašą šunų, kuriuos reikia skiepyti;
* Atspausdinkite sąrašą pasirinktos veislės šunų, kuriuos reikia skiepyti. 

 */

namespace Lab3.Exercises.Register
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string dataFileName = "Dogs.csv";
            DogsContainer container = InOutUtils.ReadDogs(@"Dogs.csv");
            DogsContainer containerCopy = new DogsContainer(container);
            DogsRegister register = new DogsRegister(container);

            container.Sort();

            List<Vaccination> VaccinationsData = InOutUtils.ReadVaccinations(@"Vaccinations.csv");
            if (VaccinationsData.Count != 0) register.UpdateVaccinationsInfo(VaccinationsData);
            else Console.WriteLine("[ERROR] No vaccination file or data");
            if (register.DogsCount() != 0)
            {
                Console.WriteLine("Registro informacija:");
                InOutUtils.PrintDogs(container);

                Console.WriteLine();

                Console.WriteLine("Is viso sunu: {0}", register.DogsCount());
                Console.WriteLine("Pateliu skaicius: {0}", register.CountByGender(Gender.Female));
                Console.WriteLine("Patinu skaicius: {0}", register.CountByGender(Gender.Male));

                Console.WriteLine();

                if (VaccinationsData.Count != 0)
                {
                    Console.WriteLine("Nevakcinuoti:");
                    DogsContainer unvaccinated = register.FilterByVaccinationExpired();
                    InOutUtils.PrintDogs(container);

                    Console.WriteLine("Kokios veisles sunis atrinkti?");
                    string selectedBreed = Console.ReadLine();

                    Console.WriteLine();

                    if (!String.IsNullOrEmpty(selectedBreed))
                    {
                        DogsContainer filteredDogs = register.FilterByBreed(selectedBreed);
                        if (filteredDogs.Count != 0)
                        {
                            Console.WriteLine("Reikia skiepyti (" + selectedBreed + ")");
                            InOutUtils.PrintDogs(unvaccinated.Intersect(filteredDogs));
                        }
                        else Console.WriteLine("[ERROR] Veisle {0} nerasta duomenu bazeje!", selectedBreed);
                    }
                    else Console.WriteLine("[ERROR] bloga ivestis: {0}!", selectedBreed);
                }

                Console.WriteLine();

                Dog oldestDog = register.FindOldestDogs();
                Console.WriteLine("Seniausias suo:");
                Console.WriteLine("Vardas: {0}, Veisle: {1}, Amzius: {2}", oldestDog.GetName(), oldestDog.GetBreed(), oldestDog.Age);

                Console.WriteLine();

                List<string> allBreeds = register.FindBreeds();
                Console.WriteLine("Sunu veisles:");
                InOutUtils.PrintBreeds(allBreeds);

                Console.WriteLine();

                InOutUtils.PrintDogs(containerCopy);
            }
            else Console.WriteLine("[ERROR] Duomenu failas {0} neegzistuoja arba duomenu nera!", dataFileName);
        }
    }
}