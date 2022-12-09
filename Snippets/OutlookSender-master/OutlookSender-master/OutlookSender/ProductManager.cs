using System;
using System.Collections.Generic;
using System.Text;

namespace OutlookSender {
    public class ProductManager {
        public List<Product> Products { get; set; } = new List<Product>();

        public ProductManager() {
            Products.Add(new Product() { Name = "Nutella", Amount = 3 });
        }


    }
}
