namespace Settings
{
    class Settings
    {
        public static string inputFilePath = "infile.json";
        public static string outputFilePath = "outfile.json";
        public static string indexKey = "$id";
        public static bool doLogs = false;

        /// <summary>
        /// Fills settings from args
        /// </summary>
        /// <param name="args">args to set</param>
        public static void SetSettings(string[] args)
        {
            /// type of upcomming argument
            string argType = "";

            // iterate
            foreach (var arg in args)
            {
                if (argType == "") argType = arg;
                else
                {
                    // set setting by arg type
                    if (argType == "-k") indexKey = arg;
                    if (argType == "-i") inputFilePath = arg;
                    if (argType == "-o") outputFilePath = arg;
                    if (argType == "-l") doLogs = arg=="true";

                    // empty arg type
                    argType = "";
                }
            }

            // if arg type is not empty -> it's input file!
            if (argType != "") inputFilePath = argType;
        }
    }
}