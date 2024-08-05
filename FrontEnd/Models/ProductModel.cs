using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontEnd.Models;
public class ProductModel
{
    public int id { get; set; }
    public string productName { get; set; }
    public int price { get; set; }
    public int quantity { get; set; }
    public string comment { get; set; }
    public int idOrderFk { get; set; }
}