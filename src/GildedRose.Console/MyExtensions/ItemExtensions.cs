using System;
using GildedRose.Console;
using GildedRose.Console.QualityChecked;

namespace GildedRose.Console.MyExtensions
{
	public static class ItemExtensions
	{
		public static QualityCheckedItem CreateQualityCheckedItem (this Item aItem)
		{
			return CheckedItemFactory.CreateQualityCheckedItem(aItem);
		}
	}
}

