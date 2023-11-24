using API.Application.Models.Task;
using MediatR;

namespace API.Application.Commands
{
    public class CreateTaskCommand : IRequest<TaskCreateModel>
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
