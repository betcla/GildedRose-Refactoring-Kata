namespace csharpcore
{
    public class UpdatingOtherObject
    {
        private GildedRose _gildedRose;

        public UpdatingOtherObject(GildedRose gildedRose)
        {
            _gildedRose = gildedRose;
        }

        public static bool IsSulfuras(Item item)
        {
            return item.Name.Contains("Sulfuras");
        }

        public void UpdateOtherItem(Item item)
        {
            item.Quality = item.Quality + _gildedRose.decreaseInQuality;
            if ((item.SellIn < _gildedRose.sellByDay) && (item.Quality > _gildedRose.minimumQuality))
            {
                item.Quality = item.Quality + _gildedRose.decreaseInQuality;
            }
        }
    }
}