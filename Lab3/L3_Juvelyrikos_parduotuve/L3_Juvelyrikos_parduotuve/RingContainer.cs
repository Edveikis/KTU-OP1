internal class RingContainer
{
    private Ring[] rings;
    public int Count { get; private set; }
    private int capacity;

    public RingContainer(int capacity = 16)
    {
        this.capacity = capacity;
        rings = new Ring[capacity];
    }

    public Ring Get(int index)
    {
        if (index < 0 || index >= Count)
            return null;
        return rings[index];
    }

    public void Add(Ring ring)
    {
        if (Count == capacity)
            EnsureCapacity(capacity * 2);
        rings[Count++] = ring;
    }

    public void Put(Ring ring, int index)
    {
        if (index < 0 || index >= Count)
            return;

        if (Count == capacity)
            EnsureCapacity(capacity * 2);

        if (index == Count)
            Count++;
        rings[index] = ring;
    }

    public void Insert(Ring ring, int index)
    {
        if (index < 0 || index >= Count)
            return;

        if (Count == capacity)
            EnsureCapacity(capacity * 2);
        Ring[] temp = new Ring[Count + 1];

        for (int i = 0, j = 0; i < Count + 1; ++i)
        {
            if (i == index)
            {
                temp[i] = ring;
            }
            else
            {
                temp[i] = rings[j];
                ++j;
            }
        }

        rings = temp;
        ++Count;
    }

    public void Remove(Ring ring)
    {
        if (Count == 0)
            return;

        Ring[] temp = new Ring[Count - 1];
        bool ringFound = false;

        for (int i = 0, j = 0; i < Count; i++)
        {
            if (rings[i].Equals(ring) && !ringFound)
            {
                ringFound = true;
                continue;
            }

            temp[j] = rings[i];
            j++;
        }

        if (ringFound)
        {
            rings = temp;
            Count--;
        }
    }

    public void RemoveAt(int index)
    {
        if (index < 0 || index >= Count)
            return;
        Ring[] temp = new Ring[Count - 1];

        for (int i = 0, j = 0; i < Count; ++i)
        {
            if (i != index)
            {
                temp[j] = rings[i];
                j++;
            }
        }

        rings = temp;
        Count--;
    }

    public bool Contains(Ring ring)
    {
        for (int i = 0; i < Count; ++i)
            if (rings[i].Equals(ring))
                return true;

        return false;
    }

    private void EnsureCapacity(int requiredCapacity)
    {
        if (requiredCapacity > capacity)
        {
            Ring[] temp = new Ring[requiredCapacity];
            for (int i = 0; i < Count; ++i)
                temp[i] = rings[i];

            capacity = requiredCapacity;
            rings = temp;
        }
    }

    public void SortRings()
    {
        for (int i = 0; i < Count - 1; ++i)
        {
            for (int j = i + 1; j < Count; ++j)
            {
                Ring ring1 = rings[i];
                Ring ring2 = rings[j];

                if (string.Compare(ring1.Manufacturer, ring2.Manufacturer) > 0 ||
                    (string.Compare(ring1.Manufacturer, ring2.Manufacturer) == 0 && string.Compare(ring1.Name, ring2.Name) > 0))
                {
                    Put(ring2, i);
                    Put(ring1, j);
                }
            }
        }
    }
}