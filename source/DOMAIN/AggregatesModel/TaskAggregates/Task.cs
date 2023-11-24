using System.Net.Http.Headers;

namespace DOMAIN.AggregatesModel.TaskAggregates;

public class Task 
{
    private Task() {}
    public int Id { get; private set; }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public bool Completed { get; private set; }

    public static async Task<Task> CreateTask(string title, string description)
    {
        title = title.Trim();
        description = description.Trim();

        Validate(title, description);

        Task task = new Task()
        {
            Title = title,
            Description = description,
            Completed = false
        };

        return task;
    }
    
    public async Task<bool> Update(string title, string description, bool completed)
    {
        bool updated;
        title = title.Trim();
        description = description.Trim();

        Validate(title, description);

        Title = title;
        Description = description;
        Completed = completed;

        updated = true;

        return updated;  
    }

    private static void Validate(string title, string description)
    {
        if (string.IsNullOrEmpty(title))
            throw new ArgumentNullException($"É necessário informa o titulo da tarefa");
        if (string.IsNullOrEmpty(description))
            throw new ArgumentNullException($"É necessário informa a descrição da tarefa");
        if (title.Length > 50)
            throw new ArgumentException($"A quantidade máxima de caracteres é de 50");
        if (description.Length > 200)
            throw new ArgumentException($"A quantidade máxima de caracteres é de 50");
    }
}
