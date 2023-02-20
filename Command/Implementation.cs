using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
	public class Employee
	{
		public int Id { get; set; }
		public string Name { get; set; }

		public Employee(int id, string name)
		{
			Id = id;
			Name = name;
		}
	}

	public class Manager: Employee
	{
		public List<Employee> employees = new();
		public Manager(int id, string name) : base(id, name) { }
	}

	public interface IEmployeeManagerRepository
	{
		void AddEmployee(int managerId, Employee employee);
		void RemoveEmployee(int managerId, Employee employee);
		bool HasEmployee(int managerId, int employeeId);
		void WriteDataStore();
	}

	public class EmployeeManagerRepository: IEmployeeManagerRepository
	{
		private List<Manager> _managers = new() { new Manager(1, "Katty"), new Manager(2, "Bob") };

		public void AddEmployee(int managerId, Employee employee)
		{
			//in real life, add additional input and error handeling
			_managers.Find(m => m.Id == managerId).employees.Add(employee);
		}

		public void RemoveEmployee(int managerId, Employee employee)
		{
			//in real life, add additional input and error handeling
			_managers.Find(m => m.Id == managerId).employees.Remove(employee);
		}

		public bool HasEmployee(int managerId, int employeeId)
		{
			//in real life, add additional input and error handeling
			return _managers.Find(m => m.Id == managerId).employees.Any(e => e.Id == employeeId);
		}

		public void WriteDataStore()
		{
			foreach(var manager in _managers)
			{
				Console.WriteLine($"Manager {manager.Id}, {manager.Name}");
				if (manager.employees.Any())
				{
					foreach (var employee in manager.employees)
					{
						Console.WriteLine($"\tEmployee {employee.Id}, {employee.Name}");
					}
				}
				else
				{
					Console.WriteLine("\tNo employees");
				}
			}
		}
	}
	public interface ICommand
	{
		void Execute();
		bool CanExecute();
		void Undo();
	}

	public class AddEmployeeCommand: ICommand
	{
		private readonly IEmployeeManagerRepository _repository;
		private readonly int _managerId;
		private readonly Employee? _employee;

		public AddEmployeeCommand(IEmployeeManagerRepository managerRepository, int managerId, Employee employee)
		{
			_employee = employee;
			_managerId = managerId;
			_repository = managerRepository;
		}
		public bool CanExecute()
		{
			if (_employee == null) return false;
			if (_repository.HasEmployee(_managerId, _employee.Id)) return false;
			return true;
		}

		public void Execute()
		{
			if (_employee == null) return;
			_repository.AddEmployee(_managerId, _employee);
		}

		public void Undo()
		{
			if (_employee == null) return;
			_repository.RemoveEmployee(_managerId, _employee);
		}
	}

	public class CommandManager
	{
		private readonly Stack<ICommand> _commands = new Stack<ICommand>();
		public void Invoke(ICommand command)
		{
			if (command.CanExecute())
			{
				command.Execute();
				_commands.Push(command);
			}
		}
		public void Undo()
		{
			if (_commands.Any())
			{
				_commands.Pop()?.Undo();
			}
		}

		public void UndoAll()
		{
			while (_commands.Any())
			{
				_commands.Pop()?.Undo();
			}
		}
	}
}
