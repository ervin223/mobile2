using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

public static class FileHelper
{
    private static string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "words.json");

    public static void SaveWords(List<Word> words)
    {
        var json = JsonConvert.SerializeObject(words);
        File.WriteAllText(filePath, json);
    }

    public static List<Word> LoadWords()
    {
        if (File.Exists(filePath))
        {
            var json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<Word>>(json) ?? new List<Word>();
        }
        return new List<Word>();
    }
}
