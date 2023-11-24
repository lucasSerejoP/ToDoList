using API.Application.Model.Task;
namespace API.Application.Queries
{
    public interface ITaskQueries
    {
        Task<List<TaskModel>> GetAllTasksAsync();
    }
}
