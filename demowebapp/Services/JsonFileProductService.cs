using System;
using System.Text.Json;
using demowebapp.Models;

namespace demowebapp.Services
{
	public class JsonFileProductService
	{
		public IWebHostEnvironment _webHostEnvironment { get; }

		public JsonFileProductService(IWebHostEnvironment webHostEnvironment)
		{
			_webHostEnvironment = webHostEnvironment;
        }

		private string JsonFileName
		{
			get { return Path.Combine(_webHostEnvironment.WebRootPath, "data", "products.json"); }
		}

		public IEnumerable<Product> GetProducts()
		{
			using (var jsonFileReader = File.OpenText(JsonFileName))
			{
                return JsonSerializer.Deserialize<Product[]>(jsonFileReader.ReadToEnd(),
					new JsonSerializerOptions
					{
						PropertyNameCaseInsensitive = true
					});
			}
		}

		public void AddRating(string productId,int rating)
		{
			var products = GetProducts();

			var query = products.FirstOrDefault(p => p.Id == productId);

			if(query.Rating == null)
			{
				query.Rating = new int[] { rating };
			}
			else
			{
				var ratings = query.Rating.ToList();
				ratings.Add(rating);
				query.Rating = ratings.ToArray();
			}

			using(var outputstream = File.OpenWrite(JsonFileName))
			{
				JsonSerializer.Serialize<IEnumerable<Product>>(
						new Utf8JsonWriter(outputstream, new JsonWriterOptions
						{
							SkipValidation = true,
							Indented = true
						}),
						products
					);
			}
		}
	}
}

