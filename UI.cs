//Landon
var currentUser = new User("User");


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
            Console.ReadKey();
            break;

        case 1:
            AddTaskUI();
            break;

        case 2:
            DeleteTaskUI();
            break;

        case 3:
            toggleTask.select_task_and_toggle(currentUser);
            break;
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
        int deleteSelection = -1;

        while (!correctDeletion)
        {

            Console.Clear();
            Console.WriteLine("Please enter the number of the task you wish to delete.");
            Console.WriteLine();

            int x = 0;
            foreach (Task task in currentUser.Tasks)
            {
                Console.WriteLine($"{x}: {task.Title}");
                x++;
            }

            while (deleteSelection == -1)
            {
                try
                {
                    deleteSelection = int.Parse(Console.ReadKey(true).KeyChar.ToString());
                }
                catch { }

                if (deleteSelection < 0 || deleteSelection > currentUser.Tasks.Count)
                    deleteSelection = -1;
            }

            Console.WriteLine($"Deleting task {deleteSelection}: {currentUser.Tasks[deleteSelection].Title}, is this correct? (Y/N)");

            string deletionConfirm = Console.ReadKey(true).KeyChar.ToString();

            if (deletionConfirm.ToLower() == "y")
                correctDeletion = true;
        }

        currentUser.DeleteTaskByIndex(deleteSelection);
    }
}