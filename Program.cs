using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using CsvHelper;
using System.Globalization;
using System.IO;

namespace TikiCrawler
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create an instance of Chrome driver
            IWebDriver browser = new ChromeDriver();

            //Navigate to website Tiki.vn > Laptop category
            browser.Navigate().GoToUrl("https://clutch.co/vn/developers/blockchain");
            System.Threading.Thread.Sleep(3000);
            //Select all product items by CSS Selector
            List<string> listProductLink = new List<string>();
            var products = browser.FindElements(By.XPath("//h3[@class='company_info']//a"));
            System.Threading.Thread.Sleep(3000);
            foreach (var product in products)
            {
                string outerHtml = product.GetAttribute("outerHTML");
                string productLink = Regex.Match(outerHtml, "href=\"(.*?)\" target").Groups[1].Value;
                productLink = "https://clutch.co" + productLink;
                listProductLink.Add(productLink);
                //if (productLink.Contains("tka.tiki.vn")) { 
                //{
                //continue;
                // }
                
            }
                List<Product> listTikiProduct = new List<Product>();
                //Go to each product link
                for (int i = 0; i < listProductLink.Count; i++)
                {
                //Go to product link
                System.Threading.Thread.Sleep(5000);
                browser.Navigate().GoToUrl(listProductLink[i]);
                    //Extract product information by CSS Selector
                    string productTitle = browser.FindElements(By.XPath("//h1[@class = 'header-company--title']//a"))[0].Text;

                    //Extract product brand by CSS Selector then remove redundant data by Regular Expression
                    //string productBrand = browser.FindElements(By.CssSelector(".vendor"))[0].GetAttribute("outerHTML");
                    //productBrand = Regex.Match(productBrand, "vendor\">(.*?)</a>").Groups[1].Value;

                    //string productJSON = browser.FindElements(By.CssSelector("#__next > script:nth-child(3)"))[0].GetAttribute("innerHTML");
                    //Extract product price
                    //string productPrice = Regex.Match(productJSON, "\"price\":(\\d+)").Groups[1].Value;
                    string productPrice = browser.FindElements(By.CssSelector(".special-price"))[0].Text;
                    //productPrice = Regex.Match(productPrice,">\"(.*?)\"</ span >").Groups[1].Value;
                    //Extract product images
                    string productImg = browser.FindElements(By.XPath("//img[@class = 'header-company--logotype']"))[0].GetAttribute("outerHTML");
                    productImg = Regex.Match(productImg, " src=\"(.*?)\"alt").Groups[1].Value;
                    //Extract colors
                    //var ColorList = browser.FindElements(By.XPath("/html/body/div[1]/div[1]/main/div[4]/div/div[3]/div[2]/div/div[1]/div[2]/div/p/span"));
                    //var Color = browser.FindElements(By.XPath("/html/body/div[1]/div[1]/main/div[4]/div/div[3]/div[2]/div/div[1]/div[2]/div/p/span"));
                    //string extractColor = "";
                    //if (Color.Count != 0) extractColor = Color[0].Text;
                    //Extract sizes
                    //string productSize = browser.FindElements(By.CssSelector(".content.has-table "))[0].GetAttribute("outerHTML");
                    //productSize = Regex.Match(productSize, "Kích thước màn hình</td><td>(.*?)</td>").Groups[1].Value;
                    //Extract product details
                    //string productDetails = browser.FindElements(By.CssSelector(".content.has-table"))[0].Text;
                    //Extract product description
                    //string productDescription = browser.FindElements(By.XPath("//div[@class='product-description-wrapper']//p"))[0].Text;
                    //productDescription = Regex.Match(productDescription, "display: block;\"(.*?)\"</div>").Groups[1].Value;
                    //Extract SKU
                    System.Threading.Thread.Sleep(5000);
                    string productSKU = "1414" +  i;

                    System.Threading.Thread.Sleep(5000);

                    int z = i + 505;
                    listTikiProduct.Add(new Product(z,productTitle, productPrice, productImg, productSKU));
                    System.Threading.Thread.Sleep(5000);


                }
                using (StreamWriter csv = new StreamWriter("C:/Users/Thanh/Desktop/EC312.L21-Thiết kế hệ thống TMĐT/Lab 3 - Web Crawler/1. Web Crawler Demo/TikiCrawler/1.csv", false, System.Text.Encoding.UTF8))
                {
                    csv.WriteLine("ID@Type@SKU@Name@Published@Is featured?@Visibility in catalog@Tax status@In stock?@Stock@Low stock amount@Regular price@Categories@Images");
                    foreach (Product item in listTikiProduct)
                    {
                        csv.WriteLine(item.productID + "@simple@"+item.productSKU +"@"+ item.productTitle + "@1@0@visible@taxable@1@10@2@" + item.productPrice + "@Sen đá cỡ lớn@" + item.productImg );
                    }
                }

                //Console.WriteLine(products.Count);
                //System.IO.StreamWriter writer = new System.IO.StreamWriter("D:\\tiki.csv", false, System.Text.Encoding.UTF8);
                //writer.WriteLine("ProductName\tImageLink");
                ////System.Threading.Thread.Sleep(10000);
                ////string productLink = product.GetAttribute("href");
                ////string productName = product.FindElement(By.CssSelector(".product-item .name")).Text;
                ////string innerHtml = product.GetAttribute("innerHTML");
                //string productName = Regex.Match(outerHtml, "alt=\"(.*?)\"").Groups[1].Value;
                //string productThumbnail = Regex.Match(outerHtml, "<img src=\"(.*?)\"").Groups[1].Value;
                //writer.WriteLine(productName + "\t" + productThumbnail);
                //writer.Close();
                browser.Close();
                //browser.FindElements(By.CssSelector(".title"))[0].Text;
                //browser.FindElements(By.CssSelector(".title"))[0].GetAttribute("");

        }
    }
}


//browser.FindElements(By.XPath(""));
//browser.FindElement(By.CssSelector(""));
//browser.FindElement(By.XPath(""));