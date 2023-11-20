using System.Collections;
using System.Collections.Generic;

namespace GildedRose.Console
{
    class Program
    {
        IList<Item> Items;
        static void Main(string[] args)
        {
            System.Console.WriteLine("OMGHAI!");

            var app = new Program()
            {
                Items = new List<Item>
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
                                          }

            };

            app.UpdateQuality();

            System.Console.ReadKey();

        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                ItemQualityType itemQualityType = SetItemQualityType(item);

                switch (itemQualityType)
                {
                    case ItemQualityType.AgedBrie:
                        UpdateAggedBrieQuality(item);
                        break;

                    case ItemQualityType.BackstagePass:
                        UpdateBackstagePassQuality(item);
                        break;

                    case ItemQualityType.Conjured:
                        UpdateConjuredItemQuality(item);
                        break;

                    case ItemQualityType.LegendaryItem:
                        break;

                    default:
                        DefaultUpdateQuality(item);
                        break;
                }
            }
        }

        public Item DefaultUpdateQuality(Item item)
        {
            if (item.SellIn > 0)
            {
                item.Quality = item.Quality - 1;
            }
            else
            {
                item.Quality = item.Quality - 2;
            }

            CheckForQualityMinAndMax(item.Quality);

            return item;
        }

        public Item UpdateAggedBrieQuality(Item item)
        {
            item.Quality = item.Quality + 1;

            CheckForQualityMinAndMax(item.Quality);

            return item;
        }

        public Item UpdateBackstagePassQuality(Item item)
        {
            if (item.SellIn > 10)
            {
                item.Quality = item.Quality + 1;
            }

            if (item.SellIn <= 10 && item.SellIn > 5)
            {
                item.Quality = item.Quality + 2;
            }

            if (item.SellIn < 5 && item.SellIn >= 0)
            {
                item.Quality = item.Quality + 3;
            }

            if (item.SellIn < 0)
            {
                item.Quality = 0;
            }

            CheckForQualityMinAndMax(item.Quality);

            return item;
        }

        public Item UpdateConjuredItemQuality(Item item)
        {
            if (item.SellIn > 0)
            {
                item.Quality = item.Quality - 2;
            }
            else
            {
                item.Quality = item.Quality - 4;
            }

            CheckForQualityMinAndMax(item.Quality);

            return item;
        }

        public ItemQualityType SetItemQualityType(Item item)
        {
            ItemQualityType itemQualityType = ItemQualityType.Default;

            if (item.Name.Contains("Aged Brie"))
            {
                itemQualityType = ItemQualityType.AgedBrie;
            }
            if (item.Name.Contains("Backstage pass"))
            {
                itemQualityType = ItemQualityType.BackstagePass;
            }
            if (item.Name.Contains("Conjured"))
            {
                itemQualityType = ItemQualityType.Conjured;
            }
            if (item.Name.Contains("Sulfuras"))
            {
                itemQualityType = ItemQualityType.LegendaryItem;
            }

            return itemQualityType;
        }

        public int CheckForQualityMinAndMax(int quality)
        {
            int MinimumQuality = 0;
            int MaximumQuality = 50;

            if (quality < MinimumQuality)
            {
                quality = MinimumQuality;
            }

            if (quality > MaximumQuality)
            {
                quality = MaximumQuality;
            }

            return quality;
        }
    }

    public enum ItemQualityType
    {
        Default = 0,
        AgedBrie = 1,
        BackstagePass = 2,
        Conjured = 3,
        LegendaryItem = 99,
    }

    public class Item
    {
        public string Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }
    }
}
