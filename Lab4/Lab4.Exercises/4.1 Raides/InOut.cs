static class InOut
{
    static void WriteRepetitionToFile(string filename, StreamWriter writer, LettersFrequency letters)
    {
        for (char ch = 'a'; ch <= 'z'; ch++)
            writer.WriteLine("{0, 3:c} {1, 4:d} | {2, 3:c} {3, 4:d}", ch,
                letters.Get(ch), Char.ToUpper(ch), letters.Get(Char.ToUpper(ch)));
    }

    static void WriteLatinRepetitionToFile(string filename, StreamWriter writer, LettersFrequency letters)
    {
        char[] chars = "ąčęėįšųūž".ToCharArray();
        for (char ch = chars[0]; ch <= chars[chars.Length - 1]; ++ch)
        {
            if (chars.Contains(ch))
            {
                writer.WriteLine("{0, 3:c} {1, 4:d} |{2, 3:c} {3, 4:d}", ch,
                    letters.Get(ch), Char.ToUpper(ch), letters.Get(Char.ToUpper(ch)));
            }
        }
    }

    public static void WriteDataToFile(string filename, LettersFrequency letters)
    {
        using (StreamWriter writer = File.CreateText(filename))
        {
            WriteRepetitionToFile(filename, writer, letters);
            WriteLatinRepetitionToFile(filename, writer, letters);
        }
    }

    public static void WriteRepetitionSortedToFile(string filename, LettersFrequency letters)
    {
        using (StreamWriter writer = File.CreateText(filename))
        {
            var sortedFrequencies = letters.GetSortedFrequencies();

            foreach (var entry in sortedFrequencies)
                if (('a' <= entry.Key && entry.Key <= 'z') || ('A' <= entry.Key && entry.Key <= 'Z') || "ąĄčČęĘėĖįĮšŠųŲūŪžŽ".Contains(entry.Key))
                    writer.WriteLine("{0, 3:c} {1, 4:d}", entry.Key, entry.Value);
        }
    }
    public static void ReadRepetitions(string filename, LettersFrequency letters)
    {
        using (StreamReader reader = new StreamReader(filename))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                letters.Line = line;
                letters.Count();
            }
        }
    }

}
