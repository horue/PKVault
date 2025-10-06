using System;
using System.IO;
using System.Text.Json;
using PKHeX.Core;

public class Converter
{
    public static void Convert(string saveFilePath)
    {
        #pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
        if (SaveUtil.TryGetSaveFile(saveFilePath, out SaveFile save) && save != null)
        {
            Console.WriteLine("Save was opened.");

            string tempDir = Path.Combine(Path.GetTempPath(), "PKVTemp_" + Guid.NewGuid());
            Directory.CreateDirectory(tempDir);
            Console.WriteLine($"Pasta temporária criada: {tempDir}");

            int count = 0;
            foreach (var pkm in save.BoxData)
            {
                if (pkm.Species == 0)
                    continue;

                var dto = new PKMDto(pkm);

                string fileName = Path.Combine(tempDir, $"{pkm.PID}.json");

                var options = new JsonSerializerOptions { WriteIndented = true };
                string json = JsonSerializer.Serialize(dto, options);

                File.WriteAllText(fileName, json);
                count++;
            }
            Console.WriteLine($"{count} pkmn saved to temp folder.");

            Console.WriteLine("Press any key to end the program. It will also delete the temp folder.");
            Console.ReadKey();

            try
            {
                Directory.Delete(tempDir, true);
                Console.WriteLine("Temp folder deleted.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error at deleting temp folder: {ex.Message}");
            }
        }
        else
        {
            Console.WriteLine("Error at opening save.");
        }
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
    }
}
