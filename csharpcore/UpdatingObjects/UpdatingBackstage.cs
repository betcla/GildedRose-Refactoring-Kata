namespace csharpcore
{
    public class UpdatingBackstage
    {
        private GildedRose _gildedRose;

        public UpdatingBackstage(GildedRose gildedRose)
        {
            _gildedRose = gildedRose;
        }

        public static bool IsBackstage(Item item)
        {
            return item.Name.Contains("Backstage");
        }

        public void UpdateBackstage(Item item)
        {
            if ((item.Quality < _gildedRose.maximumQuality) && (item.SellIn >= _gildedRose.sellByDay))
            {
                UpdateBackstageForPositiveSellIn(item);
            }
            else if (item.SellIn < _gildedRose.sellByDay)
            {
                item.Quality = _gildedRose.minimumQuality;
            }
        }

        private void UpdateBackstageForPositiveSellIn(Item item)
        {
            item.Quality = item.Quality + 1;
            if ((item.Quality < _gildedRose.maximumQuality) && (item.SellIn < 10))
            {
                item.Quality = item.Quality + 1;
                if ((item.Quality < _gildedRose.maximumQuality) && (item.SellIn < 5))
                {
                    item.Quality = item.Quality + 1;
                }
            }
        }
    }
}