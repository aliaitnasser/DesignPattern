using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
	/// <summary>
	/// Strategy
	/// </summary>
	public interface IExportService
	{
		void Export(Order order);
	}

	/// <summary>
	/// Concrete Satrategy
	/// </summary>
	public class JsonExportService: IExportService
	{
		public void Export(Order order)
		{
			Console.WriteLine($"Exporting {order.Name} to JSON");
		}
	}

	/// <summary>
	/// Concrete Satrategy
	/// </summary>
	public class CsvExportService: IExportService
	{
		public void Export(Order order)
		{
			Console.WriteLine($"Exporting {order.Name} to CSV");
		}
	}

	/// <summary>
	/// Context
	/// </summary>
	public class Order
	{
		public string Name { get; set; }
		public string Customer { get; set; }
		public decimal Price { get; set; }
		public int Amount { get; set; }
		public Order(string name, int amount, string customer)
		{
			Name = name;
			Amount = amount;
			Customer = customer;
		}

		public void Export(IExportService ExportService)
		{
			if(ExportService is null) throw new ArgumentNullException(nameof(ExportService));
			ExportService.Export(this);
		}
	}
}
