using WebApi.Models;

namespace WebApi.Interfaces
{
    public interface ICategoryService
    {
        IEnumerable<Category> Get();
        Task Insert(Category category);
        Task Update(Guid id, Category category);
        Task Delete(Guid id);
    }
}