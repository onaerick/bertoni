using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationBertoni.Services.Photos
{
	public interface IPhotoService
	{
		Task<List<Models.Photos>> GetAllPhotosAsync();
	}
}
