using System.Text;
using System.Text.RegularExpressions;

internal class TaskUtils
{
    private static int FirstEqualLast(string line, string punctuation)
    {
        string[] parts = Regex.Split(line, "[" + punctuation + "]+");
        int equal = 0;
        foreach (string word in parts)
            if (word.Length > 0)
                if (char.ToLower(word[0]) == char.ToLower(word[word.Length - 1]))
                    equal++;
        return equal;
    }

    public static int Process(string fin, string punctuation)
    {
        string[] lines = File.ReadAllLines(fin, Encoding.UTF8);
        int equal = 0;
        foreach (string line in lines)
            if (line.Length > 0)
                equal += FirstEqualLast(line, punctuation);
        return equal;
    }
}