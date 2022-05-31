using System;

namespace DAL
{
    public class Program
    {
        static void Main(string[] args)
        {
            FileReader fileReader = new FileReader(@"Utils\Commands.txt");
            fileReader.PrintLines();

        }
    }
}
