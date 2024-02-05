using DataAcess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAcess
{
    public class Context
    {
        public List<Task> Tasks { get; }

        public Context()
        {
            Tasks = PrepareData();
        }

        private List<Task> PrepareData()
        {
            List<Task> tasks = new List<Task>();
            Task task1 = new Task() { Id = 1, Date = DateTime.Now, Description = "Test1", Name = "Task", Priority = "Low" };
            Task task2 = new Task() { Id = 2, Date = DateTime.Now, Description = "Test2", Name = "Task", Priority = "High" };
            Task task3 = new Task() { Id = 3, Date = DateTime.Now, Description = "Test3", Name = "Task", Priority = "Low" };
            tasks.Add(task1);
            tasks.Add(task2);
            tasks.Add(task3);

            return tasks;
        }

    }
}
