using Newtonsoft.Json.Linq;
using Settings;

namespace Datawork
{
    class Datawork
    {

        /// <summary>
        /// Indexate JToken (and it's contents) baised on it's type
        /// </summary>
        /// <param name="data">JToken to indexate</param>
        /// <param name="index">index of this JToken</param>
        /// <returns></returns>
        public static JToken Indexate(JToken data, int index=0)
        {
            // check JTocken type and indexate correspondingly
            switch (data.Type)
            {
                case JTokenType.Array:
                    data = IndexateArray(data as JArray, index);
                    break;
                case JTokenType.Object:
                    data = IndexateObject(data as JObject, index);
                    break;
                default:
                    Console.WriteLine("unknown type: " + data.Type);
                    break;
            }

            // return data after indexation
            return data;
        }

        /// <summary>
        /// Indexate JObject and it's contents
        /// </summary>
        /// <param name="data">JToken to indexate</param>
        /// <param name="index">index of this JToken</param>
        /// <returns></returns>
        private static JToken IndexateObject(JObject data, int index=0)
        {   
            // add index to this JToken
            if (!data.ContainsKey(Settings.Settings.indexKey))
                data.Add(Settings.Settings.indexKey, index);

            // iterate through values and indexate them if needed
            foreach (var item in data.Properties())
                item.Value = Indexate(item.Value);
                
            // return data after indexation
            return data;
        }


        /// <summary>
        /// Indexate JArray and it's contents
        /// </summary>
        /// <param name="data">JToken to indexate</param>
        /// <param name="index">index of this JToken</param>
        /// <returns></returns>
        private static JToken IndexateArray(JArray data, int index=0)
        {
            // indexate contents if needed
            for (int i = 0; i < data.Count(); i++)
                data[i] = Indexate(data[i], i);

            // return data after indexation
            return data;
        }
    }
}