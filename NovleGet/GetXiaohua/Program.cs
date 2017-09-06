using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;
using System.IO;
namespace GetXiaohua
{
    class Program
    {
        static void Main(string[] args)
        {
            HtmlWeb htmlWeb = new HtmlWeb();
            HtmlDocument document = htmlWeb.Load("https://www.qiushibaike.com/");
            HtmlNodeCollection nodeCollection = document.DocumentNode.SelectNodes(@"//div[@class='content']/span");

             foreach (var node in nodeCollection)
             {

                 string values = node.InnerHtml;
                 values = values.Replace("\n", "").Replace("<br>", "\r\n").Replace("查看全文","");
                 FileStream fs = new FileStream("冷笑话.txt", FileMode.Append, FileAccess.Write);
                 StreamWriter sr = new StreamWriter(fs, Encoding.UTF8);
                 sr.WriteLine(values + "\r\n");// 开始写入
                 sr.Close();
                 fs.Close();
             }
        }
    }
}
