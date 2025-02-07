//Harry

using System.Text.Json;

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
                Console.WriteLine("Task: ", task.Title);
                Console.WriteLine("Task ID: ", task.Id);
                if (task.Completed) Console.WriteLine("Completed! Good job me!");
                else Console.WriteLine("Still needs to be done");
                Console.WriteLine("****************************");
                Console.WriteLine(task.Description);
                Console.WriteLine("****************************");

            }
        }
    }
}

public class Persistance
{
    public static void StoreUsers(List<User> users)
    {
        if (!File.Exists("./users.json")) File.Create("./users.json");
        var userJson = JsonSerializer.Serialize(users);
        File.WriteAllText("./users.json", userJson);
    }

    public static void StoreUser(User user)
    {
        if (!File.Exists("./users.json")) File.Create("./users.json");
        var userJson = JsonSerializer.Serialize(user);
        File.WriteAllText("./users.json", userJson);
    }

    public static List<User> getUsers()
    {
        if(!File.Exists("./users.json")) return new List<User>();
        else
        {
            var userJson = File.ReadAllText("./users.json");
            List<User>? usersList = JsonSerializer.Deserialize<List<User>>(userJson);
            return usersList;
        }
    }
    public static User getUser()
    {
        if(!File.Exists("./users.json")) return null;
        else
        {
            var userJson = File.ReadAllText("./users.json");
            User? user = JsonSerializer.Deserialize<User>(userJson);
            return user;
        }
    }
}