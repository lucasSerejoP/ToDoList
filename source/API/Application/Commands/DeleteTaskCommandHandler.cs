using model = DOMAIN.AggregatesModel.TaskAggregates;
using MediatR;
using DOMAIN.AggregatesModel.TaskAggregates;

namespace API.Application.Commands
{
    public class DeleteTaskCommandHandler : IRequestHandler<DeleteTaskCommand, bool>
    {
        private readonly model.ITaskRepository _taskRepository;

        public DeleteTaskCommandHandler(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }
        public async Task<bool> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
        {
            bool deleted;
            if(request == null)
                throw new ArgumentNullException("É necessário informa a tarefa que deseja excluir.");

            model.Task task = await _taskRepository.GetByIdTasksAsync(request.Id);
            if (task == null)
                throw new Exception("Não foi possível encontrar a tarefa informada");

            if (!await _taskRepository.DeleteTaskAsync(task))
                throw new Exception("Erro ao deletar tarefa");

            deleted = true;

            return deleted;
        }
    }
}
