using DataAcess.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Task = DataAcess.Models.Task;

namespace DataAcess.Repository.Interfaces
{
    public interface ITaskRepository
    {
        public Task<List<Task>> GetAll();

       public Task<Task> GetById(int id);

        public Task<bool> Add(Task task);

        public Task<bool> Update(Task task, int id);

        public Task<bool> Delete(int id);
    }
}
