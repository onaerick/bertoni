using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using WebApplicationBertoni.Models;
using WebApplicationBertoni.Services.Albums;
using WebApplicationBertoni.Services.Comments;
using WebApplicationBertoni.Services.Photos;
using WebApplicationBertoni.ViewModels;

namespace WebApplicationBertoni.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger _logger; 
		private readonly IAlbumService _albumService;
		private readonly IPhotoService _photoService;
		private readonly ICommentService _commentService;

		public HomeController(IAlbumService albumService,
			IPhotoService photoService,
			ICommentService commentService,
			ILogger<HomeController> logger)
		{
			_albumService = albumService;
			_photoService = photoService;
			_commentService = commentService;
			_logger = logger;
		}
		public async Task<IActionResult> Index()
		{

			AlbumViewModel model = new AlbumViewModel();
			model.AlbumList = await AlbumsDdl();

			return View(model);
		}

		/// <summary>
		/// Get Info from Photos
		/// </summary>
		/// <param name="albumId"></param>
		/// <returns></returns>
		public async Task<IActionResult> DataTablePhoto(int albumId)
		{
			var photos = await _photoService.GetAllPhotosAsync();
			var model = photos
				.Where(x => x.AlbumId == albumId)
				.Select(y => new GridViewModel()
				{
					Id = y.Id,
					Title = y.Title,
					UrlImage = y.ThumbnailUrl,
				});
				
			return PartialView("_DataTablePhoto", model);
		}

		/// <summary>
		/// Get Info from Comments
		/// </summary>
		/// <param name="photoId"></param>
		/// <returns></returns>
		public async Task<IActionResult> DataTableComment(int photoId)
		{
			var comments = await _commentService.GetAllCommentsAsync();
			var model = comments
				.Where(x => x.PostId == photoId)
				.Select(y => new DataTableCommentsViewModel()
				{
					Id = y.Id,
					Name = y.Name,
					Body = y.Body,
					Email = y.Email,
				});

			return PartialView("_DataTableComm", model);
		}

		/// <summary>
		/// Populate DropDownList
		/// </summary>
		/// <returns></returns>
		private async Task<SelectList> AlbumsDdl()
		{
			try
			{
				var response = await _albumService.GetAlbumAsync();
				var dropDownList = response.Select(x => new CommonDropDownList()
				{
					Id = x.Id,
					Name = x.Title,
				}).ToList().OrderBy(x => x.Name);

				return new SelectList(dropDownList, "Id", "Name");
			}
			catch (Exception)
			{
				throw;
			}
		}


		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
