using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
	/// <summary>
	/// Component as an interface
	/// </summary>
	public interface IMailService
	{
		bool SendMail(string message);
	}

	/// <summary>
	/// Concrete component 1
	/// </summary>
	public class CloudMailService: IMailService
	{
		public bool SendMail(string message)
		{
			Console.WriteLine($"Message \"{message}\" was send via {nameof(CloudMailService)}");
			return true;
		}
	}

	/// <summary>
	/// Concrete component 2
	/// </summary>
	public class OnPromiseMailService: IMailService
	{
		public bool SendMail(string message)
		{
			Console.WriteLine($"Message \"{message}\" was send via {nameof(OnPromiseMailService)}");
			return true;
		}
	}

	/// <summary>
	/// Decorator
	/// </summary>
	public abstract class MailServiceDecorator: IMailService
	{
		private IMailService _mailService;

		public MailServiceDecorator(IMailService mailService)
		{
			_mailService = mailService;
		}

		public virtual bool SendMail(string message)
		{
			return _mailService.SendMail(message);
		}
	}

	/// <summary>
	/// Concrete decorator 1
	/// </summary>
	public class StatisticDecorator : MailServiceDecorator
	{
		public StatisticDecorator(IMailService mailService) : base(mailService) {}

		public override bool SendMail(string message)
		{
			Console.WriteLine("Statistic was collected");
			return base.SendMail(message);
		}
	}

	public class MessageDataBaseDecorator: MailServiceDecorator
	{
		public List<string> messages { get; private set; }  = new List<string>();
		public MessageDataBaseDecorator(IMailService mailService) : base(mailService) { }

		public override bool SendMail(string message)
		{
			if(base.SendMail(message))
			{
				messages.Add(message);
				return true;
			}
			return false;
		}
	}
}
