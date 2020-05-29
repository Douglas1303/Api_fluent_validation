using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Fluent_Validation.Models
{
    public class EntityToValidate
    {
        public string FullName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool HasDiscount { get; set; }
        public decimal Discount { get; set; }
    }
}
