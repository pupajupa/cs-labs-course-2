using _253504_Antikhovitch_Lab4.Entities;
using _253504_Antikhovitch_Lab4.Interfaces;

namespace _253504_Antikhovitch_Lab4.FileService
{
    public class FileService : IFileService<ArtObject>
    {
        public IEnumerable<ArtObject> ReadFile(string fileName)
        {
            if (!File.Exists(fileName))
                throw new FileNotFoundException("File not found", fileName);
            using BinaryReader reader = new(File.Open(fileName, FileMode.Open));
            while (reader.BaseStream.Position < reader.BaseStream.Length)
            {
                var artObject = new ArtObject
                {
                    // Чтение данных и создание объектов
                    Value = reader.ReadInt32(),
                    IsSpecial = reader.ReadBoolean(),
                    Name = reader.ReadString(),
                };
                yield return artObject;
            }
        }

        public void SaveData(IEnumerable<ArtObject> data, string fileName)
        {
            using BinaryWriter writer = new(File.Open(fileName, FileMode.Create));
            foreach (var item in data)
            {
                // Запись данных в бинарный файл
                writer.Write(item.Value);
                writer.Write(item.IsSpecial);
                writer.Write(item.Name);
            }
        }
    }
}
