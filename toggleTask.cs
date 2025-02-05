//Kyler

public class toggleTask {

	public static void toggle_task(Task task) {
		int option;

		Console.WriteLine($"The task {task.title} is marked as" + (task.completed ? " " : " not ") + "completed.");

		do {
			Console.WriteLine("What would you like to mark it as?");
			Console.WriteLine("  0. Cancel");
			Console.WriteLine("  1. Complete");
			Console.WriteLine("  2. Not Complete");
			Console.Write("> ");
			if (int.TryParse(Console.ReadLine(), out option)) {
				if (option == 0) break;
				else if (option == 1) { task.completed = true; break; }
				else if (option == 2) { task.completed = false; break; }
				else Console.WriteLine("Please enter a valid number!");
			}
			else Console.WriteLine("Please enter a valid number!");
		} while (true);

		Console.WriteLine($"The task {task.title} is marked as" + (task.completed ? " " : " not ") + "completed.");
	}
}
