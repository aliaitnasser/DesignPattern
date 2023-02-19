using Decorator;

using System.ComponentModel.DataAnnotations;

Console.Title = "Decorator Pattern";

var cloudMailService = new CloudMailService();
var onPromiseMailService = new OnPromiseMailService();

cloudMailService.SendMail("Hello from CloudMailService");
onPromiseMailService.SendMail("Hello from OnPromiseMailService");

var statisticDecorator = new StatisticDecorator(cloudMailService);
statisticDecorator.SendMail("Hello from StatisticDecorator");

var messMessageDataBaseDecorator = new MessageDataBaseDecorator(onPromiseMailService);
messMessageDataBaseDecorator.SendMail("Hello from MessageDataBaseDecorator 1");
messMessageDataBaseDecorator.SendMail("Hello from MessageDataBaseDecorator 2");

foreach(var message in messMessageDataBaseDecorator.messages)
{
	Console.WriteLine($"Stored messages : {message}");
}