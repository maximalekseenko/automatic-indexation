﻿using Filework;
using Datawork;
using Settings;



namespace Program
{
    internal class Program {

        public static void Main(string[] args)
        {
            Settings.Settings.SetSettings(args);


            var data = Filework.Filework.ReadFile();
            data = Datawork.Datawork.Indexate(data);
            if (Settings.Settings.doLogs)
                Console.WriteLine("Final data is:\n" + data);
            Filework.Filework.WriteFile(data);
        }
    }
}