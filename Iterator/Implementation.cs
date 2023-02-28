using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterator
{
	public class Person
	{
		public string Name { get; set; }
		public string Country { get; set; }

		public Person(string name, string country)
		{
			Name = name;
			Country = country;
		}
	}

	/// <summary>
	/// Iterator
	/// </summary>
	public interface IPeopleIterator
	{
		Person First();
		Person Next();
		bool IsDone { get; }
		Person Current { get; }
	}

	/// <summary>
	/// Aggregate
	/// </summary>
	public interface IPeopleCollection
	{
		IPeopleIterator CreateIterator();
	}

	/// <summary>
	/// Concrete aggragate
	/// </summary>
	public class PeopleCollection: List<Person>, IPeopleCollection
	{
		public IPeopleIterator CreateIterator()
		{
			return new PeopeIteratore(this);
		}
	}

	/// <summary>
	/// Concrete iterator
	/// </summary>
	public class PeopeIteratore: IPeopleIterator
	{
		private PeopleCollection _people;
		private int _current = 0;

		public PeopeIteratore(PeopleCollection people)
		{
			_people = people;
		}
		public bool IsDone
		{
			get { return _current >= _people.Count; }
		}

		public Person Current
		{
			get { return _people.OrderBy(p => p.Name).ToList()[_current]; }
		}

		public Person First()
		{
			_current = 0;
			return _people.OrderBy(p => p.Name).First();
		}

		public Person Next()
		{
			_current++;
			if(!IsDone)
			{
				return _people.OrderBy(p => p.Name).ToList()[_current];
			}
			else
			{
				return null;
			}
		}
	}
}
