using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResonsability
{
	public class Document
	{
		public string Title { get; set; }
		public DateTimeOffset LastModified { get; set; }
		public bool ApprovedByLitigation { get; set; }
		public bool ApprovedByManager { get; set; }
		public Document(string title, DateTimeOffset lastModified, bool approvedByLitigation, bool approvedByManager)
		{
			Title = title;
			LastModified = lastModified;
			ApprovedByLitigation = approvedByLitigation;
			ApprovedByManager = approvedByManager;
		}
	}

	/// <summary>
	/// Handler
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public interface IHandler<T> where T : class
	{
		IHandler<T> SetNext(IHandler<T> next);
		void Handle(T request);
	}

	/// <summary>
	/// Concrete handler
	/// </summary>
	public class DocumentTitleHandler: IHandler<Document>
	{
		private IHandler<Document>? _next;
		public void Handle(Document request)
		{
			if(request.Title == string.Empty)
			{
				throw new ValidationException(
					new ValidationResult("Title must be filled out"
					,new List<string>() {"Title"}),null,null);
			}
			_next?.Handle(request);
		}

		public IHandler<Document> SetNext(IHandler<Document> next)
		{
			_next = next;
			return next;
		}
	}

	/// <summary>
	/// Concrete handler
	/// </summary>
	public class DocumentLastModifiedHandler : IHandler<Document>
	{
		private IHandler<Document>? _next;
		public void Handle(Document request)
		{
			if (request.LastModified < DateTime.UtcNow.AddDays(-30))
			{
				throw new ValidationException(
					new ValidationResult("Document must be modified the last 30 days"
					,new List<string>() { "LastModified" }), null, null);
			}
			_next?.Handle(request);
		}

		public IHandler<Document> SetNext(IHandler<Document> next)
		{
			_next = next;
			return next;
		}
	}

	// <summary>
	/// Concrete handler
	/// </summary>
	public class DocumentMustBeApprovedByLitigationHAndler: IHandler<Document>
	{
		private IHandler<Document>? _next;
		public void Handle(Document request)
		{
			if (!request.ApprovedByLitigation)
			{
				throw new ValidationException(
					new ValidationResult("Document must be approved be litigation"
					, new List<string>() { "ApprovedByLitigation" }), null, null);
			}
			_next?.Handle(request);
		}

		public IHandler<Document> SetNext(IHandler<Document> next)
		{
			_next = next;
			return next;
		}
	}

	public class DocumentMustBeApprovedByManagerHAndler: IHandler<Document>
	{
		private IHandler<Document>? _next;
		public void Handle(Document request)
		{
			if (!request.ApprovedByManager)
			{
				throw new ValidationException(
					new ValidationResult("Document must be approved be a manager"
					, new List<string>() { "LastModified" }), null, null);
			}
			_next?.Handle(request);
		}

		public IHandler<Document> SetNext(IHandler<Document> next)
		{
			_next = next;
			return next;
		}
	}
}
