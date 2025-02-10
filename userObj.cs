
public class User
{
    public string Name { get; set; }
    public List<Task> Tasks = new();
    internal IEnumerable<Task> tasks;

    public User(string name)
    {
        Name = name;
    }

    /// <summary>
    /// Pass in title and description for task
    /// </summary>
    /// <param name="title"></param>
    /// <param name="description"></param>
    public void AddTask(string title, string description)
    {
        Tasks.Add(new Task(title, description));
    }

    /// <summary>
    /// Pass in the Task object
    /// </summary>
    /// <param name="task"></param>
    public void AddTask(Task task)
    {
        Tasks.Add(task);
    }

    /// <summary>
    /// Deletes the task at specified index
    /// </summary>
    public void DeleteTaskByIndex(int index)
    {
        if (index >= Tasks.Count)
        {
            throw new ArgumentOutOfRangeException("This index is not valid in the User.Tasks list");
        }

        Tasks.RemoveAt(index);
    }
}

public class Task
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public bool Completed { get; set; }

    public Task(string title, string description)
    {
        Title = title;
        Description = description;

        Completed = false;
        Id = Guid.NewGuid();
    }
}