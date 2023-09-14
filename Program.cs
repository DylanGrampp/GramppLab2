

using System.Runtime.ExceptionServices;
using System.Security.Cryptography.X509Certificates;
/**       
*--------------------------------------------------------------------
* 	   File name: Program.cs
* 	Project name: Lab2
*--------------------------------------------------------------------
* Author’s name and email:	 Dylan Grampp gramppd@etsu.edu			
*          Course-Section: CSCI 2910-800
*           Creation Date:	09/14/23
* -------------------------------------------------------------------
*/
namespace GramppLab2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string projectRootFolder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.ToString();
            string filePath = projectRootFolder + "/videogames.csv";
            string data = File.ReadAllText(filePath);

            List<VideoGames> videoGames = new List<VideoGames>();

            using (StreamReader reader = new StreamReader(filePath))
            {
                string row;
                reader.ReadLine();

                while (!reader.EndOfStream && (row = reader.ReadLine()) != null)
                {
                    string[] strings = row.Split(',');

                    string title = strings[0];
                    string platform = strings[1];
                    int year = int.Parse(strings[2]);
                    string genre = strings[3];
                    string publisher = strings[4];
                    double naSales = double.Parse(strings[5]);
                    double euSales = double.Parse(strings[6]);
                    double jpSales = double.Parse(strings[7]);
                    double otherSales = double.Parse(strings[8]);
                    double globalSales = double.Parse(strings[9]);

                    VideoGames game = new VideoGames(title, platform, year, genre, publisher, naSales, euSales, jpSales, otherSales, globalSales);
                    videoGames.Add(game);
                }

                videoGames.Sort();
                videoGames.ForEach(Console.WriteLine);
            }

            Console.WriteLine("----------------------------------------------------------------------------");
            //DICTIONARY
            Console.WriteLine("You will now be viewing a single game from each platform using a dictionary.");
            Console.WriteLine("\nClick ENTER to continue");
            Console.ReadLine();

            Dictionary<string, string> gamePlatform = new Dictionary<string, string>();
            foreach (var g in videoGames)
            {
                if (!gamePlatform.ContainsKey(g.Platform) && !gamePlatform.ContainsKey(g.Title))
                {
                    gamePlatform.Add(g.Platform, g.Title);
                }
            }
            foreach (KeyValuePair<string, string> item in gamePlatform)
            {
                Console.WriteLine("{1} --> Platform: {0} ", item.Key, item.Value);
            }

            Console.WriteLine("\nClick ENTER to continue on to using a stack.");
            Console.ReadLine();
            Console.WriteLine("----------------------------------------------------------------------------");
            //STACK
            Console.WriteLine("Using a stack, here is the top 10 most sold games (in millions) globally.\n");

            Stack<double> count = new Stack<double>();
            Stack<string> listOfGames = new Stack<string>();

            videoGames.Sort((a, b) => a.Title.CompareTo(b.Title));
            videoGames.Sort((a, b) => a.GlobalSales.CompareTo(b.GlobalSales));

            foreach (var g in videoGames)
            {
                count.Push(g.GlobalSales);
                listOfGames.Push(g.Title);
            }
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"{i + 1}: {count.Pop()} -- {listOfGames.Pop()}");
            }

            Console.WriteLine("----------------------------------------------------------------------------");
            //QUEUE
            Queue<double> saleQueue = new Queue<double>();
            Queue<string> titleQueue = new Queue<string>();

            Console.WriteLine("Which platform sales would you like to see? ");
            Console.Write("Enter platform name: ");
            string userInput = Console.ReadLine();

            Console.WriteLine($"\nThis will be displayed using a queue. The platform you entered was: {userInput}\n");
            Console.WriteLine("Click ENTER to view the games sold by this platform");
            Console.ReadLine();
            Console.WriteLine();


            //videoGames.Sort((a,b) => a.Title.CompareTo(b.Title));

            foreach(var g in videoGames.Where(g => g.Platform == userInput))
            {
                saleQueue.Enqueue(g.GlobalSales);
            }
            foreach(var g in videoGames)
            {
                titleQueue.Enqueue(g.Title);
            }

            /**foreach(var g in saleQueue)
            {
                Console.WriteLine($"The total {userInput} sales of is: {g}");
            }*/

            IEnumerator<double> enumerator1 = saleQueue.GetEnumerator();
            IEnumerator<string> enumerator2 = titleQueue.GetEnumerator();

            while(enumerator1.MoveNext() && enumerator2.MoveNext())
            {
                double item1 = enumerator1.Current;
                string item2 = enumerator2.Current; 

                Console.WriteLine(item2 + " --> "+ "Has sold " + item1 + " Million.");
            }

            enumerator1.Dispose();
            enumerator2.Dispose();
        }
    }
}