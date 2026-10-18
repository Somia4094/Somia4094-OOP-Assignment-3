using System;
using System.Collections.Generic;

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
    private readonly List<T> _items = new List<T>();

    public void Add(T item)
    {
        _items.Add(item);
    }

    public T? GetById(int id)
    {
        foreach (T item in _items)
        {
            if (item.Id == id)
                return item;
        }

        return default;
    }

    public List<T> GetAll()
    {
        return new List<T>(_items);
    }

    public bool Remove(int id)
    {
        for (int i = 0; i < _items.Count; i++)
        {
            if (_items[i].Id == id)
            {
                _items.RemoveAt(i);
                return true;
            }
        }

        return false;
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
