using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi
{
    public class TaskContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Tasks> Tasks { get; set; }
        public TaskContext(DbContextOptions<TaskContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Adding seed data.
            List <Category> categoryInit= new List<Category>();

            categoryInit.Add(new Category() { IdCategory = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb4ef"), Name = "WorkStuff", Weight = 50 });
            categoryInit.Add(new Category() { IdCategory = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb402"), Name = "PersonalStuff", Weight = 50 });
            categoryInit.Add(new Category() { IdCategory = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb448"), Name = "HobbieStuff", Weight = 50 });

            List<Tasks> taskInit = new List<Tasks>();

            taskInit.Add(new Tasks() { IdTask = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb410"), IdCategory = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb4ef"), TaskPriorities = Priorities.Medium, Title = "Answer LinkedIn messages", TaskState = State.Done, CreateTime = DateTime.Now, TaskTime = 5 });
            taskInit.Add(new Tasks() { IdTask = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb412"), IdCategory = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb402"), TaskPriorities = Priorities.Medium, Title = "Cook lunch", TaskState = State.Done, CreateTime = DateTime.Now, TaskTime = 40 });
            taskInit.Add(new Tasks() { IdTask = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb413"), IdCategory = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb402"), TaskPriorities = Priorities.Low, Title = "Sweep kitchen floor", TaskState = State.Pendent, CreateTime = DateTime.Now, TaskTime = 0 });
            taskInit.Add(new Tasks() { IdTask = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb414"), IdCategory = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb448"), TaskPriorities = Priorities.Medium, Title = "Finish shingeki", TaskState = State.InProcess, CreateTime = DateTime.Now, TaskTime = 0 });
            taskInit.Add(new Tasks() { IdTask = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb415"), IdCategory = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb4ef"), TaskPriorities = Priorities.High, Title = "Pay health ensurance", TaskState = State.Pendent, CreateTime = DateTime.Now, TaskTime = 0 });

            modelBuilder.Entity<Category>(category =>
            {
                category.ToTable("Category");
                category.HasKey(p => p.IdCategory);
                category.Property(p => p.Name).IsRequired().HasMaxLength(150);
                category.Property(p => p.Description).IsRequired(false);
                category.Property(p => p.Weight);
                category.HasData(categoryInit);
            });

            modelBuilder.Entity<Tasks>(task =>
            {
                task.ToTable("Tasks");
                task.HasKey(p => p.IdTask);
                task.HasOne(p=> p.Category).WithMany(p => p.Tasks).HasForeignKey(p => p.IdCategory);
                task.Property(p => p.Title).IsRequired().HasMaxLength(150);
                task.Property(p => p.Description).IsRequired(false);
                task.Property(p => p.TaskPriorities);
                task.Property(p => p.CreateTime);
                task.Ignore(p => p.Summary);
                task.Property(p => p.TaskState);
                task.Property(p => p.TaskTime);
                task.Property(p => p.CloseTime);
                task.HasData(taskInit);
            });
        }
    }
}
