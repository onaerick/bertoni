using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationBertoni.ViewModels
{
	public class DataTableCommentsViewModel
	{
		[DisplayName("Id")]
		public int Id { get; set; }
		[DisplayName("Name")]
		public string Name { get; set; }
		[DisplayName("Email")]
		public string Email { get; set; }
		[DisplayName("Comment")]
		public string Body { get; set; }
	}
}
