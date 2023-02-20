using Strategy;

Console.Title = "Strategy";

var order = new Order("Visual Studio License", 16, "Microsoft");
order.Export(new JsonExportService());

order.Export(new CsvExportService());
