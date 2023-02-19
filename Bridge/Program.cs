using Bridge;

Console.Title = "Bridge";

ICoupon coupon = new TwoEuroCoupon();

var breakfastMenu = new BreakfastMenu(coupon);
Console.WriteLine($"Breakfast menu is : {breakfastMenu.CalculatePrice()} euro.");
