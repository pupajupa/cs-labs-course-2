using _253504_Antikhovitch_Lab4.Comparers;
using _253504_Antikhovitch_Lab4.Entities;
using _253504_Antikhovitch_Lab4.FileService;

internal class Program
{
    private static void Main(string[] args)
    {
        string directoryName = "Antikhovitch_Lab4";

        if (Directory.Exists(directoryName))
        {
            Directory.Delete(directoryName, true);
        }
        Directory.CreateDirectory(directoryName);
        string[] extensions = new string[] { ".txt", ".rtf", ".dat", ".inf" };
        Random random = new Random();

        for (int i = 0; i < 10; i++)
        {;
            string fileName = Path.Combine(directoryName, $"File{i}{extensions[random.Next(extensions.Length)]}");
            File.Create(fileName).Close();
        }
        string[] files = Directory.GetFiles(directoryName);
        foreach (string file in files)
        {
            string extension = Path.GetExtension(file);
            Console.WriteLine($"File: {Path.GetFileName(file)} with extension {extension}");
        }
        var artObjects = new List<ArtObject>
        {
            new ArtObject { Value = 10, IsSpecial = true, Name = "Painting" },
            new ArtObject { Value = 5, IsSpecial = false, Name = "Sculpture" },
            new ArtObject { Value = 23, IsSpecial = false, Name = "Achitecture" },
            new ArtObject { Value = 8, IsSpecial = true, Name = "Literature" },
            new ArtObject { Value = 11, IsSpecial = true, Name = "Cinematography" },
            new ArtObject { Value = 70, IsSpecial = false, Name = "Music" },
        };

        string dataFileName = Path.Combine(directoryName, "artData.dat");

        FileService fileService = new();
        fileService.SaveData(artObjects, dataFileName);

        string renamedFileName = Path.Combine(directoryName, "artRenamedData.dat");
        File.Move(dataFileName, renamedFileName);
        List<ArtObject> loadedArtObjects = new();
        foreach(var artObject in fileService.ReadFile(renamedFileName))
        {
            loadedArtObjects.Add(artObject);
        }

        var sortedArtObjects = loadedArtObjects.OrderBy(obj => obj, new MyCustomComparer()).ToList();

        Console.WriteLine("Original collection:");
        foreach (var artObject in artObjects)
        {
            Console.WriteLine($"Value: {artObject.Value}, IsSpecial: {artObject.IsSpecial}, Name: {artObject.Name}");
        }

        Console.WriteLine("\nSorted collection by name:");
        foreach (var artObject in sortedArtObjects)
        {
            Console.WriteLine($"Value: {artObject.Value}, IsSpecial: {artObject.IsSpecial}, Name: {artObject.Name}");
        }
        loadedArtObjects = loadedArtObjects.OrderBy(obj => obj.Value).ToList();
        Console.WriteLine("\nSorted collection by value:");
        foreach (var artObject in loadedArtObjects)
        {
            Console.WriteLine($"Value: {artObject.Value}, IsSpecial: {artObject.IsSpecial}, Name: {artObject.Name}");
        }
    }
}