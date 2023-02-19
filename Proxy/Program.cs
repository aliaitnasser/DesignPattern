using Proxy;

Console.Title = "Proxy";

// Without proxy
Console.WriteLine("Constructing Document");
var document = new Document("test.txt");
Console.WriteLine("Document Constructed");
document.DisplayDocument();

Console.WriteLine();

//with proxy
Console.WriteLine("Constructing Document");
var documentProxy = new DocumentProxy("test.txt");
Console.WriteLine("Document Constructed");
documentProxy.DisplayDocument();

Console.WriteLine();

//with chained proxy
Console.WriteLine("Constructing Document");
var protectedDocumentProxy = new ProtectedDocumentProxy("test.txt", "Admin");
Console.WriteLine("Document Constructed");
protectedDocumentProxy.DisplayDocument();