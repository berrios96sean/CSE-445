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


            List<string> stopWords = new List<string>
                {
                    "a", "an","and", "in", "on", "the", "is", "are", "am", "to", "or", "of", "as"
                };

            // Split input string into words and filter out stop words
            string[] remove = sb.ToString().Split(' ')
                .Where(word => !stopWords.Contains(word.ToLower()))
                .ToArray();

            // Join remaining words back into a string
            string stopsRemoved = string.Join(" ", remove);

            return stopsRemoved;

        }
    }
}
