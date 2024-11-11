public class StudentContainer
{
    private Student[] students;
    public int Count { get; private set; }
    private int capacity;

    public StudentContainer(int capacity = 16)
    {
        this.capacity = capacity;
        students = new Student[capacity];
    }

    public void Add(Student student)
    {
        if (Count == capacity)
            EnsureCapacity(capacity * 2);

        students[Count++] = student;
    }

    private void EnsureCapacity(int requiredCapacity)
    {
        if (requiredCapacity > capacity)
        {
            Student[] temp = new Student[requiredCapacity];
            for (int i = 0; i < Count; i++)
                temp[i] = students[i];

            capacity = requiredCapacity;
            students = temp;
        }
    }

    public Student GetStudent(int index)
    {
        if (index < 0 || index >= Count) 
            return null;

        return students[index];
    }

    public void Sort()
    {
        bool swapped = true;
        while (swapped)
        {
            swapped = false;
            for (int i = 0; i < Count - 1; i++)
            {
                if (students[i].AverageGrade < students[i + 1].AverageGrade ||
                    (students[i].AverageGrade == students[i + 1].AverageGrade &&
                     string.Compare(students[i].Surname, students[i + 1].Surname) > 0))
                {
                    var temp = students[i];
                    students[i] = students[i + 1];
                    students[i + 1] = temp;
                    swapped = true;
                }
            }
        }
    }
}
