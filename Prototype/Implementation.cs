using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
	/// <summary>
	/// Prototype class
	/// </summary>
	public abstract class Person
	{
		public abstract string Name { get; set; }
		public abstract Person Clone(bool deepClone);
	}

	/// <summary>
	/// Concrete Prototype
	/// </summary>
	public class Manager: Person
	{
		public override string Name { get; set; }

		public Manager(string name)
		{
			Name = name;
		}

		public override Person Clone(bool deepClone = false)
		{
			if(deepClone)
			{
				var objAsJson = JsonConvert.SerializeObject(this);
				return JsonConvert.DeserializeObject<Manager>(objAsJson)!;
			}
			return (Person)MemberwiseClone();
		}
	}

	// <summary>
	/// Concrete Prototype
	/// </summary>
	public class Employee: Person
	{
		public override string Name { get; set; }
		public Manager Manager { get; set; }

		public Employee(string name, Manager manager)
		{
			Name = name;
			Manager = manager;
		}

		public override Person Clone(bool deepClone = false)
		{
			if (deepClone)
			{
				var objAsJson = JsonConvert.SerializeObject(this);
				return JsonConvert.DeserializeObject<Employee>(objAsJson)!;
			}
			return (Person) MemberwiseClone();
		}
	}
}
