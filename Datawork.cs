using Newtonsoft.Json.Linq;

namespace Datawork
{
    class Datawork
    {

        static public JToken Indexate(JToken data, int index=0)
        {
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
            return data;
        }

        static private JToken IndexateObject(JObject data, int index=0)
        {
            data.Add("$id", index);
            foreach (var item in data.Properties())
            {
                item.Value = Indexate(item.Value);
            }
            return data;
        }
        static private JToken IndexateArray(JArray data, int index=0)
        {
            for (int i = 0; i < data.Count(); i++)
            {
                data[i] = Indexate(data[i], i);
            }
            return data;
        }
    }
}