using ChainOfResonsability;

using System.ComponentModel.DataAnnotations;

Console.Title = "Chain of responsability";

var documentValide = new Document("Cv", DateTimeOffset.Now, true, true);
var documentInValide = new Document("test", DateTimeOffset.Now, false, true);

var validationChain = new DocumentTitleHandler();

validationChain
	.SetNext(new DocumentLastModifiedHandler())
	.SetNext(new DocumentMustBeApprovedByLitigationHAndler())
	.SetNext(new DocumentMustBeApprovedByManagerHAndler());

try
{
	validationChain.Handle(documentValide);
	Console.WriteLine("Document is Valide");
	validationChain.Handle(documentInValide);
	Console.WriteLine("Invalide document");
}catch(ValidationException ex)
{
	throw ex;
}

