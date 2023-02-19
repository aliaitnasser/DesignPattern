using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade
{
	/// <summary>
	/// System class
	/// </summary>
	public class OrderService
	{
		public bool HasEnoughOrders(int customerId)
		{
			//does the customer have enough orders?
			// faking the culculation for demo purpoces
			return (customerId > 5);;
		}
	}

	/// <summary>
	/// System class
	/// </summary>
	public class CustomerDiscountBaseService
	{
		public double CalculateDiscountBase(int customerId)
		{
			// faking the culculation for demo purpoces
			return (customerId > 8) ? 10 : 20;
		}	
	}

	/// <summary>
	/// System class
	/// </summary>
	public class DayOfTheWeekFactorService
	{
		public double GetDayOfTheWeekFactor()
		{
			//faking the culculation for demo purpoces
			switch (DateTime.UtcNow.DayOfWeek)
			{
				case DayOfWeek.Sunday:
				case DayOfWeek.Monday:
					return 0.8;
				default:
					return 1.2;
			}
		}
	}

	public class DiscountFacade
	{
		private readonly OrderService _orderService = new();
		private readonly CustomerDiscountBaseService _customerDiscountBaseService = new();
		private readonly DayOfTheWeekFactorService _dayOfTheWeekFactorService = new();

		public double CalculateDiscountFacade(int customerId)
		{
			if(!_orderService.HasEnoughOrders(customerId))
				return 0;
			return _customerDiscountBaseService.CalculateDiscountBase(customerId) * _dayOfTheWeekFactorService.GetDayOfTheWeekFactor();
		}
	}
}
