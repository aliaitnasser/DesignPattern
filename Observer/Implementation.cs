using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
	public class TicketChange
	{
		public int Amount { get; private set; }
		public int ArtistId { get; set; }

		public TicketChange(int artistId, int amount)
		{
			Amount = amount;
			ArtistId = artistId;
		}
	}

	/// <summary>
	/// Subject
	/// </summary>
	public abstract class TicketChangeNotifier
	{
		private List<ITicketChangeObserver> _observers = new ();

		public void AddObserver(ITicketChangeObserver observer)
		{
			_observers.Add(observer);
		}

		public void RemoveObserver(ITicketChangeObserver observer)
		{
			_observers.Remove(observer);
		}

		public void NotifyObservers(TicketChange ticketChange)
		{
			foreach (var observer in _observers)
			{
				observer.Update(ticketChange);
			}
		}
	}

	/// <summary>
	/// Observer
	/// </summary>
	public interface ITicketChangeObserver
	{
		void Update(TicketChange ticketChange);
	}

	/// <summary>
	/// Concrete subject
	/// </summary>
	public class OrderServer : TicketChangeNotifier
	{ 
		public void CompleteTicketSale(int id, int amount)
		{
			Console.WriteLine($"{nameof(OrderServer)} is changing its state...");
			Console.WriteLine($"{nameof(OrderServer)} is notifying observers...");
			NotifyObservers(new TicketChange(id, amount));
		}
	}

	/// <summary>
	/// Concret observer
	/// </summary>
	public class TicketResellerService: ITicketChangeObserver
	{
		public void Update(TicketChange ticketChange)
		{
			Console.WriteLine($"{nameof(TicketResellerService)} notified of change: " +
				$"\n Ticket Id: {ticketChange.ArtistId} \n Amount: {ticketChange.Amount}");
		}
	}

	/// <summary>
	/// Concret observer
	/// </summary>
	public class TicketStockService: ITicketChangeObserver
	{
		public void Update(TicketChange ticketChange)
		{
			Console.WriteLine($"{nameof(TicketStockService)} notified of change: " +
				$"\n Ticket Id: {ticketChange.ArtistId} \n Amount: {ticketChange.Amount}");
		}
	}
}
