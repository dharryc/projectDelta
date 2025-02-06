//Harry

public class PrintTask
{
    public static void PrintAllTasks(User user)
    {
        if (user.tasks.Count == 0) Console.WriteLine("Looks like you don't have any tasks!");
        else
        {
            foreach (var task in user.tasks)
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