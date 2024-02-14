namespace Project_s7.Models
{
    public class BasketItem
    {
        public Horses Horses { get; set; }  

    }

    public class Basket
    {
        public List<BasketItem> Items { get; set; } = new List<BasketItem>();

        public void AddHorse(Horses horses)
        {
            Items.Add(new BasketItem {  Horses = horses });
        }

        public void RemoveHorse(int horseId)
        {
            var itemToRemove = Items.FirstOrDefault(item => item.Horses.Id == horseId);
            if (itemToRemove != null)
            {
                Items.Remove(itemToRemove);
            }
        }
        public float TotalPrice()
        {
            return Items.Sum(item => item.Horses.HorsePrice);
        }
    }
}
