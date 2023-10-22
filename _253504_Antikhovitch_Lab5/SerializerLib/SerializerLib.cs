using _253504_Antikhovitch_Lab5.Domain;
using Newtonsoft.Json;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace SerializerLib
{
    public class Serializer : ISerializer
    {
        public void SerializeByLINQ(IEnumerable<CCC> xxx, string fileName)
        {
            XElement rootElement = new XElement("Data");
            foreach (var item in xxx)
            {
                //создаем элементы для каждого объекта ССС
                XElement cccElement = new XElement("CCC");
                //добавляем данные объекта ССС в элемент
                foreach (var rest in item.Restaurants)
                {
                    XElement restElement = new XElement("Restaurant",
                        new XElement("Name", rest.Name),
                        new XElement("Description", rest.Description),
                        new XElement("Price", rest.Price)
                    );
                    cccElement.Add(restElement);
                }
                foreach (var kitchen in item.Kitchens)
                {
                    XElement kitchenElement = new XElement("Kitchen",
                        new XElement("KitchenID", kitchen.KitchenID)
                        );
                    foreach (var dish in kitchen.Dishes)
                    {
                        XElement dishElement = new XElement("Dish",
                            new XElement("DishID", dish.DishID),
                            new XElement("Name", dish.Name)
                        );
                        kitchenElement.Add(dishElement);
                    }
                    cccElement.Add(kitchenElement);
                }
                rootElement.Add(cccElement);
            }
            //создаем документ и сохраняем его в файл
            XDocument document = new XDocument(rootElement);
            document.Save(fileName);

        }
        public void SerializeXML(IEnumerable<CCC> xxx, string fileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<CCC>));
            using StreamWriter writer = new StreamWriter(fileName);
            serializer.Serialize(writer, xxx.ToList());
        }
        public void SerializeJSON(IEnumerable<CCC> xxx, string fileName)
        {
            string json = JsonConvert.SerializeObject(xxx.ToList());
            File.WriteAllText(fileName, json);
        }

        public IEnumerable<CCC> DeSerializeByLINQ(string fileName)
        {
            List<CCC> result = new List<CCC>();
            //загрузка xml дока из файла
            XDocument document = XDocument.Load(fileName);
            //используем linq-to-xml для извлечения данных
            var cccElements = document.Descendants("CCC");
            foreach (var cccElem in cccElements)
            {
                var restaurantElements = cccElem.Descendants("Restaurant");
                var kitchenElements = cccElem.Descendants("Kitchen");

                CCC ccc = new();

                foreach (var restElem in restaurantElements)
                {
                    string restName = restElem.Element("Name").Value;
                    string restDescription = restElem.Element("Description").Value;
                    decimal restPrice = decimal.Parse(restElem.Element("Price").Value);
                    Restaurant restaurant = new(restName, restDescription, restPrice);
                    ccc.Restaurants.Add(restaurant);
                }
                foreach (var kitchenElem in kitchenElements)
                {
                    int kitchenID = int.Parse(kitchenElem.Element("KitchenID").Value);
                    Kitchen kitchen = new Kitchen { KitchenID = kitchenID };
                    var dishElements = kitchenElem.Descendants("Dish");
                    foreach (var dishElem in dishElements)
                    {
                        int dishID = int.Parse(dishElem.Element("DishID").Value);
                        string name = dishElem.Element("Name").Value;
                        Dish dish = new(dishID, name);
                        kitchen.Dishes.Add(dish);
                    }
                    ccc.Kitchens.Add(kitchen);
                }
                result.Add(ccc);
            }
            return result;
        }
        public IEnumerable<CCC> DeSerializeXML(string fileName)
        {
            XmlSerializer serializer = new(typeof(List<CCC>));
            using (StreamReader reader = new(fileName))
            {
                return serializer.Deserialize(reader) as List<CCC>;
            }
        }
        public IEnumerable<CCC> DeSerializeJSON(string fileName)
        {
            using StreamReader reader = new(fileName);
            string json = reader.ReadToEnd();
            var result = JsonConvert.DeserializeObject<List<CCC>>(json);
            return result;
        }
    }
}
