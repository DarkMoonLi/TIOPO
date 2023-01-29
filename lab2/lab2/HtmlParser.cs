using AngleSharp;
using AngleSharp.Dom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace lab2
{
    class ParserHtml
    {
        private string[] validValues = new string[] { "../", "./" };
        private string[] invalidValues = new string[] { "tel:", "mailto:", "file:", "ftp:", "skype:" };
        private IConfiguration config;
        private string address;
        private IBrowsingContext context;
        private IDocument document;

        public IDocument GetDocument()
        {
            return document;
        }

        public string GetStringHtml(string url)
        {
            using (WebClient client = new WebClient())
            {
                try
                {
                    return client.DownloadString(url);
                }
                catch
                {
                    return "";
                }
            }
        }

        public async void Initialization(string url, string uri)
        {
            config = Configuration.Default.WithDefaultLoader();
            if (uri != "" && url != uri)
            {
                address = url + uri;
            }
            else
            {
                address = url;
            }
            context = BrowsingContext.New(config);
            document = await context.OpenAsync(m => m.Content(GetStringHtml(address)));
        }
        public List<string> GetInternalLinks(string url, List<string> links, string uri)
        {
            ParserHtml parser = new ParserHtml();
            parser.Initialization(url, uri);
            IDocument angle = parser.GetDocument();
            foreach (IElement element in angle.QuerySelectorAll("a"))
            {
                string link = element.GetAttribute("href");
                if (link != null && link != "" && link != "#" && (link[0] == '/' || validValues.Any(str => link.Contains(str)) || link.IndexOf(url) != -1 || link.IndexOf("/") == -1) && !invalidValues.Any(str => link.Contains(str)))
                {
                    links.Add(link);
                }
            }
            return links;
        }
    }
}
