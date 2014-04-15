using NUnit.Framework;
using System;
using GildedRose.Console;
using System.Collections.Generic;

namespace GildedRose.Tests
{
	[TestFixture ()]
	public class TestQuality
	{
		[SetUp]
		public void Init()
		{
			Program.Items = new List<Item> {
				new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 },
				new Item { Name = "Aged Brie", SellIn = 2, Quality = 0 },
				new Item { Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7 },
				new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 },
				new Item {
					Name = "Backstage passes to a TAFKAL80ETC concert",
					SellIn = 15,
					Quality = 20
				},
				new Item { Name = "Conjured Mana Cake", SellIn = 3, Quality = 6 }
			};
		}

		/// <summary>
		/// Once the sell by date for an item passed, the quality decrease at double speed
		/// </summary>
		[Test ()]
		public void ItemDatePassedQualityDecreaseDouble ()
		{
			int prev = Program.Items[0].Quality;
			Program.Items [0].SellIn = 0;
			Program.UpdateQuality ();
			int actual  = Program.Items[0].Quality;
			Assert.AreEqual (prev - 2, actual);
		}

		/// <summary>
		/// The quality of an item cannot be negative.
		/// </summary>
		[Test()]
		public void ItemQualityNeverNegative()
		{
			Program.Items [0].Quality = 0;
			Program.UpdateQuality ();
			int actual  = Program.Items[0].Quality;
			Assert.AreEqual (0, actual);
		}

		/// <summary>
		/// Decreases the quality by 1.
		/// 
		/// </summary>
		[Test ()]
		public void DecreaseQualityBy1 ()
		{
			int prev = Program.Items[0].Quality;
			Program.UpdateQuality ();
			int actual  = Program.Items[0].Quality;
			Assert.AreEqual (prev - 1, actual);

		}

		/// <summary>
		/// Aged brie increase quality instead decreasing.
		/// </summary>
		[Test ()]
		public void AgedBrieIncreaseQuality ()
		{
			int prev = Program.Items[1].Quality;
			Program.UpdateQuality ();
			int actual = Program.Items[1].Quality;
			Assert.AreEqual (prev+1, actual);
		}

		/// <summary>
		/// Quality cannot go over50.
		/// </summary>
		[Test()]
		public void QualityDoesntGoOver50 ()
		{
			Program.Items[1].Quality = 50;
			int prev = Program.Items[1].Quality;
			Program.UpdateQuality ();
			int actual  = Program.Items[1].Quality;
			Assert.AreEqual (prev, actual);
		}

		/// <summary>
		/// Sulfurases doesnt change quality.
		/// </summary>
		[Test()]
		public void SulfurasDoesntChangeQuality()
		{
			int prev = Program.Items[3].Quality;
			Program.UpdateQuality ();
			int actual  = Program.Items[3].Quality;
			Assert.AreEqual (prev, actual);
		}

		/// <summary>
		/// Backstages passes increase quality.
		/// </summary>
		[Test()]
		public void BackstagePassesIncreaseQuality()
		{
			int prev = Program.Items[4].Quality;
			Program.UpdateQuality ();
			int actual  = Program.Items[4].Quality;
			Assert.AreEqual (prev+1, actual);
		}

		/// <summary>
		/// Backstages passes increase quality by 2 when SellIn <= 10 days
		/// </summary>
		[Test()]
		public void BackstagePassesIncreaseQualityBy2With10days()
		{
			int prev = Program.Items[4].Quality;
			Program.Items [4].SellIn = 10;
			Program.UpdateQuality ();
			int actual  = Program.Items[4].Quality;
			Assert.AreEqual (prev+2, actual);
		}

		/// <summary>
		/// Backstages passes increase quality by 3 when SellIn <= 5 days
		/// </summary>
		[Test()]
		public void BackstagePassesIncreaseQualityBy3With5days()
		{
			int prev = Program.Items[4].Quality;
			Program.Items [4].SellIn = 5;
			Program.UpdateQuality ();
			int actual  = Program.Items[4].Quality;
			Assert.AreEqual (prev+3, actual);
		}

		/// <summary>
		/// Backstages increase quality never over50.
		/// </summary>
		[Test()]
		public void BackstagePassesIncreaseQualityNeverOver50()
		{
			Program.Items [4].Quality = 49;
			int prev = Program.Items[4].Quality;
			Program.Items [4].SellIn = 5;
			Program.UpdateQuality ();
			int actual  = Program.Items[4].Quality;
			Assert.AreEqual (50, actual);
		}

		/// <summary>
		/// Backstages quality drop to 0 after concert.
		/// </summary>
		[Test()]
		public void BackstagePassesQuality0AfterConcert()
		{
			Program.Items [4].SellIn = 0;
			Program.UpdateQuality ();
			int actual  = Program.Items[4].Quality;
			Assert.AreEqual (0, actual);
		}

		/// <summary>
		/// Conjured decrease quality double faster
		/// </summary>
		[Test()]
		public void ConjuredItemDecreaseQualityBy2()
		{
			int prev = Program.Items[5].Quality;
			Program.UpdateQuality ();
			int actual  = Program.Items[5].Quality;
			Assert.AreEqual (prev-2, actual);
		}

		/// <summary>
		/// Conjureds decrease quality not below zero.
		/// </summary>
		public void ConjuredItemDecreaseQualityNotBelowZero()
		{
			Program.Items [5].Quality = 1;
			int prev = Program.Items[5].Quality;
			Program.UpdateQuality ();
			int actual  = Program.Items[5].Quality;
			Assert.AreEqual (0, actual);
		}
	}
}

