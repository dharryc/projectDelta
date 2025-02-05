public class User
{
    public List<Task> tasks;
}

public class Task
{
    public Guid id;
    public string title;
    public string description;
    public bool completed;
}