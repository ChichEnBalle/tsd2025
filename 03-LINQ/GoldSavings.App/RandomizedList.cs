using System;
using System.Collections.Generic;

public class RandomizedList<T>
{
    private readonly List<T> _items;
    private readonly Random _random;

    public RandomizedList()
    {
        _items = new List<T>();
        _random = new Random();
    }

    // 2.a. Add (element)
    public void Add(T element)
    {
        if (_random.Next(2) == 0) // Randomly choose 0 or 1
        {
            _items.Insert(0, element); // Add at the beginning
        }
        else
        {
            _items.Add(element); // Add at the end
        }
    }

    // 2.b. Get (int index)
    public T Get(int index)
    {
        if (index < 0 || index >= _items.Count)
        {
            throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range.");
        }

        int randomIndex = _random.Next(0, Math.Min(index + 1, _items.Count));
        return _items[randomIndex];
    }

    // 2.c. IsEmpty
    public bool IsEmpty()
    {
        return _items.Count == 0;
    }
}