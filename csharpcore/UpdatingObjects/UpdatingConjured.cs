using System;

namespace csharpcore
{
    public class UpdatingConjured
    {
        private GildedRose _gildedRose;

        public UpdatingConjured(GildedRose gildedRose)
        {
            _gildedRose = gildedRose;
        }

        public static bool isConjured(Item item)
        {
            return item.Name.Contains("Conjured");
        }

        public void UpdateConjured(Item item)
        {
            if (item.SellIn >= _gildedRose.sellByDay)
            {
                UpdateConjuredForPositiveSellIn(item);
            }
            else
            {
                UpdateConjuredForNegativeSellIn(item);
            }
        }

        private void UpdateConjuredForNegativeSellIn(Item item)
        {
            if (item.Quality <= Math.Abs(_gildedRose.decreaseInQualForConjured_negativeSellIn))
            {
                item.Quality = _gildedRose.minimumQuality;
            }
            else
            {
                item.Quality = item.Quality + _gildedRose.decreaseInQualForConjured_negativeSellIn;
            }
        }

        private void UpdateConjuredForPositiveSellIn(Item item)
        {
            if (item.Quality < Math.Abs(_gildedRose.decreaseInQualForConjured_positiveSellIn))
            {
                item.Quality = _gildedRose.minimumQuality;
            }
            else
            {
                item.Quality = item.Quality + _gildedRose.decreaseInQualForConjured_positiveSellIn;
            }
        }
    }
}