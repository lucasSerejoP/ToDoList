using API.Application.Model.Task;
using MediatR;

namespace API.Application.Commands
{
    public class CreateTaskCommand : IRequest<TaskModel>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Completed { get; set; }
    }
}
