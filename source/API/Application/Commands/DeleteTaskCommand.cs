using MediatR;
using System.Text.Json.Serialization;

namespace API.Application.Commands
{
    public class DeleteTaskCommand : IRequest<bool>
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Completed { get; set; }
    }
}
