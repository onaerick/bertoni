using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using WebApplicationBertoni.Infraestructure;
using WebApplicationBertoni.Models;

namespace WebApplicationBertoni.Services.Albums
{
	public class AlbumService : IAlbumService
	{
		private readonly HttpClient _httpClient;
		private readonly IOptions<Models.Settings> _settings;
		private readonly string _baseUrl;

		public AlbumService(HttpClient httpClient, IOptions<Models.Settings> settings)
		{
			_httpClient = httpClient;
			_settings = settings;
			_baseUrl = $"{_settings.Value.BaseUrl}";
		}

		public async Task<List<Album>> GetAlbumAsync()
		{
			try
			{
				var uri = APIS.Album.GetAllAlbums(_baseUrl);

				var responseString = await _httpClient.GetStringAsync(uri);

				var response = JsonConvert.DeserializeObject<List<Album>>(responseString);

				return response;
			}
			catch (Exception ex)
			{

				throw ex;
			}
		}
	}
}
