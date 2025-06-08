using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Domain.Entities
{
    public class FoodVitamin 
    {
        [Key]
        public Guid FoodId { get; set; }
        [Key]
        public Guid VitaminId { get; set; }
        public double Amount { get; set; }
        public string Unit { get; set; }
        public string ReferenceQuantity { get; set; } //Định Lượng trong bao nhiêu ...
        public string ReferenceUnit { get; set; } //Đơn vị tham chiếu của food 
        public Vitamin Vitamin { get; set; }
        public Food Food { get; set; }
    }
}
