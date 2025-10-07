using PKHeX.Core;

partial class Program
{
    static void Main(string[] args)
    {
        if (args.Length < 1)
        {
            Console.WriteLine("Usage: PKVault.exe <option> [filePath]");
            return;
        }

        int option = int.Parse(args[0]);
        string filePath = args.Length > 1 ? args[1] : null;

        switch (option)
        {
            case 1: // Convert save
                if (filePath != null)
                    Converter.Convert(filePath);
                break;
            case 2: // Read Pokémon
                if (filePath != null)
                    PKReader.ReadPkmn(filePath);
                break;
            case 3:
                string tempPath = Converter.Convert(filePath);
                PKReader.CreateIndex(tempPath);
                Console.Write("Index created at " + tempPath);
                break;
            default:
                Console.WriteLine("Invalid option.");
                break;
        }
    }
}
