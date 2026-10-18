using System;
using System.Collections.Generic;
using System.Linq;

public interface IHasId
{
    int Id { get; }
}
public class Student : IHasId
{
    public int Id { get; set; }
    public string Name { get; set; }

    public Student(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public override string ToString()
    {
        return $"Student: {Id} - {Name}";
    }
}

public class Course : IHasId
{
    public int Id { get; set; }
    public string Title { get; set; }
    public decimal Price { get; set; }

    public Course(int id, string title, decimal price)
    {
        Id = id;
        Title = title;
        Price = price;
    }

    public override string ToString()
    {
        return $"Course: {Id} - {Title} - {Price}";
    }
}


public class Store<T> where T : IHasId
{
    private readonly Dictionary<int, T> _items = new Dictionary<int, T>();

    public void Add(T item)
    {
        if (_items.ContainsKey(item.Id))
        {
            throw new InvalidOperationException(
                $"An item with Id {item.Id} already exists.");
        }

        _items.Add(item.Id, item);
    }

    public T? GetById(int id)
    {
        if (_items.TryGetValue(id, out T? item))
        {
            return item;
        }

        return default;
    }

    public IReadOnlyCollection<T> GetAll()
    {
        return _items.Values.ToList().AsReadOnly();
    }

    public bool Remove(int id)
    {
        return _items.Remove(id);
    }
}

public static class EnumerableExtensions
{
    // R1: Return only the requested page.
    public static IEnumerable<T> Page<T>(
        this IEnumerable<T> source,
        int pageNumber,
        int pageSize)
    {
        if (pageNumber < 1)
            throw new ArgumentOutOfRangeException(nameof(pageNumber));

        if (pageSize < 1)
            throw new ArgumentOutOfRangeException(nameof(pageSize));

        int startIndex = (pageNumber - 1) * pageSize;
        int index = 0;

        foreach (T item in source)
        {
            if (index >= startIndex && index < startIndex + pageSize)
                yield return item;

            if (index >= startIndex + pageSize - 1)
                yield break;

            index++;
        }
    }

    // R2: Find an item by Id.
    public static T? FindById<T>(
        this IEnumerable<T> source,
        int id)
        where T : IHasId
    {
        foreach (T item in source)
        {
            if (item.Id == id)
                return item;
        }

        return default;
    }

    // R3: Convert items to a read-only dictionary keyed by Id.
    public static IReadOnlyDictionary<int, T> ToIdDictionary<T>(
        this IEnumerable<T> source)
        where T : IHasId
    {
        Dictionary<int, T> dictionary = new Dictionary<int, T>();

        foreach (T item in source)
        {
            dictionary.Add(item.Id, item);
        }

        return dictionary;
    }
}


public class Program
{
    public static void Main()
    {
        Store<Student> students = new Store<Student>();
        students.Add(new Student(1, "Somia"));

        Store<Course> courses = new Store<Course>();
        courses.Add(new Course(1, "C#", 500));

        Console.WriteLine(students.GetById(1));
        Console.WriteLine(courses.GetById(1));
    }
}
