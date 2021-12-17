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
            (item.Quality, item.SellIn) = UpdateQualityAndSellIn(item.Name, item.Quality, item.SellIn);
            item.SellIn = UpdateSellInNumberTwo(item.Name, item.Quality, item.SellIn);
        }

        private static (int quality, int sellIn) UpdateQualityAndSellIn(string name, int quality, int sellIn)
        {
            if (name == "Sulfuras, Hand of Ragnaros")
                return (quality, sellIn);

            switch (name)
            {
                case "Aged Brie":
                {
                    if (quality < 50)
                    {
                        quality++;
                    }

                    sellIn--;

                    if (sellIn >= 0) return (quality, sellIn);

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

                    sellIn--;

                    if (sellIn >= 0) return (quality, sellIn);

                    quality = 0;
                    break;
                }
                default:
                {
                    if (quality > 0)
                    {
                        quality--;
                    }

                    sellIn--;

                    if (sellIn >= 0) return (quality, sellIn);

                    if (quality > 0)
                    {
                        quality--;
                    }

                    break;
                }
            }

            return (quality, sellIn);
        }

        private static int UpdateSellInNumberTwo(string name, int quality, int sellIn)
        {
            return sellIn;
        }
    }
}