using System.Text;

internal class InOut
{
    public static bool RemoveComments(string line, out string newLine)
    {
        newLine = line;
        for (int i = 0; i < line.Length - 1; i++)
            if (line[i] == '/' && line[i + 1] == '/')
            {
                newLine = line.Remove(i);
                return true;
            }
        return false;
    }

    public static bool RemoveComments(string line, ref bool inMultiLineComment, out string newLine)
    {
        newLine = line;

        if (inMultiLineComment)
        {
            int endMultiIndex = line.IndexOf("*/");
            if (endMultiIndex >= 0)
            {
                newLine = line.Substring(endMultiIndex + 2);
                inMultiLineComment = false;
                return true;
            }
            newLine = string.Empty;
            return true;
        }

        for (int i = 0; i < line.Length - 1; ++i)
        {
            if (line[i] == '/' && line[i + 1] == '/')
            {
                newLine = line.Remove(i);
                return true;
            }
            else if (line[i] == '/' && line[i + 1] == '*')
            {
                int endMultiIndex = line.IndexOf("*/", i + 2);
                if (endMultiIndex >= 0)
                {
                    newLine = line.Remove(i, endMultiIndex - i + 2);
                }
                else
                {
                    newLine = line.Remove(i);
                    inMultiLineComment = true;
                }
                return true;
            }
        }
        return false;
    }

    public static void Process(string fin, string fout, string finfo)
    {
        string[] lines = File.ReadAllLines(fin, Encoding.UTF8);
        using (var writerF = File.CreateText(fout))
        {
            using (var writerI = File.CreateText(finfo))
            {
                bool inMultiLineComment = false;
                foreach (string line in lines)
                {
                    if (line.Length > 0)
                    {
                        string newLine = line;
                        if (RemoveComments(line, out newLine))
                            writerI.WriteLine(line);
                        if (RemoveComments(line, ref inMultiLineComment, out newLine))
                            writerI.WriteLine(line);
                        if (newLine.Length > 0)
                            writerF.WriteLine(newLine);
                    }
                    else
                        writerF.WriteLine(line);
                }
            }
        }
    }
}