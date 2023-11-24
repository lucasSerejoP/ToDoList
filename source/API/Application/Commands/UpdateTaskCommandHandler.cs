using MediatR;
using model = DOMAIN.AggregatesModel.TaskAggregates;

namespace API.Application.Commands
{
    public class UpdateTaskCommandHandler : IRequestHandler<UpdateTaskCommand, bool>
    {
        private readonly model.ITaskRepository _taskRepository;
        public UpdateTaskCommandHandler(model.ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }
        public async Task<bool> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
        {
            bool updated;
            model.Task task = await _taskRepository.GetByIdTasksAsync(request.Id);
            if(request is null)
                throw new ArgumentNullException("É necessário informa a tarefa que deseja editar.");
            if (task == null)
                throw new NullReferenceException("Não foi possivel localizar nenhuma tarefa com esse id");
            if(request.Title !=task.Title)
                if (await _taskRepository.CheckExistenceOfTitle(request.Title))
                    throw new InvalidOperationException("Já existe uma tarefa com esse nome");

            updated = await task.Update(request.Title, request.Description, request.Completed);

            if (!await _taskRepository.UpdateTaskAsync(task))
                throw new Exception("Erro ao atualizar dados");

            return updated;
        }
    }
}
