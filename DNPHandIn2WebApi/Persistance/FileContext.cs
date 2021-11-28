using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using DNPHandIn2WebApi.Model;
using Models;

namespace FileData
{
    public class FileContext
    {
       
        public IList<Adult> Adults { get; private set; }

        private readonly string familiesFile = "families.json";
        private readonly string adultsFile = @"D:\CodingProjectsSchool\DNP\DNPHandin2WebApi\DNPHandIn2WebApi\DNPHandIn2WebApi\adults.json";

        public FileContext()
        {
          
            Adults = File.Exists(adultsFile) ? ReadData<Adult>(adultsFile) : new List<Adult>();
        }

        private IList<T> ReadData<T>(string s)
        {
            using (var jsonReader = File.OpenText(s)) // I dont understand why the S was not used in the original code provided
            {
                return JsonSerializer.Deserialize<List<T>>(jsonReader.ReadToEnd());
            }
        }

        public void SaveChanges()
        {
            // storing families
            

            // storing persons
            string jsonAdults = JsonSerializer.Serialize(Adults, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            using (StreamWriter outputFile = new StreamWriter(adultsFile, false))
            {
                outputFile.Write(jsonAdults);
            }
        }
    }
}