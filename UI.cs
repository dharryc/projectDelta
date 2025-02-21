using System.Text.Json;
var currentUser = Persistence.getUser();
if (currentUser == null)
{
    currentUser = new User();
}


while (true)
{
    Console.Clear();
    Console.WriteLine("Welcome to the HKJL To-Do List.");
    Console.WriteLine();

    Console.WriteLine();
    Console.WriteLine("To display your To-Do List press '0'");
    Console.WriteLine("To add a new task, press '1'");
    Console.WriteLine("To delete tasks, press '2'");
    Console.WriteLine("To toggle task completion, press '3'");
    Console.WriteLine("To save and exit, press '4'");

    int selection = -1;
    while (selection == -1)
    {
        try
        {
            selection = int.Parse(Console.ReadKey(true).KeyChar.ToString());
        }
        catch
        {
        }
        if (selection > 4 || selection < 0)
        {
            selection = -1;
        }
    }

    switch (selection)
    {
        case 0:
            Console.Clear();
            PrintTask.PrintAllTasks(currentUser);
            Console.ReadKey();
            break;

        case 1:
            AddTaskUI();
            break;

        case 2:
            DeleteTaskUI();
            break;

        case 3:
            Console.Clear();
            toggleTask.select_task_and_toggle(currentUser);
            break;

        case 4:
            Persistence.StoreUser(currentUser);
            Console.Clear();
            return;
    }


    void AddTaskUI()
    {
        bool correctTitle = false;

        string taskTitle = "";
        string taskDescription = "";

        while (!correctTitle)
        {
            Console.Clear();
            Console.WriteLine("Please enter the title of your new task");

            taskTitle = Console.ReadLine();
            Console.WriteLine($"Your new task will be called [{taskTitle}], is this correct? (Y/N)");

            string titleConfirm = Console.ReadKey(true).KeyChar.ToString();

            if (titleConfirm.ToLower() == "y")
                correctTitle = true;
        }

        bool correctDescription = false;

        while (!correctDescription)
        {
            Console.Clear();
            Console.WriteLine($"Please enter the description of {taskTitle}");

            taskDescription = Console.ReadLine();
            Console.WriteLine($"The description of {taskTitle} will be [{taskDescription}], is this correct? (Y/N)");

            string descriptionConfirm = Console.ReadKey(true).KeyChar.ToString();

            if (descriptionConfirm.ToLower() == "y")
                correctDescription = true;
        }

        currentUser.AddTask(taskTitle, taskDescription);
    }

    void DeleteTaskUI()
    {
        bool correctDeletion = false;
        int deleteSelection = -2;

        while (!correctDeletion)
        {

            Console.Clear();
            Console.WriteLine("Please enter the number of the task you wish to delete. To cancel, enter [-1]");
            Console.WriteLine();

            int x = 0;
            foreach (Task task in currentUser.Tasks)
            {
                Console.WriteLine($"{x}: {task.Title}");
                x++;
            }

            while (deleteSelection == -2)
            {
                try
                {
                    deleteSelection = int.Parse(Console.ReadLine());
                }
                catch { }

                if (deleteSelection == -1)
                {
                    break;
                }
                if (deleteSelection < 0 || deleteSelection > currentUser.Tasks.Count)
                    deleteSelection = -2;
            }

            if (deleteSelection == -1)
                correctDeletion = true;

            if (deleteSelection != -1)
            {

                Console.WriteLine($"Deleting task {deleteSelection}: {currentUser.Tasks[deleteSelection].Title}, is this correct? (Y/N)");

                string deletionConfirm = Console.ReadKey(true).KeyChar.ToString();

                if (deletionConfirm.ToLower() == "y")
                    correctDeletion = true;

                currentUser.DeleteTaskByIndex(deleteSelection);
            }

        }
    }
}


public class User
{
    public string Name { get; set; }
    public List<Task> Tasks { get; set; } = [];

    /// <summary>
    /// Name defaults to User
    /// </summary>
    /// <param name="name"></param>
    public User(string name = "User")
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
        Task task = new Task(title, description);
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
public class toggleTask
{

    public static void select_task_and_toggle(User user)
    {
        int option;

        do
        {
            Console.Clear();
            Console.WriteLine("Which task would you like to toggle?");
            Console.WriteLine("  0. Cancel");

            int i = 1;
            foreach (Task task in user.Tasks)
            {
                Console.WriteLine($"  {i}. {task.Title}");
                i++;
            }

            if (int.TryParse(Console.ReadKey(true).KeyChar.ToString(), out option))
            {
                if (option == 0) break;
                else if (option < i) { toggle_task(user.Tasks[option - 1]); break; }
                else Console.WriteLine("Please enter a valid number!");
            }
            else Console.WriteLine("Please enter a valid number!");
        } while (true);
    }

    public static void toggle_task(Task task)
    {
        int option;

        Console.Clear();
        Console.WriteLine($"The task {task.Title} is marked as" + (task.Completed ? " " : " not ") + "completed.");

        do
        {
            Console.WriteLine("What would you like to mark it as?");
            Console.WriteLine("  0. Cancel");
            Console.WriteLine("  1. Complete");
            Console.WriteLine("  2. Not Complete");

            if (int.TryParse(Console.ReadKey(true).KeyChar.ToString(), out option))
            {
                if (option == 0) break;
                else if (option == 1) { task.Completed = true; break; }
                else if (option == 2) { task.Completed = false; break; }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Please enter a valid number!");
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Please enter a valid number!");
            }
        } while (true);

        Console.WriteLine($"The task {task.Title} is marked as" + (task.Completed ? " " : " not ") + "completed.");
    }
}

public class PrintTask
{
    public static void PrintAllTasks(User user)
    {
        if (user.Tasks.Count == 0) Console.WriteLine("Looks like you don't have any tasks!");
        else
        {
            foreach (var task in user.Tasks)
            {
                Console.WriteLine("----------------------------");
                Console.WriteLine(task.Title);
                if (task.Completed) Console.WriteLine("[Completed]");
                else Console.WriteLine("[Incomplete]");
                Console.WriteLine("****************************");
                Console.WriteLine(task.Description);
                Console.WriteLine("****************************");
            }
        }
    }
}


public class Persistence
{

    public static void StoreUser(User user)
    {
        string storage = "./users.json";
        File.WriteAllText(storage, JsonSerializer.Serialize(user));
    }

    public static User getUser()
    {
        if (!File.Exists("./users.json"))
        {
            return new User();
        }
        else
        {
            var userJson = File.ReadAllText("./users.json");
            User? user = JsonSerializer.Deserialize<User>(userJson);
            return user;
        }
    }
}