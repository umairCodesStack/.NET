using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class Product
    {
        public Product()
        {
           
        }

     // [JsonIgnore]
      public  int ID { get; set; }
      public string Name { get; set; }
      public string Description { get; set; }

       public Catagorey catagorey { get; set; }
    }
}
