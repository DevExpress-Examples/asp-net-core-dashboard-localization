using System;
using System.Collections.Generic;

public class ProductSales {
    public int OrderID { get; set; }
    public string Category { get; set; }
    public string Product { get; set; }
    public int Sales { get; set; }
    public DateTime OrderDate { get; set; }

    public static List<ProductSales> GetProductSales() {
        List<ProductSales> data = new List<ProductSales>();

        data.Add(new ProductSales() { OrderID = 1, Category = "Beverages", Product = "Chai", Sales = 10, OrderDate = DateTime.Today });
        data.Add(new ProductSales() { OrderID = 2, Category = "Beverages", Product = "Chai", Sales = 15, OrderDate = DateTime.Today });
        data.Add(new ProductSales() { OrderID = 3, Category = "Beverages", Product = "Coffee", Sales = 35, OrderDate = DateTime.Today.AddMonths(3) });
        data.Add(new ProductSales() { OrderID = 4, Category = "Beverages", Product = "Coffee", Sales = 20, OrderDate = DateTime.Today.AddMonths(3) });
        data.Add(new ProductSales() { OrderID = 5, Category = "Confections", Product = "Chocolate", Sales = 40, OrderDate = DateTime.Today.AddMonths(3) });
        data.Add(new ProductSales() { OrderID = 6, Category = "Confections", Product = "Chocolate", Sales = 55, OrderDate = DateTime.Today.AddMonths(7) });
        data.Add(new ProductSales() { OrderID = 7, Category = "Confections", Product = "Biscuits", Sales = 25, OrderDate = DateTime.Today.AddMonths(7) });
        data.Add(new ProductSales() { OrderID = 8, Category = "Confections", Product = "Biscuits", Sales = 35, OrderDate = DateTime.Today.AddMonths(7) });

        return data;
    }
}