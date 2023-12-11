using _253504_Antikhovitch_Lab6;
using Newtonsoft.Json;

namespace Library
{
    public class FileService<T> : IFileService<T> where T : class
    {
        public IEnumerable<T> ReadFile(string fileName)
        {
            if (File.Exists(fileName))
            {
                string json = File.ReadAllText(fileName);
                return JsonConvert.DeserializeObject<IEnumerable<T>>(json);
            }
            else
            {
                return new List<T>();
            }
        }

        public void SaveData(IEnumerable<T> data, string fileName)
        {
            string json = JsonConvert.SerializeObject(data);
            File.WriteAllText(fileName, json);
        }
    }
}