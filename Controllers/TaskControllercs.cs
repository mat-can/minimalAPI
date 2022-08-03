using Microsoft.AspNetCore.Mvc;
using WebApi.Interfaces;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService taskService;
        public TaskController(ITaskService taskService)
        {
            this.taskService = taskService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(taskService.Get());
        }
        [HttpPost]
        public IActionResult Post([FromBody] Tasks task)
        {
            taskService.Insert(task);
            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] Tasks task)
        {
            taskService.Update(id, task);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            taskService.Delete(id);
            return Ok();
        }
    }
}