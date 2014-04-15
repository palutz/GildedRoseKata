using System;
using GildedRose.Console;

namespace GildedRose.Console.QualityChecked
{
	public class AgedBrieItem : QualityCheckedItem
	{
		#region implemented abstract members of QualityCheckedItem

		protected override int ActualQualityUpdate ()
		{
			if (myItem.Quality < 50)
				return -1; // Decrease the quality by a negative factor = increase. ;)
			else
				return 0;
		}

		#endregion

		public AgedBrieItem(Item aItem)
		{
			this.myItem = aItem;
		}
	}
}

