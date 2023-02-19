
using AbstractFactory;

Console.Title = "Abstract Factory";

var belguimCosts = new BelgiumShoppingCardPurchaseFactory();
var shoppingCardForBelgium = new ShoppingCard(belguimCosts);
shoppingCardForBelgium.CalculateCosts();

var franceCosts = new FranceShoppingCardPurchaseFactory();
var shoppingCardForFrance = new ShoppingCard(franceCosts);
shoppingCardForFrance.CalculateCosts();
