using System;

namespace GildedRose.Console.QualityChecked
{
	public class ConjuredItem : QualityCheckedItem
	{
		#region implemented abstract members of QualityCheckedItem

		protected override int ActualQualityUpdate ()
		{
			if (myItem.Quality > 1) {
				return 2;
			} else
				return myItem.Quality;
		}

		#endregion

		public ConjuredItem(Item aItem)
		{
			this.myItem = aItem;
		}

	}
}

