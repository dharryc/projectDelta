//Landon

var currentUser = new User("john doe");
currentUser.Tasks = new();


Console.Clear();
Console.WriteLine("Welcome to the HKJL To-Do List.");
Console.WriteLine();

Console.WriteLine();
Console.WriteLine("To display your To-Do List press '0'");
Console.WriteLine("To add a new task, press '1'");
Console.WriteLine("To delete tasks, press '2'");
Console.WriteLine("To toggle task completion, press '3'");

int selection = -1;
while (selection == -1)
{
    try
    {
        selection = int.Parse(Console.ReadKey(true).KeyChar.ToString());
    }
    catch
    {
        Console.WriteLine(selection);
    }
    if (selection > 3 || selection < 0)
    {
        selection = -1;
    }
}

switch (selection)
{
    case 0:
        Console.Clear();
        PrintTask.PrintAllTasks(currentUser);
        break;

    case 1:
        // AddTask();
        break;

    case 2:
        // DeleteTask();
        break;

    case 3:
        toggleTask.select_task_and_toggle(currentUser);
        break;
}
