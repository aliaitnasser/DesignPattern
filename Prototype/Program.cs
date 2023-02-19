using Prototype;

Console.Title = "Prototype";

// Create a new manager
Manager manager = new Manager("John");

// Create a new employee
Employee employee = new Employee("Peter", manager);

// Clone the employee
Employee employeeClone = (Employee)employee.Clone();
Console.WriteLine("employee Clone name is " + employeeClone.Name + " and manager name is " +employeeClone.Manager.Name);

