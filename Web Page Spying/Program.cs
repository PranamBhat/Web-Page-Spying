using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Web_Page_Spying
{
    class Program
    {
        static void Main(string[] args)
        {
            var desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var path1 = Path.Combine(desktop, "URL List.txt");
            var path2 = Path.Combine(desktop, "Web Content.txt");
            var path3 = Path.Combine(desktop, "Web Pictures");
            Console.WriteLine("Enter URL : ");
            Console.WriteLine("\n");

            string url = Console.ReadLine();

            using (WebSpy WebSpyer = new WebSpy(url))
            {
                // write urls in txt
                WebSpyer.SaveURLsToDoc(path1);
                Console.WriteLine("\n");
                Console.WriteLine("All URL's writen in text document on your Desktop : URL List");
                Console.WriteLine("\n");

                //clean web content from html tags and write in txt
                WebSpyer.SaveWebContentToDoc(path2);
                Console.WriteLine("Content of web page is cleared from html tags and writen in text document on your Desktop : Web Content");
                Console.WriteLine("\n");

                // write urls in txt
                WebSpyer.SavePicturesToDoc(path3);
                Console.WriteLine("All pictures from web page saved in a folder on your Desktop : Web Pictures");
            }

            Console.ReadKey();
        }
    }
}