using System;

namespace GildedRose.Console.QualityChecked
{
	public class BackstageItem : QualityCheckedItem
	{
		#region implemented abstract members of QualityCheckedItem

		protected override int ActualQualityUpdate ()
		{
			int ret = 0;

			if (myItem.SellIn > 0) {
				if (myItem.SellIn > 5) {
					if (myItem.SellIn > 10) {
						ret = 1; // more than 10 days... increase by 1
					} else
						ret = 2; // 10 days or less... increase by 2
				} else
					ret = 3; // 5 days or less... increase by 3
				if (myItem.Quality + ret > 50) // check if we exceed 50
					ret = 50 - myItem.Quality; // so return only the amount to get to 50

				return -(ret);  // decreased by a negative number => add 
			} else
				return myItem.Quality;  // Quality must be dropped to 0
		}

		#endregion

		public BackstageItem (Item aItem)
		{
			this.myItem = aItem;
		}
	}
}

