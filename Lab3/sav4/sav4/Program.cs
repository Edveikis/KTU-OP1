namespace sav4
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = "students.csv";
            string facultyName = InOutUtils.ReadFacultyName(fileName);
            if (!string.IsNullOrEmpty(facultyName))
            {
                Console.WriteLine($"Fakulteto pavadinimas: {facultyName}");

                StudentContainer students = InOutUtils.ReadStudents(fileName);
                students.Sort();

                Console.WriteLine("Studentai su pažymiais:");
                InOutUtils.PrintStudents(students);
            } else Console.WriteLine("[ERROR] failas nerastas arba duomenys neteisingi");
        }
    }
}