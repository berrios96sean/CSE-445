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
using System.Collections;

namespace A3_berrios_sean_part_3
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public string add(String a, String b)
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
                var dict = new HashSet<string>(File.ReadAllLines(path + "\\dictionary.txt"));

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

        public String GetDates(String topic)
        {

            ArrayList list = new ArrayList(); 
            // New Implementation
            string url = $"https://en.wikipedia.org/api/rest_v1/page/html/{topic}";

            var client = new HttpClient();
            var response = client.GetAsync(url).Result;
            response.EnsureSuccessStatusCode();

            string htmlContent = response.Content.ReadAsStringAsync().Result;

            HtmlDocument document = new HtmlDocument();
            document.LoadHtml(htmlContent);

            // Get all section elements
            var sectionElements = document.DocumentNode.Descendants("section");

            // Loop through each section element and build its <p> elements into a string
            StringBuilder sb = new StringBuilder();
            foreach (var section in sectionElements)
            {
                // Check if the section has a header with the text "References"
                var sectionHeader = section.Descendants("h").FirstOrDefault();
                if (sectionHeader != null && sectionHeader.InnerText == "References")
                {
                    // Skip this section
                    continue;
                }

                string sectionId = section.Attributes["id"].Value;
                var paragraphElements = section.Descendants("p");
                foreach (var paragraph in paragraphElements)
                {
                    sb.AppendLine(paragraph.InnerText);
                }
                sb.AppendLine();
            }

            string texty = sb.ToString();
            List<DateData> tempData = new List<DateData>();
            string[] sentencey = Regex.Split(texty, @"(?<=[^\d\)])\.\s+");

            foreach (string sentence in sentencey)
            {
               // tempArr.Add(sentence);   
            }

            foreach (string sentence in sentencey)
            {
                // Define a regular expression pattern to match any four-digit number between 0001 and 9999
                string pattern = @"(?<!\d)(1\d{3}|[2-9]\d{3})(?!\d)";

                // Check if the sentence contains a date pattern
                if (Regex.IsMatch(sentence, pattern))
                {
                    // Extract the date from the sentence using a regular expression match
                    Match match = Regex.Match(sentence, pattern);
                    int date = int.Parse(match.Value);

                    DateData newDate = new DateData { Date = date, info = sentence };

                    tempData.Add(newDate);
                }
            }

            list.Add(tempData);

            // Create a root object with the dictionary as a property
            var rootObject = new { ListOfDates = list };

            // Convert the root object to JSON using custom options
            JsonSerializerOptions options0 = new JsonSerializerOptions
            {
                IncludeFields = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
            string json = JsonSerializer.Serialize(rootObject, options0);


            return json;


          //  return htmlContent; 

        }

        public String GetTopics(String topic)
        {
            ArrayList list = new ArrayList();
            // New Implementation
            string url = $"https://en.wikipedia.org/api/rest_v1/page/html/{topic}";

            var client = new HttpClient();
            var response = client.GetAsync(url).Result;
            response.EnsureSuccessStatusCode();

            string htmlContent = response.Content.ReadAsStringAsync().Result;

            HtmlDocument document = new HtmlDocument();
            document.LoadHtml(htmlContent);

            // Get all section elements
            // Extract the title of the HTML document
            List<String> tps = new List<string>();
            tps.Add("");
            string title = document.DocumentNode.SelectSingleNode("//title").InnerText;
            tps.Add(title);
            // Extract the names of each header in the HTML document
            List<string> headers = new List<string>();
            foreach (var header in document.DocumentNode.Descendants("h2"))
            {
                tps.Add(header.InnerText);
                headers.Add(header.InnerText);
            }


            // Combine the title and header names into a single string
            string result = $"{title}\n{string.Join("\n", headers)}";

            var sectionElements = document.DocumentNode.Descendants("section");

            List<String> descr = new List<string>(); 
            // Loop through each section element and build its <p> elements into a string
            StringBuilder sb = new StringBuilder();
            foreach (var section in sectionElements)
            {
                sb.AppendLine("Section");
                // Check if the section has a header with the text "References"
                var sectionHeader = section.Descendants("h").FirstOrDefault();
                if (sectionHeader != null && sectionHeader.InnerText == "References")
                {
                    // Skip this section
                    continue;
                }

                string sectionId = section.Attributes["id"].Value;
                var paragraphElements = section.Descendants("p");
                foreach (var paragraph in paragraphElements)
                {
                 
                    sb.AppendLine(paragraph.InnerText);
                    
                }
                sb.AppendLine();
            }

            var inputString = sb.ToString();
            string[] sections = inputString.Split(new string[] { "Section" }, StringSplitOptions.None);

            for (int i = 1; i < sections.Length; i++)
            {
                var section = sections[i];
                var sentences = section.Split(new char['.']);
                foreach (var sentence in sentences)
                {
                    descr.Add(sentence.Trim());
                }
            }

            int count = sectionElements.Count();


            List<TopicData> td = new List<TopicData>();

            for (int i = 1; i <= count; i++)
            {
                TopicData temp = new TopicData {topic = tps[i], description = sections[i] };

                td.Add(temp);
            }

            list.Add(td);

            // Create a root object with the dictionary as a property
            var rootObject = new { ListOfTopics = list };

            // Convert the root object to JSON using custom options
            JsonSerializerOptions options0 = new JsonSerializerOptions
            {
                IncludeFields = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
            string json = JsonSerializer.Serialize(rootObject, options0);

            return json;
        }

        class DateData
        {
            public int Date;
            public String info;
        }

        class TopicData
        {
            public string topic;
            public string description; 
        }
    }
}
