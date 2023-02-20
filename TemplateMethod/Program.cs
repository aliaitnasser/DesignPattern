using TemplateMethod;

Console.Title = "Template Method";

ExchageMailParcer ExchageMailParcer = new();
Console.WriteLine(ExchageMailParcer.ParceMailBody("ww2w0-9sqksq79237"));
Console.WriteLine();

ApacheMailParser ApacheMailParser = new();
Console.WriteLine(ApacheMailParser.ParceMailBody("swlkjsw972j2-ms;qlsjwqs"));
Console.WriteLine();

EndoraMailParser EndoraMailParser = new();
Console.WriteLine(EndoraMailParser.ParceMailBody("swklsw08872oje2-dlksadhoudy"));
