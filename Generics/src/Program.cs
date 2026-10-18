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
        students.Add(new Student(2, "Ahmed"));
        students.Add(new Student(3, "Mona"));
        students.Add(new Student(4, "Ali"));
        students.Add(new Student(5, "Sara"));

        Store<Course> courses = new Store<Course>();
        courses.Add(new Course(101, "C#", 500));
        courses.Add(new Course(102, "SQL", 400));
        courses.Add(new Course(103, "OOP", 600));

        Console.WriteLine("Student by Id:");
        Console.WriteLine(students.GetById(1));

        Console.WriteLine("\nCourse by Id:");
        Console.WriteLine(courses.GetById(102));

        Console.WriteLine("\nDuplicate Id test:");
        try
        {
            students.Add(new Student(1, "Another Student"));
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine(ex.Message);
        }

        Console.WriteLine("\nPage 2 of students (page size 2):");
        foreach (Student student in students.GetAll().Page(2, 2))
        {
            Console.WriteLine(student);
        }

        Console.WriteLine("\nFind course by Id using List<Course>:");
        List<Course> courseList = new List<Course>
        {
            new Course(101, "C#", 500),
            new Course(102, "SQL", 400),
            new Course(103, "OOP", 600)
        };

        Console.WriteLine(courseList.FindById(103));

        Console.WriteLine("\nCourse Id dictionary:");
        IReadOnlyDictionary<int, Course> courseDictionary =
            courseList.ToIdDictionary();

        Console.WriteLine(courseDictionary[101]);

    }
}

