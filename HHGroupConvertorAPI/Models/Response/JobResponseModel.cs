using System.Collections.Generic;

namespace HHGroupConvertorAPI.Models.Response
{
    public class JobResponseModel
    {
        public List<ItemModel> Items { get; set; } = new List<ItemModel>();
        public decimal Total { get; set; }

    }
}
