using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationBertoni.Services.Comments
{
	public interface ICommentService
	{
		Task<List<Models.Comments>> GetAllCommentsAsync();
	}
}
