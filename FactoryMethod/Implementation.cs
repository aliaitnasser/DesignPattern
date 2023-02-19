
namespace FactoryMethod
{
	/// <summary>
	/// Product
	/// </summary>
	public abstract class DiscountService
	{
		public abstract int DiscountPercentage { get; }
		public override string ToString() => GetType().Name;
	}

	/// <summary>
	/// Concrete Product
	/// </summary>
	public class CountryDiscountService: DiscountService
	{
		private readonly string _countryIdentifier = String.Empty;

		public CountryDiscountService(string countryIdentifier)
		{
			_countryIdentifier= countryIdentifier;
		}
		public override int DiscountPercentage
		{
			get
			{
				switch (_countryIdentifier)
				{
					case "UK":
						return 15;
					case "US":
						return 20;
					default:
						return 10;
				}
			}
		}
	}

	/// <summary>
	/// Concrete Product
	/// </summary>
	public class CodeDiscountService : DiscountService
	{
		private readonly Guid _guid;
		public CodeDiscountService(Guid guid)
		{
			_guid = guid;
		}

		public override int DiscountPercentage
		{
			get => 40;
		}
	}

	/// <summary>
	/// Creator
	/// </summary>
	public abstract class DiscountServiceFactory
	{
		public abstract DiscountService CreateDiscountService();
	}

	/// <summary>
	/// Concreate Creator
	/// </summary>
	public class CountryDiscountFactory: DiscountServiceFactory
	{
		private readonly string _countryIdentifier = String.Empty;
		public CountryDiscountFactory(string countryIdentifier)
		{
			_countryIdentifier = countryIdentifier;
		}
		public override DiscountService CreateDiscountService()
		{
			return new CountryDiscountService(_countryIdentifier);
		}
	}

	/// <summary>
	/// Concrete Creator
	/// </summary>
	public class CodeDiscountFactory : DiscountServiceFactory
	{
		private readonly Guid _guid;
		public CodeDiscountFactory(Guid guid)
		{
			_guid = guid;
		}

		public override DiscountService CreateDiscountService()
		{
			return new CodeDiscountService(_guid);
		}
	}

}
