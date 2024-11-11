public static class InOutUtils
{
    public static string ReadFacultyName(string fileName)
    {
        if (!File.Exists(fileName))
            return null;

        using (var reader = new StreamReader(fileName))
            return reader.ReadLine();
    }

    public static StudentContainer ReadStudents(string fileName)
    {
        StudentContainer container = new StudentContainer();

        if (!File.Exists(fileName))
            return container;

        bool skipHeader = false;
        string[] lines = File.ReadAllLines(fileName);
        
        foreach (var line in lines)
        {
            if (!skipHeader)
            {
                skipHeader = true;
                continue;
            }

            string[] values = line.Split(";");

            if (values.Length < 4) 
                continue;

            string surname = values[0].Trim();
            string name = values[1].Trim();
            string group = values[2].Trim();
            int gradeCount = int.Parse(values[3].Trim());
            int[] grades = new int[gradeCount];

            for (int i = 0; i < gradeCount; i++)
                if (i + 4 < values.Length)
                    grades[i] = int.Parse(values[i + 4].Trim());

            var student = new Student(surname, name, group, gradeCount, grades);
            container.Add(student);
        }

        return container;
    }

    public static void PrintStudents(StudentContainer container)
    {
        for (int i = 0; i < container.Count; i++)
            Console.WriteLine(container.GetStudent(i));
    }
}
