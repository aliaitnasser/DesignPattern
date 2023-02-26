using Observer;

Console.Title = "Observer";

var orderServer = new OrderServer();
var ticketResellerService = new TicketResellerService();
var ticketStockService = new TicketStockService();

orderServer.AddObserver(ticketResellerService);
orderServer.AddObserver(ticketStockService);

orderServer.CompleteTicketSale(1, 2);

orderServer.RemoveObserver(ticketResellerService);
Console.WriteLine();
orderServer.CompleteTicketSale(2, 3);


