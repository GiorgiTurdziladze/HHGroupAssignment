using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HHGroupConvertorAPI.Models
{
    public class JobCreateModel
    {
        [Required(ErrorMessage = "Extra Margin field is required")]
        public bool HasExtraMargin { get; set; }

        public IEnumerable<ItemModel> Items { get; set; } = new List<ItemModel>();
    }
}
