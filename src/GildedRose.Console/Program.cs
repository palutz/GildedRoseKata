using System.Collections.Generic;
using GildedRose.Console.MyExtensions;
using GildedRose.Console.QualityChecked;

namespace GildedRose.Console
{
	public class Program
    {
		public static IList<Item> Items { get; set; }
	
        static void Main(string[] args)
        {
            System.Console.WriteLine("OMGHAI!");

			Program.Items = new List<Item>()
                                          {
                                              new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                                              new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                                              new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                                              new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                                              new Item
                                                  {
                                                      Name = "Backstage passes to a TAFKAL80ETC concert",
                                                      SellIn = 15,
                                                      Quality = 20
                                                  },
                                              new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
                                          };

			Program.UpdateQuality();

            System.Console.ReadKey();

			string str = Program.Items [0].Name + 12;

			System.Console.WriteLine (str);

			System.Console.ReadLine ();

        }

		public static void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
				QualityCheckedItem qualityItem = Items [i].CreateQualityCheckedItem ();
				Items [i].SellIn -= qualityItem.SellInUpdateAmount ();
				Items[i].Quality -= qualityItem.QualityUpdateAmount ();
//                if (Items[i].Name != "Aged Brie" && Items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
//                {
//                    if (Items[i].Quality > 0)
//                    {
//                        if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
//						{
//							if (Items[i].Name.Contains("Conjured"))
//							{
//								if (Items [i].Quality >= 2)
//									Items [i].Quality = Items [i].Quality - 2;
//								else
//									Items [i].Quality = 0;
//							} else
//                            	Items[i].Quality = Items[i].Quality - 1;
//                        }
//                    }
//                } else {
//                    if (Items[i].Quality < 50)
//                    {
//                        Items[i].Quality = Items[i].Quality + 1;
//
//                        if (Items[i].Name == "Backstage passes to a TAFKAL80ETC concert")
//                        {
//                            if (Items[i].SellIn < 11)
//                            {
//                                if (Items[i].Quality < 50)
//                                    Items[i].Quality = Items[i].Quality + 1;
//                            }
//                            if (Items[i].SellIn < 6)
//                            {
//                                if (Items[i].Quality < 50)
//                                    Items[i].Quality = Items[i].Quality + 1;
//                            }
//                        }
//                    }
//                }
//
//                if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
//                    Items[i].SellIn = Items[i].SellIn - 1;
//
//                if (Items[i].SellIn < 0)
//                {
//                    if (Items[i].Name != "Aged Brie")
//                    {
//                        if (Items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
//                        {
//                            if (Items[i].Quality > 0)
//                            {
//                                if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
//                                {
//                                    Items[i].Quality = Items[i].Quality - 1;
//                                }
//                            }
//                        }
//                        else
//                            Items[i].Quality = Items[i].Quality - Items[i].Quality;
//                    }
//                    else
//                    {
//                        if (Items[i].Quality < 50)
//                            Items[i].Quality = Items[i].Quality + 1;
//                    }
//                }
            }
        }

    }

    public class Item
    {
        public string Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }
    }

}
