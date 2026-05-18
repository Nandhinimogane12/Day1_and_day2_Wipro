using System;
using System.Collections.Generic;

class TaskSchedulerSystem
{
    static void Main()
    {
        // Queue for task execution order
        Queue<string> taskQueue = new Queue<string>();

        // Stack for undoing last executed task
        Stack<string> undoStack = new Stack<string>();

        // List for all tasks
        List<string> allTasks = new List<string>();

        // SortedDictionary for priority-based tasks
        SortedDictionary<int, string> priorityTasks = new SortedDictionary<int, string>();

        // HashSet to ensure no duplicate tasks
        HashSet<string> uniqueTasks = new HashSet<string>();

        // Adding tasks
        string[] tasks =
        {
            "Database Backup",
            "System Update",
            "Virus Scan",
            "Log Cleanup",
            "Security Check"
        };

        int priority = 1;

        foreach (string task in tasks)
        {
            if (uniqueTasks.Add(task)) // prevents duplicates
            {
                allTasks.Add(task);
                taskQueue.Enqueue(task);
                priorityTasks.Add(priority, task);
                priority++;
            }
            else
            {
                Console.WriteLine("Duplicate Task Found: " + task);
            }
        }

        // Display all tasks
        Console.WriteLine("All Tasks:");
        foreach (string task in allTasks)
        {
            Console.WriteLine(task);
        }

        // Execute tasks in queue order
        Console.WriteLine("\nExecuting Tasks:");
        while (taskQueue.Count > 0)
        {
            string currentTask = taskQueue.Dequeue();
            Console.WriteLine("Executed: " + currentTask);

            // Save to stack for undo
            undoStack.Push(currentTask);
        }

        // Undo last executed task
        Console.WriteLine("\nUndo Last Executed Task:");
        if (undoStack.Count > 0)
        {
            string lastTask = undoStack.Pop();
            Console.WriteLine("Undone Task: " + lastTask);
        }

        // Display tasks by priority
        Console.WriteLine("\nPriority-Based Tasks:");
        foreach (KeyValuePair<int, string> item in priorityTasks)
        {
            Console.WriteLine("Priority " + item.Key + ": " + item.Value);
        }
    }
}
