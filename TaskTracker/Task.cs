using System;

namespace TaskTracker {
    public class Task {
        public string Name { get; set; }
        public string Description { get; set ; }
        public string Category { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsCompleted { get; set; }
        
        // Constructor to initialize a new task
        public Task(string name, string description, string category, DateTime dueDate)
        {
            Name = name;
            Description = description;
            Category = category;
            DueDate = dueDate;
            IsCompleted = false;  // Initially, task is not completed
        }
        
        // Method to mark a task as completed
        public void MarkAsCompleted()
        {
            IsCompleted = true;
        }
    }
}