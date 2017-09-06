using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;
namespace ImageGet
{
    class Program
    {
        static void Main(string[] args)
        {
            HtmlWeb htmlWeb = new HtmlWeb();
            HtmlDocument document = htmlWeb.Load("https://www.dbmeinv.com/");
            HtmlNodeCollection nodeCollection = document.DocumentNode.SelectNodes(@"//div[@class='img_single']/a[@href]");
               foreach (var node in nodeCollection)
               {
                   HtmlAttribute attribute = node.Attributes["href"];
                   String val = attribute.Value;
                   HtmlNodeCollection doc = htmlWeb.Load(val).DocumentNode.SelectNodes(@"//div[@class='topic-figure cc']/img");
                   var u= doc[0].Attributes["src"].Value;
                   //var title = htmlWeb.Load(val).DocumentNode.SelectNodes(@"//div[@class='bookread']/h1")[0].InnerText;  //文章标题
               }
        }
    }
}
