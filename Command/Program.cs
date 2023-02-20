using Command;

Console.Title = "Command";

CommandManager commandManager = new();
IEmployeeManagerRepository Repository = new EmployeeManagerRepository();

commandManager.Invoke(new AddEmployeeCommand(Repository, 1, new Employee(1, "Said")));
Repository.WriteDataStore();

commandManager.Invoke(new AddEmployeeCommand(Repository, 1, new Employee(2, "Mouad")));
Repository.WriteDataStore();

commandManager.Invoke(new AddEmployeeCommand(Repository, 2, new Employee(1, "Brahim")));
Repository.WriteDataStore();

commandManager.Undo();
Repository.WriteDataStore();

commandManager.Invoke(new AddEmployeeCommand(Repository, 2, new Employee(1, "Issam")));
Repository.WriteDataStore();

commandManager.UndoAll();
Repository.WriteDataStore();
