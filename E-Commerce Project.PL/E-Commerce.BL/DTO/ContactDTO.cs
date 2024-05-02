using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.BL.DTO
{
    public class ContactDTO
    {
        public string Name { get; set; }

        public string Email { get; set; }

       
        public string Subject { get; set; }

     
        public string Message { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
