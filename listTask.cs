using System.Text.Json;

public class PrintTask
{
    public static void PrintAllTasks(User user)
    {
        if (user.Tasks.Count == 0) Console.WriteLine("Looks like you don't have any tasks!");
        else
        {
            int i = 0;
            foreach (var task in user.Tasks)
            {
                Console.WriteLine("----------------------------");
                Console.WriteLine(task.Title);
                Console.WriteLine("Task index: " + i);
                if (task.Completed) Console.WriteLine("[Completed]");
                else Console.WriteLine("[Incomplete]");
                Console.WriteLine("****************************");
                Console.WriteLine(task.Description);
                Console.WriteLine("****************************");
                i++;
            }
        }
    }
}


public class Persistence
{

    public static void StoreUser(User user)
    {
        if (!File.Exists("./users.json")) File.Create("./users.json");
        var userJson = JsonSerializer.Serialize(user);
        File.WriteAllText("./users.json", userJson);
    }

    public static User getUser()
    {
        if(!File.Exists("./users.json")) return new User();
        else
        {
            var userJson = File.ReadAllText("./users.json");
            User? user = JsonSerializer.Deserialize<User>(userJson);
            return user;
        }
    }
}