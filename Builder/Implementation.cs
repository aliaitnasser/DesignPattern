using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
	/// <summary>
	/// Car
	/// </summary>
	public class Car
	{
		private readonly List<string> _parts = new();
		private readonly string _carType;

		public Car(string carType)
		{
			_carType = carType;
		}

		public void AddPart(string part)
		{
			_parts.Add(part);
		}

		public override string ToString()
		{
			var sb = new StringBuilder();
			foreach (var part in _parts)
			{
				sb.AppendLine($"Car type: {_carType} has part {part}");
			}
			return sb.ToString();			
		}
	}

	/// <summary>
	/// Builder
	/// </summary>
	public abstract class CarBuilder
	{
		public Car Car { get; private set; }
		public CarBuilder(string carType)
		{
			Car = new Car(carType);
		}

		public abstract void BuildFrame();
		public abstract void BuildEngine();
	}

	/// <summary>
	/// Concrete builder class
	/// </summary>
	public class MiniBuilder: CarBuilder
	{
		public MiniBuilder() : base("Mini") { }
		public override void BuildEngine()
		{
			Car.AddPart("Not a V8");
		}

		public override void BuildFrame()
		{
			Car.AddPart("3-door with stripes");
		}
	}

	// <summary>
	/// Concrete builder class
	/// </summary>
	public class BMWBuilder: CarBuilder
	{
		public BMWBuilder() : base("BMW") { }
		public override void BuildEngine()
		{
			Car.AddPart("has a fancy V8");
		}

		public override void BuildFrame()
		{
			Car.AddPart("5-door with metallic finish");
		}
	}

	public class Garage
	{
		private CarBuilder? _builder;

		public Garage() { }

		public void Construct(CarBuilder builder)
		{
			_builder = builder;
			_builder.BuildEngine();
			_builder.BuildFrame();
		}

	}
}
