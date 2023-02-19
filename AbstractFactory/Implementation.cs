using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
	public interface IShoppingCardPurchaseFactory
	{
		IDiscountService CreateDiscountService();
		IShippingService CreateShippingService();
	}

	public interface IDiscountService
	{
		int DiscountPercentage { get; }
	}
	public interface IShippingService
	{
		decimal ShippingCosts { get; }
	}

	public class BelgiumDiscountService : IDiscountService
	{
		public int DiscountPercentage => 20;
	}

	public class BelgiumShippingCostsService : IShippingService
	{
		public decimal ShippingCosts => 15;
	}

	public class FranceDiscountService : IDiscountService
	{
		public int DiscountPercentage => 10;
	}

	public class FranceShippingCostsService : IShippingService
	{
		public decimal ShippingCosts => 10;
	}

	public class BelgiumShoppingCardPurchaseFactory : IShoppingCardPurchaseFactory
	{
		public IDiscountService CreateDiscountService()
		{
			return new BelgiumDiscountService();
		}

		public IShippingService CreateShippingService()
		{
			return new BelgiumShippingCostsService();
		}
	}

	public class FranceShoppingCardPurchaseFactory : IShoppingCardPurchaseFactory
	{
		public IDiscountService CreateDiscountService()
		{
			return new FranceDiscountService();
		}

		public IShippingService CreateShippingService()
		{
			return new FranceShippingCostsService();
		}
	}

	public class ShoppingCard
	{
		private readonly IDiscountService _discountService;
		private readonly IShippingService _shippingService;
		private int _totalCosts;
		public ShoppingCard(IShoppingCardPurchaseFactory factory)
		{
			_discountService= factory.CreateDiscountService();
			_shippingService= factory.CreateShippingService();
			_totalCosts = 200;
		}

		public void CalculateCosts()
		{
			Console.WriteLine($"Total costs: " + $"{_totalCosts - (_totalCosts / 100 * _discountService.DiscountPercentage) + _shippingService.ShippingCosts }");
		}
	}


}
