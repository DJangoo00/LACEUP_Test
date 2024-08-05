using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Product : BaseEntity
{
    //public int Id { get; set; }
    public string ProductName { get; set; }
    public int Price { get; set; }
    public int Quantity { get; set; }
    public string Comment { get; set; }
    public int IdOrderFk { get; set; }
    public Order Order { get; set; }
}
