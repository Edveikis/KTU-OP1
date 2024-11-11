public class Student
{
    public string Surname { get; set; }
    public string Name { get; set; }
    public string Group { get; set; }
    public int GradeCount { get; set; }
    public int[] Grades { get; set; }

    public Student(string surname, string name, string group, int gradeCount, int[] grades)
    {
        Surname = surname;
        Name = name;
        Group = group;
        GradeCount = gradeCount;
        Grades = grades;
    }

    public double AverageGrade
    {
        get
        {
            if (GradeCount == 0) return 0;
            double total = 0;
            foreach (var grade in Grades)
            {
                total += grade;
            }
            return total / GradeCount;
        }
    }

    public override string ToString()
    {
        return $"{Surname}, {Name}, {Group}, {string.Join(", ", Grades)}, Vidurkis: {AverageGrade:F2}";
    }
}
