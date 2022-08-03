using WebApi.Interfaces;
using WebApi.Models;

namespace WebApi.Services
{
    public class CategoryService : ICategoryService
    {
        TaskContext context;
        public CategoryService(TaskContext dbContext)
        {
            context = dbContext;
        }
        public IEnumerable<Category> Get()
        {
            return context.Categories;
        }
        public async Task Insert(Category category)
        {
            context.Add(category);
            await context.SaveChangesAsync();
        }
        public async Task Update(Guid id, Category category)
        {
            var currentCategory = context.Categories.Find(id);

            if(currentCategory != null)
            {
                currentCategory.Name = category.Name;
                currentCategory.Description = category.Description;
                currentCategory.Weight = category.Weight;

                await context.SaveChangesAsync();
            }
        }
        public async Task Delete(Guid id)
        {
            var currentCategory = context.Categories.Find(id);

            if(currentCategory != null)
            {
                context.Remove(currentCategory);
                await context.SaveChangesAsync();
            }
        }
    }
}