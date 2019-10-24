using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationBertoni.Models;

namespace WebApplicationBertoni.Services.Albums
{
	public interface IAlbumService
	{
		Task<List<Album>> GetAlbumAsync();
	}
}
