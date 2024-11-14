using System.Text;

static class InOut
{
    public static List<int> LongestLine(string fin)
    {
        List<int> Nos = new List<int>();
        int No = -1;
        using (StreamReader reader = new StreamReader(fin, Encoding.UTF8))
        {
            string line;
            int length = 0;
            int lineNo = 0;
            while ((line = reader.ReadLine()) != null)
            {
                if (line.Length > length)
                {
                    length = line.Length;
                    No = lineNo;
                }
                else if (line.Length == length) Nos.Add(lineNo);
                lineNo++;
            }
            Nos.Add(No);
        }
        return Nos;
    }

    public static void RemoveLine(string fin, string fout, List<int> Nos)
    {
        using (StreamReader reader = new StreamReader(fin, Encoding.UTF8))
        {
            foreach (int No in Nos)
            {
                string line;
                int lineNo = 0;
                using (var writer = File.CreateText(fout))
                {
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (No != lineNo)
                            writer.WriteLine(line);

                        lineNo++;
                    }
                }
            }
        }
    }

    public static void PrintLongestLineIDs(List<int> Nos)
    {
        foreach (int No in Nos)
            Console.WriteLine("Ilgiausios eilutės nr. {0, 4:d}", No + 1);
    }
}