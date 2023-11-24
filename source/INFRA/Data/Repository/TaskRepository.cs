using Microsoft.EntityFrameworkCore;
using model = DOMAIN.AggregatesModel.TaskAggregates;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace INFRA.Data.Repository
{
    public class TaskRepository : model.ITaskRepository
    {
        private readonly TaskDbContext _context;
        public TaskRepository(TaskDbContext context)
        {
            _context = context;
        }
        public async Task<bool> CheckExistenceOfTitle(string title) =>
            await _context.Task.AnyAsync(t => t.Title == title);

        public async Task<int> CreateTaskAsync(model.Task task)
        {
            await _context.AddAsync(task);
            await _context.SaveChangesAsync();
            return task.Id;
        }

        public async Task<bool> DeleteTaskAsync(model.Task task)
        {
            _context.Remove(task);
            var entries =  await _context.SaveChangesAsync();
            return entries > 0;
        }

        public async Task<model.Task?> GetByIdTasksAsync(int id) =>
            await _context.Task
            .AsNoTracking()
            .FirstOrDefaultAsync(it => it.Id == id);

        public async Task<bool> UpdateTaskAsync(model.Task task)
        {
            _context.Update(task);

            var entries = _context.SaveChanges();
            return entries > 0;
        }
    }
}
