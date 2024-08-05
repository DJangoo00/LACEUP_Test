using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace API.Dtos
{
    public class OrderDto : BaseEntity
    {
        public DateTime CreateDate { get; set; }
        public int ItemCount { get; set; }
        public int TotalPrice { get; set; }
        public string CustomerName { get; set; }
    }
}