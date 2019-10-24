using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using WebApplicationBertoni.Infraestructure;
using WebApplicationBertoni.Models;

namespace WebApplicationBertoni.Services.Photos
{
	public class PhotoService : IPhotoService
	{
		private readonly HttpClient _httpClient;
		private readonly IOptions<Models.Settings> _settings;
		private readonly string _baseUrl;

		public PhotoService(HttpClient httpClient, IOptions<Models.Settings> settings)
		{
			_httpClient = httpClient;
			_settings = settings;
			_baseUrl = $"{_settings.Value.BaseUrl}";
		}

		public async Task<List<Models.Photos>> GetAllPhotosAsync()
		{
			try
			{
				var uri = APIS.Photos.GetAllPhotos(_baseUrl);

				var responseString = await _httpClient.GetStringAsync(uri);

				var response = JsonConvert.DeserializeObject<List<Models.Photos>>(responseString);

				return response;
			}
			catch (Exception ex)
			{

				throw ex;
			}
		}

	}
}
