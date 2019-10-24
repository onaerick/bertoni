using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using WebApplicationBertoni.Infraestructure;

namespace WebApplicationBertoni.Services.Comments
{
	public class CommentService	: ICommentService
	{
		private readonly HttpClient _httpClient;
		private readonly IOptions<Models.Settings> _settings;
		private readonly string _baseUrl;

		public CommentService(HttpClient httpClient, IOptions<Models.Settings> settings)
		{
			_httpClient = httpClient;
			_settings = settings;
			_baseUrl = $"{_settings.Value.BaseUrl}";
		}

		public async Task<List<Models.Comments>> GetAllCommentsAsync()
		{
			try
			{
				var uri = APIS.Comments.GetAllComments(_baseUrl);

				var responseString = await _httpClient.GetStringAsync(uri);

				var response = JsonConvert.DeserializeObject<List<Models.Comments>>(responseString);

				return response;
			}
			catch (Exception ex)
			{

				throw ex;
			}
		}

	}
}
