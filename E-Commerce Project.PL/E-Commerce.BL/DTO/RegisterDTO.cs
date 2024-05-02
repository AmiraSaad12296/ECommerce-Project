using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.BL.DTO
{
    public class RegisterDTO
    {
        
        public string FullName { get; set; }

        
        public string UserName { get; set; }

       
        public string Mobile { get; set; }

        public string Email { get; set; }

      
        public string Address { get; set; }

        public string Password { get; set; }

        public DateTime CreatedDate { get; set; }

    }
}
