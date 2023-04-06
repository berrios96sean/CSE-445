using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web;
using System.Xml;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.Json;
using System.Text.RegularExpressions;
using HtmlAgilityPack;
using System.Reflection;

namespace A3_part_2_berrios_sean
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public string add(String a,String b)
        {
            int int_a = int.Parse(a);
            int int_b = int.Parse(b);

            int sum = int_a + int_b;

            String strSum = sum.ToString();

            return strSum; 

        }

        /**
         * This service will return a URL for a specific topic. 
         */
        public String getWikiURL(String topic)
        {
            // Make a request to the Wikipedia API to search for the topic
            using (HttpClient client = new HttpClient())
            {
                string url = $"https://en.wikipedia.org/api/rest_v1/page/summary/{topic}";
                HttpResponseMessage response = client.GetAsync(url).Result;
                string json = response.Content.ReadAsStringAsync().Result;

                // Extract the URL of the webpage from the response JSON
                JsonDocument doc = JsonDocument.Parse(json);
                string pageUrl = doc.RootElement.GetProperty("content_urls")
                    .GetProperty("desktop").GetProperty("page").GetString();

                // Print the URL
                Console.WriteLine(pageUrl);

                return pageUrl; 
            }
        }

        public String WordFilter(String topic)
        {
            // Make a request to the Wikipedia API to get the page content in plain text format
            using (HttpClient client = new HttpClient())
            {
                string html = "";
                string url1 = getWikiURL(topic);

                // Grab the html of the page content to parse through each heading 
                using (WebClient client1 = new WebClient())
                {
                    try
                    {
                        // Download the webpage as a string
                        html = client1.DownloadString(url1);

                        // Do something with the HTML string (e.g. print it to console)
                        Console.WriteLine(html);
                    }
                    catch (WebException ex)
                    {
                        // Handle any exceptions that occur
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }

                // Get html content as a string 
                var doc = new HtmlDocument();
                doc.LoadHtml(html);
                var headings = doc.DocumentNode.Descendants()
                    .Where(n => n.Name.StartsWith("h"))
                    .Select(n => n.InnerText.Trim());
                string txt = string.Join(" ", headings);

                // Read the contents of the dictionary text file in this directory 
                string dir = Environment.CurrentDirectory;
                
                Console.WriteLine(dir);

                string path = "C:\\Repos\\CSE-445\\Assignments\\A3_part_2_berrios_sean";
                var dict = new HashSet<string>(File.ReadAllLines(path+"\\dictionary.txt"));

                char[] delimiters = new[] { ' ', ',', '.', ';', ':', '!', '?', '(', ')', '[', ']', '{', '}', '<', '>' };

                // Extract all words in the input string that are present in the dictionary
                var words = txt.Split(delimiters, StringSplitOptions.RemoveEmptyEntries)
                    .Select(w => w.Trim(new[] { '.', ',', ';', ':', '!', '?', '(', ')', '[', ']', '{', '}', '<', '>' }))
                    .Where(w => dict.Contains(w.ToLower()));

                // Concatenate all extracted words into a single string
                string res = string.Join(" ", words);

                List<string> stopWords = new List<string>
                {
                    "a", "an","and", "in", "on", "the", "is", "are", "am", "to", "or", "of", "as"
                };

                // Split input string into words and filter out stop words
                string[] remove = res.Split(' ')
                    .Where(word => !stopWords.Contains(word.ToLower()))
                    .ToArray();

                // Join remaining words back into a string
                string stopsRemoved = string.Join(" ", remove);

                return stopsRemoved;
            }
        }
    }
}
