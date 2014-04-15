using System;
using System.Collections.Generic;
using System.Linq;

namespace GildedRose.Console.QualityChecked
{
	public class CheckedItemFactory
	{
		protected Dictionary<string, string> pCheckedItem = new Dictionary<string ,string> {
			{ "Aged Brie", "GildedRose.Console.QualityChecked.AgedBrieItem" }, 
			{ "Sulfuras", "GildedRose.Console.QualityChecked.SulfurasItem" },
			{ "Backstage", "GildedRose.Console.QualityChecked.BackstageItem" },
			{ "Conjured", "GildedRose.Console.QualityChecked.ConjuredItem" }
		};

		public Dictionary<string, string> CheckedItem {
			get {
				return pCheckedItem;
			}
		}

		/// <summary>
		/// Creates the instance.
		/// </summary>
		/// <returns>The instance.</returns>
		/// <param name="aItem">A item.</param>
		///

		public static QualityCheckedItem CreateQualityCheckedItem(Item aItem) {
			CheckedItemFactory factory = new CheckedItemFactory ();
			var matchedItem = factory.CheckedItem.Where(cItem => aItem.Name.Contains (cItem.Key));

			if (matchedItem.Any ()) { // found a match..
				return (QualityCheckedItem)Activator.CreateInstance (Type.GetType (matchedItem.First ().Value), new [] { aItem });
			} else
				return new NormalItem (aItem);
		}
	}
}

