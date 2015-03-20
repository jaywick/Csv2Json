using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csv2Json
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Please enter source CSV as first command line parameter");
                Console.ReadKey();
                return;
            }

            var sourcePath = args.Single();

            if (!File.Exists(sourcePath))
            {
                Console.WriteLine("The source CSV does not exist: " + sourcePath);
                Console.ReadKey();
                return;
            }

            var destinationPath = Path.ChangeExtension(sourcePath, "json");

            try
            {
                ConvertCsvToJson(sourcePath, destinationPath);
                Console.WriteLine("Successfully generated JSON file: " + destinationPath);
            }
            catch(Exception ex)
            {
                Console.WriteLine("An error occured!");
                Console.WriteLine(ex.Message);
                Console.ReadKey();
                return;
            }


            // open folder and select output item
            Process.Start("explorer.exe", String.Format("/select,\"{0}\"", destinationPath));
            Console.ReadKey();
        }

        private static void ConvertCsvToJson(string sourcePath, string destinationPath)
        {
            using (var stream = new StreamReader(sourcePath))
            using (var csvReader = new CsvHelper.CsvReader(stream))
            {
                var input = csvReader.GetRecords<dynamic>();
                var output = JsonConvert.SerializeObject(input, Formatting.Indented);
                File.WriteAllText(destinationPath, output);
            }
        }
    }
}
