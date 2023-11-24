using MediatR;

namespace API.Application.Model.Task
{
    public class TaskModel : IRequest
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Completed { get; set; }
    }
}
