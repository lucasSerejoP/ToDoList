using DOMAIN.Aggregates.Task;

namespace DOMAIN.Aggregates.TaskAggregates
{
    public interface ITaskRepository
    {
        Task<int> CreateTaskAsync(Tasks task);
        Task<Tasks> UpdateTaskAsync(Tasks task);
        Task<bool> DeleteTaskAsync(int id);
        Task<Tasks> GetByIdTasksAsync(int id);
    }
}
