using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.BL.DTO
{
    public class ProductDTO
    {
        public int ProdId { get; set; }

       
        public string ProdName { get; set; }

      
        public string ShortDesc { get; set; }

        
        public string LongDesc { get; set; }

       
        public string AdditionalDesc { get; set; }

        public string Color { get; set; }

    }
}
