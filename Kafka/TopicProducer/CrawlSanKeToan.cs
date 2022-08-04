using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Text;
using ScrapySharp.Extensions;
using System.Linq;
using Newtonsoft.Json;
using System.Web;
using System.IO;
using System.Threading.Tasks;

namespace TopicProducer
{
    class CrawlSanKeToan
    {
        public List<NhanVien> Member()
        {
            HtmlWeb htmlWeb = new HtmlWeb()
            {
                AutoDetectEncoding = false,
                OverrideEncoding = Encoding.UTF8  //Set UTF8 để hiển thị tiếng Việt
            };
            var parallelOptions = new ParallelOptions { MaxDegreeOfParallelism = 1 };
            List<NhanVien> Listnv = new List<NhanVien>();
            Parallel.For(0, 1, parallelOptions, (paging, loopstate) =>
            {
                HtmlDocument document = htmlWeb.Load($"https://sanketoan.vn/danh-sach-ung-vien?page={paging}");
                var nhanviens = document.DocumentNode.CssSelect("div.content_box_employee div.item_employee_new");// bat dau boc tach
                if (nhanviens == null)
                    loopstate.Break();//if nhanviens == null break vòng for i;
                foreach (var nhanvien in nhanviens)
                {
                    var nvObj = new NhanVien();
                    var name = nhanvien.CssSelect("div.col-xl-5 div.item_employee_intro div.item_employee_title h3").FirstOrDefault().InnerText;//gia tri name
                    nvObj.name = name;
                    var exp = nhanvien.CssSelect("div.col-xl-4.col-lg-5 div.uv-info.td-nam-kinh-nghiem .mgb5.cutTitle.clGreen span.employeeExperience.js_year").FirstOrDefault().InnerText;//gia tri exp
                    nvObj.exp = exp;
                    var point = nhanvien.CssSelect("div.col-xl-3.uv_info_item_employee p.mgb5.clGreen span").FirstOrDefault().InnerText;//gia tri point
                    nvObj.point = point;
                    var hoctap = nhanvien.CssSelect("div.col-xl-3.uv_info_item_employee div.uv-info.td-bang-cap p.mgb5.js_literacy_name").FirstOrDefault().InnerText;//gia tri hoc tap
                    nvObj.hoctap = hoctap;
                    var salary = nhanvien.CssSelect("div.col-xl-3.uv_info_item_employee div.uv-info.td-muc-luong p.mgb5.clRed.js_salary").FirstOrDefault().InnerText;//gia tri salary
                    nvObj.salary = salary;
                    var information = nhanvien.CssSelect("a").FirstOrDefault().GetAttributeValue("href");
                    nvObj.information = information;
                    var job = nhanvien.CssSelect("div.col-xl-4.col-lg-5 div.uv-info.td-cty-lv-gan-day p.mgb5.cutTitle.clRed.employeeJobLookFor.js_career_name");//gia tri job
                    foreach (var item in job)
                    {
                        nvObj.Jobs.Add(item.InnerText);
                        Console.WriteLine(item.InnerText);
                    }
                    var field = nhanvien.CssSelect("div.col-xl-4.col-lg-5 div.uv-info.td-cty-lv-gan-day p.mgb5.cutTitle.experienceInField.js_business_name").FirstOrDefault();// gia tri field
                    if (field != null)
                        nvObj.field = HttpUtility.HtmlDecode(field.InnerText);

                    List<string> imgs = new List<string>();
                    var image = nhanvien.CssSelect("img");
                    foreach (var item in image)
                    {
                        Console.WriteLine(item.GetAttributeValue("src"));
                        imgs.Add(item.GetAttributeValue("src"));
                    }
                    nvObj.images = imgs;
                    var address = nhanvien.CssSelect("div.col-xl-5 div.item_employee_intro p.mgb5.clBlack.cutTitle.areaEmployeeWork.js_provice_district");//gia tri address
                    foreach (var item in address)
                    {
                        nvObj.Addresss.Add(item.InnerText);
                        Console.WriteLine(item.InnerText);
                    }
                    var time = nhanvien.CssSelect("div.col-xl-5 div.item_employee_intro p.mgb5.clOrange.dateUpdate.js_date").FirstOrDefault().InnerText;//gia tri time
                    nvObj.time = time;
                    Listnv.Add(nvObj);
                }
            });
            return Listnv;
            //Console.WriteLine(json);
        }
    }
}
