using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DictionaryTree.Models
{
    public class CLib
    {
        [JsonPropertyName("id")]
        public long? Id { get; set; }

        [JsonPropertyName("parent_id")]
        public long? ParentId { get; set; }

        [JsonPropertyName("cnt_leafs")]
        public int? CntLeafs { get; set; } = 0;

        [JsonPropertyName("caption")]
        public string? Caption { get; set; } /*= string.Empty;*/
        [JsonIgnore]
        [JsonPropertyName("abbr")]
        public string? Abbr { get; set; }
        [JsonIgnore]
        [JsonPropertyName("uname")]
        public string? UName { get; set; }
        [JsonIgnore]
        [JsonPropertyName("date_start")]
        public DateTime? DateStart { get; set; }
        [JsonIgnore]
        [JsonPropertyName("date_end")]
        public DateTime? DateEnd { get; set; }
        [JsonIgnore]
        [JsonPropertyName("note")]
        public string? Note { get; set; }
        [JsonIgnore]
        [JsonPropertyName("d_updated")]
        public DateTime? DUpdated { get; set; }
        [JsonIgnore]
        [JsonPropertyName("connection_info_id")]
        public long? ConnectionInfoId { get; set; }
        [JsonIgnore]
        [JsonPropertyName("event_onupdatedata")]
        public string? EventOnuDateData { get; set; }
        /*public override string ToString()
        {
            return $"Node {{ {Id}| {Caption} }}";
        }*/

    }
}
