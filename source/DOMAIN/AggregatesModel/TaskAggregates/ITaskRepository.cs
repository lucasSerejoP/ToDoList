using System.Xml.Schema;

using model = DOMAIN.AggregatesModel.TaskAggregates;

namespace DOMAIN.AggregatesModel.TaskAggregates
{
    public interface ITaskRepository
    {
        Task<int> CreateTaskAsync(model.Task task);
        Task<bool> UpdateTaskAsync(model.Task task);
        Task<bool> DeleteTaskAsync(model.Task task);
        Task<model.Task?> GetByIdTasksAsync(int id);
        Task<bool> CheckExistenceOfTitle(string title);
    }
}
