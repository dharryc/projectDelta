public class User
{
    public List<Task> tasks;
}

public class Task
{
    public Guid Id;
    public string Title;
    public string Description;
    public bool Completed;

    public Task(string title, string description)
    {

    }
}