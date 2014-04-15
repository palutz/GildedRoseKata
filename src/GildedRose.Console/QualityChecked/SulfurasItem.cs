using System;

namespace GildedRose.Console.QualityChecked
{
	public class SulfurasItem : QualityCheckedItem
	{
		#region implemented abstract members of QualityCheckedItem

		protected override int ActualQualityUpdate ()
		{
			return 0; // quality doesn't decrease
		}

		#endregion

		protected override int ActualSellIInUpdate ()
		{
			return 0; // SellIn doesn't decrease
		}

		public SulfurasItem (Item aItem)
		{
			this.myItem = aItem;
		}
	}
}

