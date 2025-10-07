using System;
using System.IO;
using PKHeX.Core;

public class Converter
{
    public static string Convert(string saveFilePath)
    {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
        if (SaveUtil.TryGetSaveFile(saveFilePath, out SaveFile save) && save != null)
        {
            Console.WriteLine("Save was opened.");

            string tempDir = Path.Combine(Path.GetTempPath(), "PKVTemp_" + Guid.NewGuid());
            Directory.CreateDirectory(tempDir);
            Console.WriteLine($"Temp folder created at: {tempDir}");

            // Obtém a geração do save para definir extensão
            int gen = save.Generation;
            Console.WriteLine(save.Generation);

            int count = 0;
            foreach (var pkm in save.BoxData)
            {
                if (pkm.Species == 0)
                    continue;

                string extension = GetExtensionForGeneration(gen);
                string fileName = Path.Combine(tempDir, $"{pkm.PID}.{extension}");

                byte[] pkmBytes = pkm.Data.ToArray();  // converte Span<byte> para byte[]
                File.WriteAllBytes(fileName, pkmBytes);

                count++;
            }
            Console.WriteLine($"{count} pkmn saved to temp folder.");
            Console.WriteLine("Press any key to end the program. It will also delete the temp folder.");
            return tempDir;

            
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
            string info = "Error at opening save.";
            Console.WriteLine(info);
            return info;
        }
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
    }

    private static string GetExtensionForGeneration(int gen)
    {
        return gen switch
        {
            1 => "pk1",
            2 => "pk2",
            3 => "pk3",
            4 => "pk4",
            5 => "pk5",
            6 => "pk6",
            7 => "pk7",
            8 => "pk8",
            9 => "pk9",
            _ => "pkm"
        };
    }
}
