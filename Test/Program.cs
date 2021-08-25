using System;
using CUE4Parse;
using CUE4Parse_Fortnite.Enums;
using CUE4Parse_Fortnite;
using CUE4Parse.FileProvider;
using CUE4Parse.UE4.Objects.Core.Misc;
using CUE4Parse.Encryption.Aes;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Text;
using System.IO;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter game pak directory here: ");
            string dir = Console.ReadLine();
            var provider = new DefaultFileProvider(dir, System.IO.SearchOption.TopDirectoryOnly);
            provider.Initialize();
            FGuid guid = new FGuid();
            FAesKey key = new FAesKey("0xAEEDAAEFB7C3FE1BD8EBCBC60802D494FAE4687B32A1E1D2E58D719372187381");
            provider.SubmitKey(guid, key);
            var test = provider.SaveAsset("FortniteGame/EditorClientAssetRegistry.bin");
            File.WriteAllBytes(Path.Combine(Environment.CurrentDirectory, "EditorClientAssetRegistry.bin"), test);
        }
    }
}
