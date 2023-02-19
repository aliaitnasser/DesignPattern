using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge
{
	/// <summary>
	/// Abstraction
	/// </summary>
	public abstract class Menu
	{
		public readonly ICoupon _coupon = null!; 
		public abstract int CalculatePrice();
		public Menu(ICoupon coupon)
		{
			_coupon = coupon;
		}
	}
	/// <summary>
	/// Implementor
	/// </summary>
	public interface ICoupon
	{
		int CouponValue { get; }
	}

	/// <summary>
	/// Concrete Implementor
	/// </summary>
	public class OneEuroCoupon : ICoupon
	{
		public int CouponValue => 1;
	}

	/// <summary>
	/// Concrete Implementor
	/// </summary>
	public class TwoEuroCoupon: ICoupon
	{
		public int CouponValue => 2;
	}

	public class BreakfastMenu : Menu
	{
		public BreakfastMenu(ICoupon coupon) : base(coupon) {}
		public override int CalculatePrice() => 10 - _coupon.CouponValue;
	}

	public class LunchMenu : Menu
	{
		public LunchMenu(ICoupon coupon) : base(coupon) {}
		public override int CalculatePrice() => 20 - _coupon.CouponValue;
	}
}
