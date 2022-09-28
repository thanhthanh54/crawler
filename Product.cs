using System;
using System.Collections.Generic;
using System.Text;

namespace TikiCrawler
{
    class Product
    {
        public int productID { get; set; }
        public string productTitle { get; set; }
        public string productPrice { get; set; }
        public string productImg { get; set; }
        public string productDescription { get; set; }
        public string productSKU { get; set; }
        //public string productBrand { get; set; }
        //public Product(string productImageURL)
        //{
        //this.productImg = productImageURL;
        //}
        public Product(int productID, string productTitle, string productPrice, string productImage, string productSKU)
        {
            this.productID = productID;
            this.productTitle = productTitle;
            this.productPrice = productPrice;
            this.productImg = productImage;
            //this.productDescription = productDescription;
            this.productSKU = productSKU;
            //this.productBrand = productBrand;
        }
    }
}
