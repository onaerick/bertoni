using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplicationBertoni.ViewModels
{
	public class AlbumViewModel
	{
		[DisplayName("Albums")]
		public SelectList AlbumList { get; set; }
		public int? AlbumId { get; set; }
	}
}
