using System.ComponentModel.DataAnnotations;

namespace HHGroupConvertorAPI.Models.Configuration
{
    public class CalculatorConfigModel
    {
        [Required(ErrorMessage = "Tax field is required")]
        public decimal Tax { get; set; }

        [Required(ErrorMessage = "Margin field is required")]
        public decimal Margin { get; set; }

        [Required(ErrorMessage = "Extra Margin is required")]
        public decimal ExtraMargin { get; set; }


    }
}
