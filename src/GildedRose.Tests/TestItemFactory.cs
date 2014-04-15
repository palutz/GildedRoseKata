using NUnit.Framework;
using System;
using GildedRose.Console;
using GildedRose.Console.QualityChecked;

namespace GildedRose.Tests
{
	[TestFixture ()]
	public class TestItemFactory
	{
		[Test]
		public void CreateAnAgedBrieClass()
		{
			Item aItem = new Item { 
				Name = "my Aged Brie",
				Quality = 10,
				SellIn = 10
			};

			Assert.IsInstanceOfType(typeof(AgedBrieItem), CheckedItemFactory.CreateQualityCheckedItem (aItem));
		}
	
		[Test]
		public void CreateASimpleitem()
		{
			Item aItem = new Item { 
				Name = "A simple item",
				Quality = 10,
				SellIn = 10
			};

			Assert.IsInstanceOfType(typeof(NormalItem), CheckedItemFactory.CreateQualityCheckedItem (aItem));
		}

		[Test]
		public void CreateConjuredItemClass()
		{
			Item aItem = new Item { 
				Name = "Another item Conjured",
				Quality = 10,
				SellIn = 10
			};

			Assert.IsInstanceOfType(typeof(ConjuredItem), CheckedItemFactory.CreateQualityCheckedItem (aItem));
		}

		[Test]
		public void CreateASulfurasClass()
		{
			Item aItem = new Item { 
				Name = "Not real item Sulfuras",
				Quality = 10,
				SellIn = 10
			};

			Assert.IsInstanceOfType(typeof(SulfurasItem), CheckedItemFactory.CreateQualityCheckedItem (aItem));
		}

		[Test]
		public void CreateABackstageClass()
		{
			Item aItem = new Item { 
				Name = "Metallica Backstage Ticket",
				Quality = 10,
				SellIn = 10
			};

			Assert.IsInstanceOfType(typeof(BackstageItem), CheckedItemFactory.CreateQualityCheckedItem (aItem));
		}
	}
}