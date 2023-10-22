
using _253504_Antikhovitch_Lab5.Domain;
using SerializerLib;

internal class Program
{
    static void Main(string[] args)
    {
        static bool IsEqual(CCC a, IEnumerable<CCC> b)
        {
            return a.Restaurants.SequenceEqual(b.First().Restaurants)
                && a.Kitchens.SequenceEqual(b.First().Kitchens);
        }

        CCC data = new();

        //create restaurants
        Restaurant rest1 = new("Restaurant 1", "Japanese cuisine", 2500);
        Restaurant rest2 = new("Restaurant 2", "Russian cuisine", 1700);
        data.Restaurants.Add(rest1);
        data.Restaurants.Add(rest2);

        //create partsstorage
        Kitchen kitchen1 = new() { KitchenID = 1 };
        kitchen1.Dishes.Add(new Dish(1, "Sushi"));
        kitchen1.Dishes.Add(new Dish(2, "Rolls"));
        data.Kitchens.Add(kitchen1);

        Kitchen kitchen2 = new Kitchen { KitchenID = 2 };
        kitchen2.Dishes.Add(new Dish(3, "Borscht"));
        kitchen2.Dishes.Add(new Dish(4, "Сholodets"));
        data.Kitchens.Add(kitchen2);

        //serialize the data to three different files
        Serializer serializer = new Serializer();
        serializer.SerializeByLINQ(new List<CCC> { data }, "data_linq.xml");
        serializer.SerializeXML(new List<CCC> { data }, "data_xml.xml");
        serializer.SerializeJSON(new List<CCC> { data }, "data_json.json");

        //deserialize and check if it matches the original data
        IEnumerable<CCC> deserializedDataLINQ = serializer.DeSerializeByLINQ("data_linq.xml");
        IEnumerable<CCC> deserializedDataXML = serializer.DeSerializeXML("data_xml.xml");
        IEnumerable<CCC> deserializedDataJSON = serializer.DeSerializeJSON("data_json.json");

        if (IsEqual(data, deserializedDataLINQ) && IsEqual(data, deserializedDataXML) && IsEqual(data, deserializedDataJSON))
        {
            Console.WriteLine("Deserialization successful. The data matches the original.");
        }
        else
            Console.WriteLine("Deserialization failed. The data doesn't match the original.");
    }
}