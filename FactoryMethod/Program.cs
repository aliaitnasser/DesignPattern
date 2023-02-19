using FactoryMethod;

Console.Title = "Factory Method";

var factories = new List<DiscountServiceFactory>
{
	new CodeDiscountFactory(Guid.NewGuid()),
	new CountryDiscountFactory("US")
};

foreach(var fact in factories)
{
	var discount = fact.CreateDiscountService();
	Console.WriteLine($"Percentage {discount.DiscountPercentage} "+$"Comming from {discount}");
}
