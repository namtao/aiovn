using Fizzler.Systems.HtmlAgilityPack;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilsLib
{
    class CrawlData
    {
        public void GetData()
        {
            //runCmd("ipconfig");
            HtmlWeb web = new HtmlWeb();
            //HtmlDocument: Đây là một class chứ thông tin về một file html (encoding, innerhtml). Ta có thể load dữ liệu vào HTMLDocument từ 1 URL hoặc từ 1 file
            /*HTMLNode: Một HTMLNode tương đương với một tag(li, ul, div, …) trong HTML. Node lớn nhất chứa toàn bộ tất cả sẽ là DocumentNode.Một số property của HTMLNode mà ta hay sử dụng:

                Name: Tên của node(div, ul, li).
                Attributes: Danh sách các attribute của note(Attribute là các thông tin của node như: src, href, id, class …)
                InnerHTML, OuterHTML: Đọc tên là hiểu rồi nhỉ
                SelectNodes(string xPath) : Tìm các node con của node hiện hành, dựa trên xPath đưa vào.
                SelectSingleNode(string xPath): Tìm node con đầu tiên của node hiện hành, dựa trên xPath đưa vào.
                Descendants(string xPath): Trả ra danh sách các HTMLNode con của node hiện tại.*/

            HtmlAgilityPack.HtmlDocument doc = web.Load("https://code.4noobz.net/web-scraping-simple-html-agility-pack-example/");
            foreach (var item in doc.DocumentNode.SelectNodes("//a[@class= 'btn screen-reader-text sr-only sr-only-focusable']"))
            {
                //MessageBox.Show(item.InnerText.ToString());
            }

            var threadItems = doc.DocumentNode.QuerySelectorAll("ul > li").ToList();
        }
    }
}
