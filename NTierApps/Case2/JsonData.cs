using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DataLayer
{
    public class JsonData
    {
        static string path = Path.Combine("../../../PointsDB.json");
        static public int GetPointsInJson()
        {
            var jsonFileReader = File.OpenText(path);
            var contents = jsonFileReader.ReadToEnd();
            var jsonDataModel = JsonSerializer.Deserialize<DataModel>(contents);
            jsonFileReader.Dispose();
            return jsonDataModel.NumberOfPoints;
        }

        static public int UsePointsInJson(int points)
        {
            DataModel data = new DataModel() { NumberOfPoints = (GetPointsInJson() - points) };
            var jsonFileWriter = File.OpenWrite(path);
            var jsonWriter = new Utf8JsonWriter(jsonFileWriter);
            JsonSerializer.Serialize<DataModel>(jsonWriter, data);
            jsonFileWriter.Dispose();
            return GetPointsInJson();
        }
    }
}
