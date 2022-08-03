using WebApi.Interfaces;
using WebApi.Models;

namespace WebApi.Services
{
    public class TaskService : ITaskService
    {
        TaskContext context;
        public TaskService(TaskContext dbContext)
        {
            context = dbContext;
        }
        public IEnumerable<Tasks> Get()
        {
            return context.Tasks;
        }
        public async Task Insert(Tasks tasks)
        {
            context.Add(tasks);
            await context.SaveChangesAsync();
        }
        public async Task Update(Guid id, Tasks tasks)
        {
            var currentTask = context.Tasks.Find(id);

            if(currentTask != null)
            {
                currentTask.CreateTime = DateTime.Parse(DateTime.Now.ToShortDateString());
                currentTask.Description = tasks.Description;
                currentTask.TaskPriorities = tasks.TaskPriorities;
                currentTask.Title = tasks.Title;
                currentTask.TaskState = tasks.TaskState;

                await context.SaveChangesAsync();
            }
        }
        public async Task Delete(Guid id)
        {
            var currentTask = context.Tasks.Find(id);

            if(currentTask != null)
            {
                context.Remove(currentTask);
                await context.SaveChangesAsync();
            }
        }
    }
}