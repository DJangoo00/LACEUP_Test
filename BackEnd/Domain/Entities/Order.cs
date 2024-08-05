using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Order : BaseEntity
{
    //public int Id { get; set; }
    public DateTime CreateDate { get; set; }

    public int ItemCount { get; set; }

    public int TotalPrice { get; set; }

    public string CustomerName { get; set; }

    public ICollection<Product> Products { get; set; }
}
