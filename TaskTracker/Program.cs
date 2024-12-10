using System;
using System.Globalization;

namespace TaskTracker {
    class Program {
        static void Main(string[] args) {
            var taskManager = new TaskManager();

            while(true) {
                Console.Clear();
                Console.WriteLine("Task Tracker");
                Console.WriteLine("1. Add Task");
                Console.WriteLine("2. View Tasks");
                Console.WriteLine("3. Edit Task");
                Console.WriteLine("4. Mark Task as Completed");
                Console.WriteLine("5. Delete Task");
                Console.WriteLine("6. Exit");
                
                Console.Write("Enter your choice: ");

                var choice = Console.ReadLine();
                
                switch(choice) {
                    case "1":
                        AddTask(taskManager);
                        break;
                    case "2":
                        taskManager.ViewTasks();
                        break;
                    case "3":
                        EditTask(taskManager);
                        break;
                    case "4":
                          MarkTaskAsCompleted(taskManager);
                          break;
                    case "5":
                        DeleteTask(taskManager);
                        break;
                    case "6":
                        continue;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }

            
        }
        private static void AddTask(TaskManager taskManager)
        {
            Console.Clear();
            Console.WriteLine("Enter Task Details");

            Console.Write("Task Name: ");
            var name = Console.ReadLine();

            Console.Write("Description: ");
            var description = Console.ReadLine();

            Console.Write("Category: ");
            var category = Console.ReadLine();

            Console.Write("Due Date (YYYY-MM-DD): ");
            var dueDate = DateTime.Parse(Console.ReadLine());

            var task = new Task(name, description, category, dueDate);
            taskManager.AddTask(task);

            Console.WriteLine("Task added successfully!");
        }
        private static void EditTask(TaskManager taskManager)
        {
            Console.Clear();
            Console.Write("Enter task name to edit: ");
            var name = Console.ReadLine();

            var task = taskManager.FindTaskByName(name);
            if (task != null)
            {
                Console.WriteLine($"Editing task: {task.Name}");
                Console.Write("New Description: ");
                task.Description = Console.ReadLine();

                Console.Write("New Due Date (YYYY-MM-DD): ");
                task.DueDate = DateTime.Parse(Console.ReadLine());

                Console.WriteLine("Task updated successfully!");
            }
            else
            {
                Console.WriteLine("Task not found.");
            }
        }
        private static void MarkTaskAsCompleted(TaskManager taskManager)
        {
            Console.Clear();
            Console.Write("Enter task name to mark as completed: ");
            var name = Console.ReadLine();

            taskManager.MarkAsCompleted(name);
        }
        private static void DeleteTask(TaskManager taskManager)
        {
            Console.Clear();
            Console.Write("Enter task name to delete: ");
            var name = Console.ReadLine();

            taskManager.DeleteTask(name);
        }
    }
}