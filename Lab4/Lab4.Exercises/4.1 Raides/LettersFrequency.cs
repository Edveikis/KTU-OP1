class LettersFrequency
{
    private const int CMax = 383;
    private int[] Frequency;
    public string Line { get; set; }

    public LettersFrequency()
    {
        Line = "";
        Frequency = new int[CMax];
        for (int i = 0; i < CMax; ++i)
            Frequency[i] = 0;
    }

    public int Get(char character)
    {
        return Frequency[character];
    }

    public void Count()
    {
        for (int i = 0; i < Line.Length; ++i)
        {
            if (('a' <= Line[i] && Line[i] <= 'z') ||
            ('A' <= Line[i] && Line[i] <= 'Z') ||
            "ąĄčČęĘėĖįĮšŠųŲūŪžŽ".Contains(Line[i]))
                Frequency[Line[i]]++;
        }
    }

    public int GetMostUsedLetter()
    {
        int biggestValue = 0;
        int i_mostUsed = -1;

        for (int i = 0; i < Frequency.Length; ++i)
        {
            if (Frequency[i] > biggestValue)
            {
                biggestValue = Frequency[i];
                i_mostUsed = i;
            }
        }

        return i_mostUsed;
    }

    public List<KeyValuePair<char, int>> GetSortedFrequencies()
    {
        var frequencyList = new List<KeyValuePair<char, int>>();
        for (int i = 0; i < Frequency.Length; i++)
                frequencyList.Add(new KeyValuePair<char, int>((char)i, Frequency[i]));

        frequencyList.Sort((x, y) => y.Value.CompareTo(x.Value));

        return frequencyList;
    }
}