using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ScrapySharp.Extensions;
using System.Web;
using Newtonsoft.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;
using System.Threading.Tasks;

namespace Crawl_TGDD
{
    class Program
    {
        public static void Main(string[] args)
        {
            HtmlWeb htmlWeb = new HtmlWeb()
            {
                AutoDetectEncoding = false,
                OverrideEncoding = Encoding.UTF8  //Set UTF8 để hiển thị tiếng Việt
            };
            //Load trang web, nạp html vào document
            HtmlDocument document = htmlWeb.Load("https://www.thegioididong.com/dtdd/");
            //list product
            var products = document.DocumentNode.CssSelect("ul.listproduct li a[data-site='1']");// bat dau boc tach
            List<ClassProduct> Listproduct = new List<ClassProduct>();
            foreach (var product in products)
            {
                var productObject = new ClassProduct();//khoi tao object product

                var name = product.CssSelect("h3").FirstOrDefault().InnerText;//gia tri name
                productObject.name = name;
                var price = product.CssSelect("strong.price").FirstOrDefault().InnerText;// gia tri price
                productObject.price = HttpUtility.HtmlEncode(price);
                var memory = product.CssSelect("ul li");//gia tri memory
                foreach (var item in memory)
                {
                    productObject.memorys.Add(item.InnerText);
                    Console.WriteLine(item.InnerText);
                }
                List<string> imgs = new List<string>();
                var image = product.CssSelect("img");
                foreach (var item in image)
                {
                    Console.WriteLine(item.GetAttributeValue("src"));
                    imgs.Add(item.GetAttributeValue("src"));
                }
                productObject.images=imgs;
                Listproduct.Add(productObject);
            }
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(Listproduct);
            Console.WriteLine(json);
            
        }
        class ClassProduct
        {
            public string name { get; set; }
            public string  price { get; set; }
            public List<string> memorys { get; set; } = new List<string>();
            public List<string> images { get; set; }
        }

    }
}
