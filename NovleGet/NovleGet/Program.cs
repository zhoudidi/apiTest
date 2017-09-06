using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace NovleGet
{
    class Program
    {
        static void Main(string[] args)
        {
            HtmlWeb htmlWeb = new HtmlWeb();
            HtmlDocument document = htmlWeb.Load("http://www.dishuge.com/book/20602/");
            //HtmlNodeCollection nodeCollection = document.DocumentNode.SelectNodes(@"//div[@id='list']/table/td/span/a[@href]");
            HtmlNodeCollection nodeCollection = document.DocumentNode.SelectNodes(@"//div[@id='list']/div[@class='box']/div[@class='table']/table/tr/td/span/a[@href]");
            foreach (var node in nodeCollection)
            {
                HtmlAttribute attribute = node.Attributes["href"];
                String val = attribute.Value;
                //if(val.Contains("www.axszw.com"))
                //{

                //}
                //else
                //{
                //    val = "http://www.axszw.com" + val;
                //}
                var title = htmlWeb.Load(val).DocumentNode.SelectNodes(@"//div[@class='bookread']/h1")[0].InnerText;  //文章标题
                //var doc = htmlWeb.Load(val).DocumentNode.SelectNodes(@"//dd[@id='contents']");
                var doc = htmlWeb.Load(val).DocumentNode.SelectNodes(@"//div[@id='read']");
                var content = doc[0].InnerHtml.Replace("&nbsp;", "").Replace("<p/>","").Replace("<p>", "\r\n");  //文章内容
                FileStream fs = new FileStream("杜门.txt", FileMode.Append, FileAccess.Write);
                StreamWriter sr = new StreamWriter(fs, Encoding.UTF8);
                sr.WriteLine("\r\n" + title + "\r\n" + content);// 开始写入
                sr.Close();
                fs.Close();
            }
        }
    }
}
