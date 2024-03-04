using Filework;
using Datawork;



namespace Program
{
    internal class Program {

        public static void Main(string[] args)
        {
            if (args.Length < 1) throw new Exception("Program expects file");


            var data = Filework.Filework.ReadFile(args[0]);
            data = Datawork.Datawork.Indexate(data);
            Console.WriteLine(data);
            Filework.Filework.WriteFile(args[0], data);
        }
    }
}