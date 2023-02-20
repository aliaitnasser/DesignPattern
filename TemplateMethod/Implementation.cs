using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethod
{
	/// <summary>
	/// Abstract Class
	/// </summary>
	public abstract class MailParser
	{
		public virtual void FindServer()
		{
			Console.WriteLine("Finding Server...");
		}

		public abstract void AuthenticateToServer();

		public string ParceHtmlMailBody(string id)
		{
			Console.WriteLine("Parsing HTML mail body...");
			return $"This is the body of the email with id:  {id}";
		}

		/// <summary>
		/// template method
		/// </summary>
		/// <param name="id"></param>
		/// <returns>The parse mail body</returns>
		public string ParceMailBody(string id)
		{
			Console.WriteLine("Parsing the Email body (from template)");
			FindServer();
			AuthenticateToServer();
			return ParceHtmlMailBody(id);
		}
	}

	public class ExchageMailParcer : MailParser
	{
		public override void AuthenticateToServer()
		{
			Console.WriteLine("Connecting to Exchange...");
		}
	}

	public class ApacheMailParser: MailParser
	{
		public override void AuthenticateToServer()
		{
			Console.WriteLine("Connecting to Apache...");
		}
	}

	public class EndoraMailParser: MailParser
	{
		public override void FindServer()
		{
			Console.WriteLine("Finding Edora server throught a custom algorithm...");
		}
		public override void AuthenticateToServer()
		{
			Console.WriteLine("Connecting to Endora...");
		}
	}

}
