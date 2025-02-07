//Kyler

public class toggleTask {

	public static void select_task_and_toggle(User user) {
		int option;

		do {
			Console.WriteLine("Which task would you like to toggle?");
			Console.WriteLine("  0. Cancel");

			int i = 1;
			foreach (Task task in user.tasks) {
				Console.WriteLine($"  {i}. {task.title}");
				i++;
			}
			Console.Write("> ");

			if (int.TryParse(Console.ReadLine(), out option)) {
				if (option == 0) break;
				else if (option < i) { toggle_task(user.tasks[option - 1]); break; }
				else Console.WriteLine("Please enter a valid number!");
			}
			else Console.WriteLine("Please enter a valid number!");
		} while (true);
	}

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
