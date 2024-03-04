namespace Settings
{
    class Settings
    {
        public static string inputFilePath = "infile.json";
        public static string outputFilePath = "outfile.json";
        public static string indexKey = "$id";

        public static void SetSettings(string[] args)
        {
            string argType = "";
            foreach (var arg in args)
            {
                if (argType == "") argType = arg;
                else {
                    if (argType == "-k") indexKey = arg;
                    if (argType == "-i") inputFilePath = arg;
                    if (argType == "-o") outputFilePath = arg;
                    argType = "";
                }
            }
            if (argType != "") inputFilePath = argType;
        }
    }
}