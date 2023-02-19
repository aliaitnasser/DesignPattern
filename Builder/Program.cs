using Builder;

Console.Title = "Builder";

var garage = new Garage();

var mini = new MiniBuilder();
var bmw = new BMWBuilder();

garage.Construct(mini);
Console.WriteLine(mini.Car.ToString());

garage.Construct(bmw);
Console.WriteLine(bmw.Car.ToString());