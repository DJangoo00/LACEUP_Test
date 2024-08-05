using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontEnd.Models;
public class OrderModel
{
    public int id { get; set; }
    public DateTime createDate { get; set; }
    public int itemCount { get; set; }
    public int totalPrice { get; set; }
    public string customerName { get; set; }
}