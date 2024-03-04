using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Settings;


namespace Filework
{
    class Filework {

        /// <summary>
        /// Reads json file and converts it's contents into JToken
        /// </summary>
        /// <returns>Serialized JToken from </returns>
        public static JToken ReadFile() {
            string json;
            using (StreamReader file = new StreamReader(Settings.Settings.inputFilePath)) { json = file.ReadToEnd(); }
            JToken data = JObject.Parse(json);
            return data;
        }


        public static void WriteFile(JToken data) {
            using (StreamWriter file = new StreamWriter(Settings.Settings.outputFilePath)) { new JsonSerializer().Serialize(file, data); }
        }
    }
}