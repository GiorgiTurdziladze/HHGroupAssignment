using System.ComponentModel.DataAnnotations;

namespace HHGroupConvertorAPI.Models
{
    public class ItemModel
    {
        [Required(ErrorMessage = "Exempt field is Required")]
        public bool IsExempt { get; set; }

        [Required(ErrorMessage = "Name field is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Cost field is required")]
        public decimal Cost { get; set; }
    }
}
