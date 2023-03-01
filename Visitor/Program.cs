using Visitor;

Console.Title = "Visitor";

var container = new Container();

container.employees.Add(new Employee(18, "John"));
container.employees.Add(new Employee(6, "Mary"));
container.customers.Add(new Customer(100, "John"));
container.customers.Add(new Customer(1200, "Mary"));

var visitor = new DiscountVisitor();

container.Accept(visitor);

Console.WriteLine($"Total discount: {visitor.TotalDiscount}");
