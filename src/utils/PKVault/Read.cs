using System;
using System.IO;
using PKHeX.Core;
using System.Text.Json;
using System.Collections.Generic;

class PKReader
{
    public static Dictionary<string, object> ReadPkmn(string filePath)
    {
        byte[] data = File.ReadAllBytes(filePath);
        PKM pokemon;

        string ext = Path.GetExtension(filePath).ToLower();

        switch (ext)
        {
            case ".pk3":
                pokemon = new PK3(data);
                break;
            case ".pk4":
                pokemon = new PK4(data);
                break;
            case ".pk5":
                pokemon = new PK5(data);
                break;
            case ".pk6":
                pokemon = new PK6(data);
                break;
            case ".pk7":
                pokemon = new PK7(data);
                break;
            case ".pk8":
                pokemon = new PK8(data);
                break;
            case ".pk9":
                pokemon = new PK9(data);
                break;

            default:
                throw new Exception("Formato de arquivo desconhecido baseado na extensão.");
        }


        var pkmnData = new Dictionary<string, object>
        {
            { "species", pokemon.Species },
            { "heldItem", pokemon.HeldItem },
            { "level", pokemon.CurrentLevel },
            { "nickname", pokemon.Nickname },
            { "nature", pokemon.Nature.ToString() },
            { "gender", pokemon.Gender },
            { "ability", pokemon.Ability },
            { "isShiny", pokemon.IsShiny },
            { "originalTrainer", pokemon.OriginalTrainerName },
            { "tid", pokemon.TrainerTID7 }
        };

        return pkmnData;

    }

    public static void CreateIndex(string pkmnFiles)
    {
        string tempFolder = pkmnFiles;
        var files = Directory.GetFiles(pkmnFiles, "*.pk*");

        var indexList = new List<Dictionary<string, object>>();

        foreach (var file in files)
        {
            var pkmnData = PKReader.ReadPkmn(file);

            pkmnData["filename"] = Path.GetFileName(file);

            indexList.Add(pkmnData);
        }

        // Serializa a lista e escreve no JSON
        var json = JsonSerializer.Serialize(indexList, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(Path.Combine(tempFolder, "index.json"), json);

        Console.WriteLine("index.json criado com sucesso!");
    }
}
