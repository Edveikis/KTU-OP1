internal class DogsContainer
{
    private Dog[] dogs;
    public int Count { get; private set; }
    private int capacity;

    public DogsContainer(int capacity = 16)
    {
        this.capacity = capacity;
        dogs = new Dog[capacity];
    }

    // deep copy nes sukuria objekto kopijas naujam container
    public DogsContainer(DogsContainer container) : this()
    {
        for (int i = 0; i < container.Count; i++)
        {
            Dog dogCopy = new Dog(container.GetDog(i));
            this.Add(dogCopy);
        }
    }

    public void Add(Dog dog)
    {
        if (Count == capacity)
            EnsureCapacity(capacity * 2);

        dogs[Count++] = dog;
    }

    public void Put(Dog dog, int index)
    {
        if (index < 0 || index >= Count)
            return;

        if (Count == capacity)
            EnsureCapacity(capacity * 2);

        if (index == Count)
            Count++;

        dogs[index] = dog;
    }

    public void Insert(Dog dog, int index)
    {
        if (index < 0 || index >= Count)
            return;

        if (Count == capacity)
            EnsureCapacity(capacity * 2);

        Dog[] temp = new Dog[Count + 1];

        for (int i = 0, j = 0; i < Count + 1; ++i)
        {
            if (i == index)
            {
                temp[i] = dog;
            }
            else
            {
                temp[i] = dogs[j];
                ++j;
            }
        }

        dogs = temp;
        ++Count;
    }

    public void Remove(Dog dog)
    {
        if (Count == 0)
            return;

        Dog[] temp = new Dog[Count - 1];
        bool dogFound = false;

        for (int i = 0, j = 0; i < Count; i++)
        {
            if (dogs[i].Equals(dog) && !dogFound)
            {
                dogFound = true;
                continue;
            }

            temp[j] = dogs[i];
            j++;
        }

        if (dogFound)
        {
            dogs = temp;
            Count--;
        }
    }

    public void RemoveAt(int index)
    {
        if (index < 0 || index >= Count)
            return;

        Dog[] temp = new Dog[Count - 1];

        for (int i = 0, j = 0; i < Count; ++i)
        {
            if (i != index)
            {
                temp[j] = dogs[i];
                j++;
            }
        }

        dogs = temp;
        Count--;
    }

    public Dog GetDog(int index)
    {
        if (index < 0 || index >= Count)
            return null;

        return dogs[index];
    }

    public bool Contains(Dog dog)
    {
        for (int i = 0; i < Count; ++i)
            if (dogs[i].Equals(dog))
                return true;

        return false;
    }

    private void EnsureCapacity(int requiredCapacity)
    {
        if (requiredCapacity > capacity)
        {
            Dog[] temp = new Dog[requiredCapacity];
            for (int i = 0; i < Count; ++i)
                temp[i] = dogs[i];

            capacity = requiredCapacity;
            dogs = temp;
        }
    }

    public void Sort()
    {
        bool flag = true;
        while (flag)
        {
            flag = false;
            for (int i = 0; i < this.Count - 1; i++)
            {
                Dog a = this.dogs[i];
                Dog b = this.dogs[i + 1];
                if (a.CompareTo(b) > 0)
                {
                    this.dogs[i] = b;
                    this.dogs[i + 1] = a;
                    flag = true;
                }
            }
        }
    }

    public DogsContainer Intersect(DogsContainer other)
    {
        DogsContainer result = new DogsContainer();
        for (int i = 0; i < this.Count; i++)
        {
            Dog current = this.dogs[i];
            if (other.Contains(current))
            {
                result.Add(current);
            }
        }
        return result;
    }
}