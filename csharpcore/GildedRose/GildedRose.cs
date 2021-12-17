using System.Collections.Generic;
using GildedRoseKata;

namespace GildedRose
{
    public class GildedRose
    {
        public readonly IList<Item> Items;

        public GildedRose(IList<Item> items)
        {
            Items = items;
        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                UpdateItem(item);
            }
        }

        private static void UpdateItem(Item item)
        {
            if (item.Name == "Sulfuras, Hand of Ragnaros")
            {
                return;
            }

            item.Quality = UpdateQualityAndSellInBeforeCheckingToReturnEarly(item.Name, item.Quality, item.SellIn);
            item.SellIn--;
            item.Quality = UpdateQualityIfThereIsANeedToChangeIt(item.Name, item.Quality, item.SellIn);
        }

        private static int UpdateQualityAndSellInBeforeCheckingToReturnEarly(string name, int quality, int sellIn)
        {
            switch (name)
            {
                case "Aged Brie":
                {
                    if (quality < 50)
                    {
                        quality++;
                    }

                    break;
                }
                case "Backstage passes to a TAFKAL80ETC concert":
                {
                    if (quality < 50)
                    {
                        quality++;

                        if (sellIn < 11)
                        {
                            quality++;

                            if (sellIn < 6)
                            {
                                quality++;
                            }
                        }
                    }

                    break;
                }
                default:
                {
                    if (quality > 0)
                    {
                        quality--;
                    }

                    break;
                }
            }

            sellIn--;

            return quality;
        }

        private static int UpdateQualityIfThereIsANeedToChangeIt(string name, int quality, int sellIn)
        {
            switch (name)
            {
                case "Aged Brie":
                {
                    if (sellIn >= 0) return quality;

                    if (quality < 50)
                    {
                        quality++;
                    }

                    break;
                }
                case "Backstage passes to a TAFKAL80ETC concert":
                {
                    if (sellIn >= 0) return quality;

                    quality = 0;
                    break;
                }
                default:
                {
                    if (sellIn >= 0) return quality;

                    if (quality > 0)
                    {
                        quality--;
                    }

                    break;
                }
            }

            return quality;
        }
    }
}