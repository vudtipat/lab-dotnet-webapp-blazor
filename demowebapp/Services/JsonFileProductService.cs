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
	}
}

