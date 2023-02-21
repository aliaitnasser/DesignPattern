using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memento
{
	public class LedTV
	{
		public string Size { get; set; }
		public string Prise { get; set; }
		public bool isFHD { get; set; }

		public LedTV(string size, string prise, bool isFhd)
		{
			Size = size;
			Prise = prise;
			isFHD = isFhd;
		}

		public string GetDetails()
		{
			return $"Led TV [Size = {Size}, Prise : {Prise}, FHD : {isFHD}]";
		}
	}

	/// <summary>
	/// Memento
	/// </summary>
	public class Memento
	{
		public LedTV LedTV { get; set;}

		public Memento(LedTV ledTV)
		{
			LedTV = ledTV;
		}

		public string GetDetails()
		{
			return $"Memento [Led TV = {LedTV.GetDetails()}]";
		}
	}

	/// <summary>
	/// Caretaker
	/// </summary>
	public class CareTaker
	{
		private List<Memento> ledTvList = new ();
		public void AddMemento(Memento memento)
		{
			ledTvList.Add(memento);
			Console.WriteLine($"Led TV snapshot Maintaned by Caretaker: {memento.GetDetails()}");
		}

		public Memento GetMemento(int index)
		{
			return ledTvList[index];
		}
	}

	/// <summary>
	/// Originator
	/// </summary>
	public class Originator
	{
		public LedTV ledTV;

		public Memento CreateMemento()
		{
			return new Memento(ledTV);
		}

		public void SetMemento(Memento memento)
		{
			ledTV = memento.LedTV;
		}
		public string GetDetails()
		{
			return $"Led TV Generator [Led TV = {ledTV.GetDetails()}]";
		}
	}

}
