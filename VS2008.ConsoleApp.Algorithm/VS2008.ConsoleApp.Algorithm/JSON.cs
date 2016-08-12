using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Newtonsoft.Json;
namespace VS2008.ConsoleApp.Algorithm
{
    public class JSON
    {
        public static void WriteJSONFile(Vertex V)
        {
          
            StreamWriter stream = new StreamWriter(File.Create(@"E:\VIP\智立方\智立方\源代码\WEB前台\VCube.Web\data\jsongraph.txt"));
            StringBuilder jsonBuilder = new StringBuilder();
            StringWriter writer = new StringWriter(jsonBuilder);
            using (JsonWriter jsonWriter = new JsonTextWriter(writer))
            {
                jsonWriter.WriteStartObject();
                jsonWriter.WritePropertyName("Coordinates");
                jsonWriter.WriteRawValue(JsonConvert.SerializeObject(V.Coordinates));
                //jsonWriter.WritePropertyName("HasTraversed");
                //jsonWriter.WriteStartArray();
                //for (int i = 0; i < V.Coordinates.Length; i++)
                //{
                //    jsonWriter.WriteStartArray();
                //    for (int j = 0; j < V.Coordinates.Length; j++)
                //    {
                //        jsonWriter.WriteValue(V.HasTraversed[i, j]);
                //    }
                //    jsonWriter.WriteEndArray();
                //}
                //jsonWriter.WriteEndArray();
                jsonWriter.WritePropertyName("Edge");
                jsonWriter.WriteStartArray();
                for (int i = 0; i < V.Coordinates.Length; i++)
                {
                    jsonWriter.WriteStartArray();
                    for (int j = 0 ; j < V.Coordinates.Length; j++)
                    {
                        jsonWriter.WriteValue(V.Edge[i, j]);
                    }
                    jsonWriter.WriteEndArray();
                }
                jsonWriter.WriteEndArray();
                jsonWriter.WriteEndObject();
            }
            stream.Write(jsonBuilder.ToString());
            stream.Close();
        }
       
    }
}
