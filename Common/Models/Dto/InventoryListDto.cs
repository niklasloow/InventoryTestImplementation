using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Common.Models.Dto
{
    public class InventoryDto
    {
        [JsonPropertyName("art_id")]
        public string ArtId { get; set; }
        
        [JsonPropertyName("name")]
        public string Name { get; set; }
        
        [JsonPropertyName("stock")]
        public string Stock { get; set; }
    }

    public class InventoryListDto
    {
        [JsonPropertyName("inventory")]
        public List<InventoryDto> Inventory { get; set; }
    }

}
