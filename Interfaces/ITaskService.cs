using WebApi.Models;

namespace WebApi.Interfaces
{
    public interface ITaskService
    {
        IEnumerable<Tasks> Get();
        Task Insert(Tasks tasks);
        Task Update(Guid id, Tasks tasks);
        Task Delete(Guid id);
    }
}