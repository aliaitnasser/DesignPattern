using Facade;

Console.Title = "Facade";

var facade = new DiscountFacade();

Console.WriteLine($"Discount for id 1: {facade.CalculateDiscountFacade(1)}");
Console.WriteLine($"Discount for id 8: {facade.CalculateDiscountFacade(8)}");