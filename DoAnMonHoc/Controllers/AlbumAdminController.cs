using DoAnMonHoc.Data;
using DoAnMonHoc.Models;
using DoAnMonHoc.Services;
using DoAnMonHoc.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Drawing.Printing;

namespace DoAnMonHoc.Controllers
{
    [Authorize(Roles = "admin, manager")]
    public class AlbumAdminController : Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly Helper _helper;

        public AlbumAdminController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment, Helper helper)
        {
            _context = context;
            _hostingEnvironment = webHostEnvironment;
            _helper = helper;
        }

        public IActionResult Index(int page = 1, int pageSize = 5)
        {

            if (!_helper.CheckPermission("AlbumList", User.Identity?.Name??""))
            {
                return Redirect("/Account/Login");
            }

            var albums = _context.Album.OrderByDescending(i => i.AlbumId);
            var totalAlbums = albums.Count();
            var albumsList = albums.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            var viewModel = new Paging<Album>
            {
                Data = albumsList,
                CurrentPage = page,
                TotalPages = (int)Math.Ceiling(totalAlbums / (double)pageSize)
            };

            return View(viewModel);
        }

        [HttpGet("AlbumAdmin/AddEdit/{Id}")]
        public IActionResult AddEdit(int Id)
        {

            if (!_helper.CheckPermission("AlbumAddEdit", User.Identity?.Name??""))
            {
                return Redirect("/Account/Login");
            }

            Album album = new Album();

            if (Id > 0)
            {
                album = _context.Album.FirstOrDefault(i => i.AlbumId == Id);
            }

            return View(album);
        }
        [HttpGet("AlbumAdmin/Delete/{Id}")]
        public IActionResult Delete(int Id)
        {
            if (!_helper.CheckPermission("AlbumDelete", User.Identity?.Name ?? ""))
            {
                return Redirect("/Account/Login");
            }

            Album album = new Album();
            if (Id > 0)
            {
                album = _context.Album.FirstOrDefault(i => i.AlbumId == Id);
                _context.Album.Remove(album);
                _context.SaveChanges();
            }

            return Redirect("/AlbumAdmin");
        }


        [HttpPost("upload-image")]
        public IActionResult UploadImage([FromForm]Upload upload)
        {

            string ProfilePictureFileName = string.Empty;

            if (upload.File != null)
            {
                string uploadsFolder = Path.Combine(_hostingEnvironment.ContentRootPath, "wwwroot/upload");

                ProfilePictureFileName = DateTime.Now.Ticks.ToString() + Path.GetExtension(upload.File.FileName);
                string filePath = Path.Combine(uploadsFolder, ProfilePictureFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    upload.File.CopyTo(fileStream);
                }
            }
            return Ok(new
            {
                path = $"/upload/{ProfilePictureFileName}"
            });


        }

        [HttpPost]
        public IActionResult Save(Album album)
        {
            try
            {
                if (!_helper.CheckPermission("AlbumDelete", User.Identity?.Name ?? ""))
                {
                    return Ok(new
                    {
                        code = 500,
                        message = "Bạn không có quyền"
                    });
                }


                if (album.AlbumId > 0)
                {
                    _context.Album.Update(album);
                }
                else
                {
                    _context.Album.Add(album);
                }
                _context.SaveChanges();

                return Ok(new
                {
                    code = 200
                });
            }catch (Exception e)
            {
                return Ok(new
                {
                    code = 500,
                    message = e.Message
                });
            }
        }

    }
}
