using System;
using GildedRose.Console;

namespace GildedRose.Console.QualityChecked
{
	public abstract class QualityCheckedItem
	{
		protected Item myItem;

		protected abstract int ActualQualityUpdate();
		/// <summary>
		/// .
		/// </summary>
		/// <returns>The decrease amount.</returns>
		public int QualityUpdateAmount ()
		{ 
			return ActualQualityUpdate ();
		}


		protected virtual int ActualSellIInUpdate()
		{
			if (myItem.SellIn > 0)
				return 1;
			else
				return myItem.SellIn;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns>The sell in.</returns>
		public int SellInUpdateAmount() {
			return this.ActualSellIInUpdate ();
		}
	}
}

