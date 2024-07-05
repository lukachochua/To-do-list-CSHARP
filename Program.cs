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

    static void EditTask()
    {
        ViewTasks();

        if (tasks.Count == 0)
        {
            return;
        }

        if (int.TryParse(Console.ReadLine(), out int taskNumber) && taskNumber > 0 && taskNumber <= tasks.Count)
        {
            int index = taskNumber - 1;
            Console.WriteLine($"Current task: {tasks[index]}");
            Console.Write("Enter the new task description: ");
            string newDescription = Console.ReadLine();
            tasks[index] = newDescription;
            Console.WriteLine("Task updated successfully.");
            SaveTasks();
        }
        else
        {
            Console.WriteLine("Invalid task number.");
        }

    }

    static void RemoveTask()
    {
        ViewTasks(); // Show current tasks
        if (tasks.Count == 0) return; // If no tasks, return to menu

        Console.Write("Enter the number of the task you want to remove: ");
        if (int.TryParse(Console.ReadLine(), out int taskNumber) && taskNumber > 0 && taskNumber <= tasks.Count)
        {
            int index = taskNumber - 1; // Convert to zero-based index
            string removedTask = tasks[index];
            tasks.RemoveAt(index);
            Console.WriteLine($"Task removed: {removedTask}");
            SaveTasks(); // Save changes to file
        }
        else
        {
            Console.WriteLine("Invalid task number.");
        }
    }

    static void DisplayMenu()
    {
        Console.WriteLine("\n--- To-Do List App ---");
        Console.WriteLine("1. Add a task");
        Console.WriteLine("2. View existing tasks");
        Console.WriteLine("3. Edit a task");
        Console.WriteLine("4. Remove a task");
        Console.WriteLine("5. Exit");
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
                    EditTask();
                    break;
                case "4":
                    RemoveTask();
                    break;
                case "5":
                    Console.WriteLine("Exiting the App.");
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }
}