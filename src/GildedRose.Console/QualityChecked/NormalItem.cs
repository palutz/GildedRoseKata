using System;
using GildedRose.Console.QualityChecked;

namespace GildedRose.Console
{
	public class NormalItem : QualityCheckedItem
	{
		#region implemented abstract members of QualityCheckedItem

		protected override int ActualQualityUpdate ()
		{
			if (myItem.Quality > 0) {
				if (myItem.SellIn > 0)
					return 1;
				else {
					if (myItem.Quality > 1)
						return 2;
					else
						return 1;
				}
			} else
				return myItem.Quality;
		}
			
		#endregion

		public NormalItem(Item aItem)
		{
			this.myItem = aItem;
		}
	}
}

