using DataAcess.Models;
using DataAcess.Repository.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.Repository.Implementation
{
    public class TaskRepository : ITaskRepository
    {
        private readonly Context _context;

        public TaskRepository() { 
        
            _context = new Context();
        
        }


        public async Task<bool> Add(Models.Task task)
        {
            try
            {
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

        public async Task<List<Models.Task>> GetById(int id)
        {
            try
            {
                var tasks = await System.Threading.Tasks.Task.Run(() => _context.Tasks.Where(x => x.Id == id).ToList());
                return tasks;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<bool> Update(Models.Task task, int id)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
