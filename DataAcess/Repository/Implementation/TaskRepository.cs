using DataAcess.Models;
using DataAcess.Repository.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = DataAcess.Models.Task;

namespace DataAcess.Repository.Implementation
{
    public class TaskRepository : ITaskRepository
    {
        private readonly Context _context;

        public TaskRepository() { 
        
            _context = new Context();
        
        }

        public class IdComparer : IComparer<int>
        {
            public int Compare([AllowNull] int x, [AllowNull] int y)
            {
                if(x > y)
                {
                    return 1;
                }
                else
                {
                    return -1;
                }
            }
        }

        public async Task<bool> Add(Models.Task task)
        {
            try
            {
                var lastId = _context.Tasks.OrderByDescending(x => x.Id, new IdComparer()).FirstOrDefault();
                task.Id = lastId.Id + 1;
                task.Date = DateTime.Now;
                await System.Threading.Tasks.Task.Run(() => _context.Tasks.Add(task));
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var coincidence = _context.Tasks.Where(x => x.Id == id).FirstOrDefault();
                if (coincidence != null)
                {
                    await System.Threading.Tasks.Task.Run(() => _context.Tasks.Remove(coincidence));
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Models.Task>> GetAll()
        {
            try
            {
                var tasks = await System.Threading.Tasks.Task.Run(() => _context.Tasks.ToList());
                return tasks;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Task> GetById(int id)
        {
            try
            {
                var task = await System.Threading.Tasks.Task.Run(() => _context.Tasks.Where(x => x.Id == id).FirstOrDefault());
                return task;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Update(Models.Task task, int id)
        {
            try
            {
                var coincidence = _context.Tasks.Where(x => x.Id == id).FirstOrDefault();
                if (coincidence != null)
                {
                    await System.Threading.Tasks.Task.Run(() => {
                        var updatedTask = new Models.Task() { 
                            Id = id,
                            Date = task.Date,
                            Description = task.Description,
                            Name = task.Name,
                            Priority = task.Priority,
                        };
                        _context.Tasks.Remove(coincidence);
                        _context.Tasks.Add(updatedTask);
                     });
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
