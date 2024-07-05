using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
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

    static void ViewTasks()
    {
        if (tasks.Count == 0)
        {
            Console.WriteLine("There are no tasks for now.");
        }
        else
        {
            Console.WriteLine("Current tasks:");
            for (int i = 0; i < tasks.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {tasks[i]}");
            }
        }
    }

    static void AddTasks()
    {
        Console.WriteLine("Add a task: ");
        string newTask = Console.ReadLine();
        tasks.Add(newTask);
        Console.WriteLine($"Task added. New task count: {tasks.Count}");
        SaveTasks();
    }

    static void DisplayMenu()
    {
        Console.WriteLine("\n--- To-Do List App ---");
        Console.WriteLine("1. Add a task");
        Console.WriteLine("2. View existing tasks");
        Console.WriteLine("3. Exit");
        Console.Write("Choose a desired option: ");
    }

    static void Main(string[] args)
    {
        LoadTasks();
        while (true)
        {
            DisplayMenu();
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddTasks();
                    break;
                case "2":
                    ViewTasks();
                    break;
                case "3":
                    Console.WriteLine("Exiting an App.");
                    return;
                default:
                    Console.WriteLine("invalid option. Please try again.");
                    break;
            }
        }
    }
}