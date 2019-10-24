using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationBertoni.ViewModels
{
	public class GridViewModel
	{
		[DisplayName("Id")]
		public int Id { get; set; }
		[DisplayName("Title")]
		public string Title { get; set; }
		[DisplayName("Image")]
		public string UrlImage { get; set; }
	}
}
