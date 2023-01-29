using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace lab2
{
    class Program
    {

        static async Task Main(string[] args)
        {
            //const string url = "http://links.qatl.ru/";
            const string url = "https://www.linuxcenter.ru/";
            //const string url = "https://www.yola-mkt.ru/";
            StreamWriter validLinks = new StreamWriter("validLinks.txt");
            StreamWriter invalidLinks = new StreamWriter("invalidLinks.txt");
            ParserHtml parser = new ParserHtml();
            List<string> links = new List<string>();
            List<string> usedLinks = new List<string>();
            links.Add(url);
            links = parser.GetInternalLinks(url, links, ""); ;

            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1)");

            int countValidLinks = 0;
            int countInvalidLinks = 0;
            for (int i = 0; i < links.Count; i++)
            {
                string link = links[i];
                if (link.IndexOf("../") != -1)
                {
                    link = link.Replace("../", "");
                }

                if (link[0] == '/')
                {
                    link = link.Remove(0, 1);
                }

                if (!usedLinks.Contains(link))
                {
                    var result = new HttpResponseMessage();

                    if (link.IndexOf(url) == -1)
                    {
                        result = await httpClient.GetAsync(url + link);
                    }

                    if (link.IndexOf(url) != -1)
                    {
                        result = await httpClient.GetAsync(link);
                    }

                    if ((int)result.StatusCode < 400)
                    {
                        if (link == url)
                        {
                            validLinks.WriteLine(link + ' ' + (int)result.StatusCode);
                        }
                        else
                        {
                            validLinks.WriteLine(url + link + ' ' + (int)result.StatusCode);
                        };

                        countValidLinks++;
                    }
                    else
                    {
                        if (link == url)
                        {
                            invalidLinks.WriteLine(link + ' ' + (int)result.StatusCode);
                        }
                        else
                        {
                            invalidLinks.WriteLine(url + link + ' ' + (int)result.StatusCode);
                        };
                        countInvalidLinks++;
                    }
                    usedLinks.Add(link);
                    links = parser.GetInternalLinks(url, links, link);
                }
            }
            DateTime date = DateTime.Now;
            validLinks.WriteLine(countValidLinks);
            validLinks.WriteLine(date); 
            invalidLinks.WriteLine(countInvalidLinks); 
            invalidLinks.WriteLine(date);
            validLinks.Close();
            invalidLinks.Close();
        }
    }
}
