﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationBertoni.Models
{
	public class CommonDropDownList
	{
		[Key]
		public int Id { get; set; }
		[Display(Name = "Name")]
		public string Name { get; set; }
	}
}
