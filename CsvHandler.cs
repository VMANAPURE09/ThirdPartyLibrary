using CsvHelper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPLProject
{
    public class CsvHandler
    {
        public static void ImplementCSVHandling()
        {
            string importfilePath = @"E:\BridgeLabz\TPLProject\TPLProject\Book1.csv";
            // string ExportfilePath = @"E:\BridgeLabz\TPLProject\TPLProject\Export.csv";

            string ExportfilePath = @"E:\BridgeLabz\TPLProject\TPLProject\json1.json";

            using (var reader = new StreamReader(importfilePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var record = csv.GetRecords<AddressData>().ToList();
                Console.WriteLine("Read Data successfully from address csv.");
                foreach (AddressData address in record)
                {
                    Console.WriteLine(address.firstName);
                    Console.WriteLine(address.lastName);
                    Console.WriteLine(address.address);
                    Console.WriteLine(address.city);
                    Console.WriteLine(address.state);
                    Console.WriteLine(address.code);
                    Console.WriteLine("-----------------");
                }

                Console.WriteLine("*************Reading from csv file to csv file************");
                using (var writer = new StreamWriter(ExportfilePath))
                using (var csvExport = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csvExport.WriteRecords(record);
                }
                //Console.WriteLine("*********Reading from csv file to jSON file*********");
                //JsonSerializer serializer = new JsonSerializer();
                //using (StreamWriter sw = new StreamWriter(ExportfilePath))
                //using(JsonWriter writer = new JsonTextWriter(sw))
                //{
                //    serializer.Serialize(writer, record);
                //}
            }
        }
    }
}
