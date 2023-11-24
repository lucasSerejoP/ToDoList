using API.Application.Models.Task;
using MediatR;
using Microsoft.AspNetCore.Server.IIS.Core;
using model = DOMAIN.AggregatesModel.TaskAggregates;

namespace API.Application.Commands
{
    public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, TaskCreateModel>
    {
        private readonly model.ITaskRepository _taskRepository;
        public CreateTaskCommandHandler(model.ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }
        public async Task<TaskCreateModel> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new ArgumentNullException("A request não pode ser nula.");
            if (await _taskRepository.CheckExistenceOfTitle(request.Title))
                throw new ArgumentException("Já existe uma tarefa com esse títullo");

            var task = await model.Task.CreateTask(request.Title, request.Description);

            if (task.Completed)
                throw new Exception("Erro ao Cadastrar");

            await _taskRepository.CreateTaskAsync(task);

            TaskCreateModel taskCreate = new()
            {
                Id = task.Id
            };

            return taskCreate;
        }

    }
}
