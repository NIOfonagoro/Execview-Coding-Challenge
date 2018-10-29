using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.VisualBasic.FileIO;
using System.Web.UI;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
//NewtonsoftJSON NuGet package had to be installed to deal with json output files

namespace Execview_Coding_Challenge
{
    class Program
    {
        class ChicagoBull
        {
            public int Id { get; set; }
            public string Position { get; set; }
            public int Number { get; set; }
            public string Country { get; set; }
            public string Name { get; set; }
            public string Height { get; set; }
            public string Weight { get; set; }
            public string University { get; set; }
            public decimal PPG { get; set; } 
            
            public static ChicagoBull FromLine(string line)
            {
                var data = line.Split(',');

                return FromFields(data);
            }

            public static ChicagoBull FromFields(string[] data)
            {
                return new ChicagoBull()
                {
                    Id = int.Parse(data[0]),
                    Position = data[1],
                    Number = int.Parse(data[2]),
                    Country = data[3],
                    Name = data[4],
                    Height = data[5],
                    Weight = data[6],
                    University = data[7],
                    PPG = decimal.Parse(data[8]),
                };
            }
        }

        static void Main(string[] args)
        {
            args = new[] { "..//..//chicago-bulls.csv" };

            var chicagoBulls = ReadBulls(args[0]);
            var averagePPG = CalculateAverage(chicagoBulls);

            Console.WriteLine(averagePPG);
            Console.ReadKey();
        }

        static IList<ChicagoBull> ReadBulls(string path, bool hasHeaders = true)
        {
            var reader = new TextFieldParser(path)
            {
                Delimiters = new[] { "," },
                TrimWhiteSpace = true,
            };

            var list = new List<ChicagoBull>();

            if (hasHeaders)
            {
                reader.ReadLine();
            }
            while (!reader.EndOfData)
            {
                list.Add(ChicagoBull.FromFields(reader.ReadFields()));
            }

            var serializer = new JavaScriptSerializer();
            var serializedResult = serializer.Serialize(list);

            File.WriteAllText("Output.json", serializedResult);

            Console.WriteLine(serializedResult);
            return list;
        }

        static decimal CalculateAverage(IEnumerable<ChicagoBull> chicagoBulls)
        {
            var count = 0;
            var total = 0M;

            foreach (var chicagoBull in chicagoBulls)
            {
                count += 1;
                total += chicagoBull.PPG;

            }

            return total / count;
        }
    }
}
