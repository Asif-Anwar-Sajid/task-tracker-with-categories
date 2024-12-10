using System;
using System.Collections.Generic;
using System.IO.Compression;

namespace TaskTracker {
    public class TaskManager {
        private List<Task> tasks;

        public TaskManager() {
            tasks = new List<Task>();
        }

        // Add a new task to the list
        public void AddTask(Task task) {
            tasks.Add(task);
        }
         // View all tasks
        public void ViewTasks()
        {
            if (tasks.Count == 0)
            {
                Console.WriteLine("No tasks available.");
                return;
            }
            foreach(var task in tasks) {
                string status = task.IsCompleted ? "Completed" : "Pending";
                Console.WriteLine($"Task: {task.Name}");
                Console.WriteLine($"Category: {task.Category}");
                Console.WriteLine($"Due Date: {task.DueDate.ToShortDateString()}");
                Console.WriteLine($"Status: {status}");
                Console.WriteLine($"Description: {task.Description}");
                Console.WriteLine(new string('-', 30));
            }
        }
        // Find a task by name
        public Task FindTaskByName(string name)
        {
            return tasks.Find(task => task.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }
        // Delete a task by name
        public void DeleteTask(string name) {
            var task = FindTaskByName(name);
            if (task != null)
            {
                tasks.Remove(task);
                Console.WriteLine($"Task '{name}' deleted successfully.");
            }
            else
            {
                Console.WriteLine($"Task '{name}' not found.");
            }
        }

        // Mark a task as completed
        public void MarkAsCompleted(string name) {
            var task = FindTaskByName(name);
            if(task!=null) {
                task.MarkAsCompleted();
                Console.WriteLine($"Task '{name}' marked as completed.");
            }
            else
            {
                Console.WriteLine($"Task '{name}' not found.");
            }
        }
    }
}