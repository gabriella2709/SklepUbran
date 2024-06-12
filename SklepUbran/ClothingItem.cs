using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SklepUbran
{
      public class ClothingItem
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public string Type { get; set; }  // e.g., T-shirt, Jeans, Jacket
            public string Color { get; set; }
            public string Size { get; set; }  // e.g., S, M, L, XL
            public decimal Price { get; set; }
            public string Status { get; set; }  // e.g., Available, Sold Out
        }
}
