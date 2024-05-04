using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace demowebapp.Models
{
	public class Product
	{
		public string Id { get; set; } = null!;
		public string Maker { get; set; } = null!;
        [JsonPropertyName("img")]
        public string Image { get; set; } = null!;
        public string Url { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int[]? Rating { get; set; }

        public override string ToString() => JsonSerializer.Serialize<Product>(this);    
    }
}

