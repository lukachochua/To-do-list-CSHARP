using System;
using System.Collections.Generic;
using System.IO;

public class Program
{
    public static List<string> tasks = new List<string>();
    private const string fileName = "tasks.txt";

    static void LoadTasks()
    {
        if (File.Exists(fileName))
        {
            tasks = new List<string>(File.ReadAllLines(fileName));
        }
    }

    static void SaveTasks()
    {
        File.WriteAllLines(fileName, tasks);
    }

    static void AddTasks()
    {
        Console.WriteLine($"Current task count: {tasks.Count}");
        if (tasks.Count == 0)
        {
            Console.WriteLine("There are no tasks for now.");
        }

        Console.WriteLine("Do you want to add a task? (y/n)");
        string add = Console.ReadLine().ToLower();

        if (add != "y")
        {
            return;
        }
        else
        {
            Console.WriteLine("Add a task: ");
            string newTask = Console.ReadLine();
            tasks.Add(newTask);
            Console.WriteLine($"New task count: {tasks.Count}");
            SaveTasks(); // Save tasks after adding a new one
        }
    }

    static void Main(string[] args)
    {
        LoadTasks(); // Load tasks at the start of the program
        AddTasks();
    }
}