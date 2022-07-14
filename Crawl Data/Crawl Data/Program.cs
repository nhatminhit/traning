using System;
using System.Threading.Tasks;
using HtmlAgilityPack;
namespace Crawl_Data
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * lay du lieu tu trang web 
             * get static data */

            //var html = new HtmlWeb();
            //var document = html.Load("https://vnexpress.net/ong-phan-van-mai-tp-hcm-khong-co-nhan-luc-nhan-roi-4486320.html");
            //var node = document.DocumentNode.SelectSingleNode("html/body/section[4]/div/div[2]/article/p[1]/em/a");

            /* lay du lieu tu chuoi html
             * get data form html string */

            /* get data from file HTML */
            var document = new HtmlDocument();
            document.Load(@"D:\Learn\CTY\Buoi3\Crawl Data\Crawl Data\html.txt");
            var node = document.DocumentNode.SelectSingleNode("html/body/h1");

            /* Inner Text chỉ get thong tin noi dung bang Text
             * Inner Html chỉ get thong tin ve html va cac the tag*/

            /* lay gia tri cua thuoc tinh href trong node
             * get value of href attribute from node*/
            //Console.WriteLine(node.Attributes["href"].Value);
            Console.WriteLine(node.InnerText);
            Console.ReadLine();
        }
    }
}
