namespace _253504_Antikhovitch_Lab5.Domain
{
    public class Restaurant : IEquatable<Restaurant>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public Restaurant()
        {
            Price = 0;
            Name = "";
            Description = "";
        }
        public Restaurant(string name, string description, decimal price)
        {
            Name = name;
            Description = description;
            Price = price;
        }

        public bool Equals(Restaurant other)
        {
            if (other == null) return false;
            return Name == other.Name && Description == other.Description;
        }
    }
    public class Dish : IEquatable<Dish>
    {
        public int DishID { get; set; }
        public string Name { get; set; }
        public Dish()
        {
            DishID = 0;
            Name = "";
        }
        public Dish(int dishID, string name)
        {
            DishID = dishID;
            Name = name;
        }

        public bool Equals(Dish other)
        {
            if (other == null) return false;
            return DishID == other.DishID && Name == other.Name;
        }
    }
    public class Kitchen : IEquatable<Kitchen> //склад деталей
    {
        public int KitchenID { get; set; }
        public List<Dish> Dishes { get; set; } = new();
        public Kitchen(int kitchenID, List<Dish> dishes)
        {
            KitchenID = kitchenID;
            Dishes = dishes;
        }
        public Kitchen()
        {
            KitchenID = 0;
            Dishes = new();
        }
        public bool Equals(Kitchen other)
        {
            if (other == null) return false;
            return KitchenID == other.KitchenID && Dishes.SequenceEqual(other.Dishes);
        }
    }
    public class CCC
    {
        public List<Restaurant> Restaurants { get; set; } = new List<Restaurant>();
        public List<Kitchen> Kitchens { get; set; } = new List<Kitchen>();
    }
}