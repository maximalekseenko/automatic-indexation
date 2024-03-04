using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace Filework
{
    class Filework {

        /// <summary>
        /// Reads json file
        /// </summary>
        /// <param name="filepath">path to file</param>
        /// <returns>serialized json object or array</returns>
        public static JToken ReadFile(string filepath) {
            string json;
            using (StreamReader file = new StreamReader(filepath)) { json = file.ReadToEnd(); }
            JToken data = JObject.Parse(json);
            return data;
        }


        public static void WriteFile(string filepath, JToken data) {
            using (StreamWriter file = new StreamWriter(filepath)) { new JsonSerializer().Serialize(file, data); }
        }
    }
}