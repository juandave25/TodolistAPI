using DataAcess.Models;
using DataAcess.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Task = DataAcess.Models.Task;

namespace TodolistAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskRepository _taskRepository;
        public TaskController(ITaskRepository taskRepository) {
            _taskRepository = taskRepository;
        } 

        [HttpGet]
        public async Task<ActionResult<List<Task>>> Get()
        {
           var tasks = await  _taskRepository.GetAll();
            return Ok(tasks);
        }

        [HttpPost]
        public async Task<ActionResult<List<Task>>> Post([FromBody] Task task)
        {
            var response = await _taskRepository.Add(task);
            if (response)
            {
                return NoContent();
            }
            else
            {
                return StatusCode(500);
            }
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<List<Task>>> Put([FromBody] Task task, int id)
        {
            var response = await _taskRepository.Update(task, id);
            if (response)
            {
                return NoContent();
            }
            else
            {
                return StatusCode(500);
            }

        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<List<Task>>> Delete(int id)
        {
            var response = await _taskRepository.Delete(id);
            if (response)
            {
                return NoContent();
            }
            else
            {
                return StatusCode(500);
            }
            
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Task>> getById(int id)
        {
            var response = await _taskRepository.GetById(id);
            if (response != null)
            {
                return Ok(response);
            }
            else
            {
                return StatusCode(500);
            }

        }
    }
}
