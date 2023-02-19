using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
	/// <summary>
	/// Subject
	/// </summary>
	public interface IDocument
	{
		void DisplayDocument();
	}

	/// <summary>
	/// Real document
	/// </summary>
	public class Document: IDocument
	{
		public string? Title { get; private set; }
		public string? Content { get; private set; }
		public int AuthorId { get; private set; }
		public DateTimeOffset LastAccessed { get; private set; }
		private string _fileName;

		public Document(string filename)
		{
			_fileName = filename;
			LoadDocument(_fileName);
		}

		private void LoadDocument(string fileName)
		{
			Console.WriteLine("Excecuting expensive action: Loading a file from disk");
			//fake loading...
			Thread.Sleep(1500);

			Title = "Document Title";
			Content = "Document Content";
			AuthorId = 1;
			LastAccessed = DateTimeOffset.Now;
		}

		public void DisplayDocument()
		{
			Console.WriteLine($"Title : {Title}, content : {Content}");
		}
	}

	/// <summary>
	/// Proxy document
	/// </summary>
	public class DocumentProxy: IDocument
	{
		//private Document? _document;
		private Lazy<Document> _document;
		private string _fileName;

		public DocumentProxy(string fileName)
		{
			_fileName = fileName;
			_document = new Lazy<Document>(() => new Document(_fileName));
		}

		public void DisplayDocument()
		{
			//avoiding creating the document untill	we need it
			//if(_document == null)
			//{
			//	_document = new Document(_fileName);
			//}
			//_document.DisplayDocument();
			_document.Value.DisplayDocument();
		}
	}

	/// <summary>
	/// Protected Document Proxy
	/// </summary>
	public class ProtectedDocumentProxy: IDocument
	{
		private DocumentProxy _document;
		private string _fileName;
		private string _userRole;

		public ProtectedDocumentProxy(string fileName, string userRole)
		{
			_document = new DocumentProxy(fileName);
			_fileName = fileName;
			_userRole = userRole;
		}

		public void DisplayDocument()
		{
			Console.WriteLine($"Entering DisplayDocument in {nameof(ProtectedDocumentProxy)}");
			if(_userRole != "Admin")
			{
				throw new UnauthorizedAccessException("You are not authorized to access this document");
			}
			_document.DisplayDocument();
			Console.WriteLine($"Exeting DisplayDocument in {nameof(ProtectedDocumentProxy)}");
		}
	}
}
