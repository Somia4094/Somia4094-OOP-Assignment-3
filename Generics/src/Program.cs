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
