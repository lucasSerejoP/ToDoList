using DOMAIN.Aggregates.Task;
using DOMAIN.Aggregates.TaskAggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INFRA.Data.Repository
{
    public class TaskRepository : ITaskRepository
    {
        public Task<int> CreateTaskAsync(Tasks task)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteTaskAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Tasks> GetByIdTasksAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Tasks> UpdateTaskAsync(Tasks task)
        {
            throw new NotImplementedException();
        }
    }
}
