using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor
{
	/// <summary>
	/// Visitor
	/// </summary>
	//public interface IVisitor
	//{
	//	void VisitEmployee(Employee employee);
	//	void VisitCustomer(Customer customer);
	//}

	public interface IVisitor
	{
		void Visit(IElement element);
	}

	/// <summary>
	/// Element
	/// </summary>
	public interface IElement
	{
		void Accept(IVisitor visitor);
	}

	/// <summary>
	/// Concrete element
	/// </summary>
	public class Customer : IElement
	{
		public decimal AmountOrdred { get; private set; }
		public decimal Discount { get; set; }
		public string Name { get; private set; }

		public Customer(decimal amountOrdred, string name)
		{
			AmountOrdred = amountOrdred;
			Name = name;
		}

		public void Accept(IVisitor visitor)
		{
			//visitor.VisitCustomer(this);
			visitor.Visit(this);
			Console.WriteLine($"Visited {nameof(Customer)} {Name}, discount given: {Discount}");
		}
	}

	/// <summary>
	/// Concrete element
	/// </summary>
	public class Employee : IElement
	{
		public decimal Discount { get; set; }
		public int YearsEmployed{ get; set; }
		public string Name { get; set; }

		public Employee(int yearsEmployed, string name)
		{
			YearsEmployed = yearsEmployed;
			Name = name;
		}

		public void Accept(IVisitor visitor)
		{
			//visitor.VisitEmployee(this);
			visitor.Visit(this);
			Console.WriteLine($"Visited {nameof(Employee)} {Name}, discount given: {Discount}");
		}
	}

	public class DiscountVisitor: IVisitor
	{
		public decimal TotalDiscount { get; set; }

		public void Visit(IElement element)
		{
			if (element is Customer)
			{
				VisitCustomer((Customer)element);
			}
			else if (element is Employee)
			{
				VisitEmployee((Employee)element);
			}
		}

		private void VisitCustomer(Customer customer)
		{
			var discount = customer.AmountOrdred / 10;
			customer.Discount = discount;
			TotalDiscount += discount;
		}

		private void VisitEmployee(Employee employee)
		{
			var discount = employee.YearsEmployed < 10 ? 100 : 200;
			employee.Discount = discount;
			TotalDiscount += discount;
		}
	}

	/// <summary>
	/// Object structure
	/// </summary>
	public class Container
	{
		public List<Employee> employees { get; set; } = new ();
		public List<Customer> customers { get; set; } = new();

		public void Accept(IVisitor visitor)
		{
			foreach(var employee in employees)
			{
				employee.Accept(visitor);
			}
			foreach(var customer in customers)
			{
				customer.Accept(visitor);
			}
		}
	}
}
