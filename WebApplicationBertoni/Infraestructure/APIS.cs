using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationBertoni.Infraestructure
{
	public static class APIS
	{
		public static class Album
		{
			public static string GetAllAlbums(string baseUrl) => $"{baseUrl}/albums";
		}

		public static class Photos
		{
			public static string GetAllPhotos(string baseUrl) => $"{baseUrl}/photos";
		}

		public static class Comments
		{
			public static string GetAllComments(string baseUrl) => $"{baseUrl}/comments";
		}
	}
}
