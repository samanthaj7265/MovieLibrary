/*
Download initial movie data file
Create movie Console Application to see all movies in the file and to add movies to the file.
Implement Exception Handling
Implement NLog framework
Extra: Check for duplicate values
*/

//Create a menu
using System.Formats.Asn1;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Win32.SafeHandles;
using NLog.LayoutRenderers.Wrappers;

internal class Program
{
    private static void Main(string[] args)
    {
        //Create a Menu
        Console.WriteLine("Enter 1 to see list of movies.");
        Console.WriteLine("Enter 2 to add movie to file.");
        Console.WriteLine("Enter anything else to quit.");
        
                string? resp = Console.ReadLine();
        string movieFile = "movies.csv";
        if (resp == "1")
        {
            try
            {
                using (StreamReader sr = new StreamReader("movies.csv"))
                {
                    string? line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] subs = line.Split(',');
                        Console.WriteLine("{0,-8}{1,-75}{2,-50}", subs[0], subs[1], subs[2]);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }
        else if (resp == "2")
        {
            string? title;
            string? genre;
            string? movieID;
            int number;
            while (resp != "N")
            {
                string last = File.ReadLines(@"movies.csv").Last();
                string[] lastLine = last.Split(',');
                number = Convert.ToInt32(lastLine[0]) + 1;
                movieID = number.ToString();
                Console.Write("Title of Movie: ");
                title = Console.ReadLine();
                Console.Write("Genre(s) of Movie: ");
                genre = Console.ReadLine();
                File.AppendAllText(movieFile, $"\n{movieID},{title},{genre}");
                Console.Write("Add another Movie? Y or N?: ");
                resp = Console.ReadLine().ToUpper();       
            }
        }       
    }
}
