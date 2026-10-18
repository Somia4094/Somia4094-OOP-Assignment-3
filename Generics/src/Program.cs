
using System;
using System.Collections.Generic;

public class Student
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

public class StudentStore
{
    private readonly List<Student> _students = new List<Student>();

    public void Add(Student student)
    {
        _students.Add(student);
    }

    public Student? GetById(int id)
    {
        foreach (Student student in _students)
        {
            if (student.Id == id)
                return student;
        }

        return null;
    }

    public List<Student> GetAll()
    {
        return new List<Student>(_students);
    }

    public bool Remove(int id)
    {
        for (int i = 0; i < _students.Count; i++)
        {
            if (_students[i].Id == id)
            {
                _students.RemoveAt(i);
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
        StudentStore store = new StudentStore();

        store.Add(new Student(1, "Somia"));
        store.Add(new Student(2, "Ahmed"));

        Console.WriteLine(store.GetById(1));
    }

    public class Course
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

    public class CourseStore
    {
        private readonly List<Course> _courses = new List<Course>();

        public void Add(Course course)
        {
            _courses.Add(course);
        }

        public Course? GetById(int id)
        {
            foreach (Course course in _courses)
            {
                if (course.Id == id)
                    return course;
            }

            return null;
        }

        public List<Course> GetAll()
        {
            return new List<Course>(_courses);
        }

        public bool Remove(int id)
        {
            for (int i = 0; i < _courses.Count; i++)
            {
                if (_courses[i].Id == id)
                {
                    _courses.RemoveAt(i);
                    return true;
                }
            }

            return false;
        }
    }
}
