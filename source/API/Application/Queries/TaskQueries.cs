using model = DOMAIN.AggregatesModel.TaskAggregates;
using System.Data;
using System.Linq;
using System.Collections.Generic;
using Dapper;
using API.Application.Model.Task;

namespace API.Application.Queries
{
    public class TaskQueries : ITaskQueries
    {
        private readonly IDbConnection _connection;
        public TaskQueries(IDbConnection connection)
        {
            _connection = connection;
        }
        public async Task<List<TaskModel>> GetAllTasksAsync()
        {
            var query = "SELECT *FROM Task";
            var tasks = _connection.Query<TaskModel>(query);

            var taskModel = tasks.Select(task => new TaskModel { Id = task.Id, Title = task.Title, Description = task.Description, Completed = task.Completed }).ToList();

            return taskModel;
        }
    }
}
