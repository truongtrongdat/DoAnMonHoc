using DoAnMonHoc.Data;
using DoAnMonHoc.Models;
using DoAnMonHoc.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DoAnMonHoc.Controllers
{
	public class CustomerVisitController : Controller
	{
        private readonly ApplicationDbContext _context;
		private readonly UserManager<AppUser> _userManager;

        public CustomerVisitController(ApplicationDbContext context, UserManager<AppUser> userManager) {
            this._context = context;
			this._userManager = userManager;
        }

        [Authorize(Roles = "admin, manager")]
        public async Task<IActionResult> Index()
		{
			var listMessage = await _context.messageCustomerVisit.ToListAsync();
			return View(listMessage);
		}
		public async Task<IActionResult> ThongTinLienHe(MessageCustomerVisit model) 
		{
            try
			{
				var message = new MessageCustomerVisit
				{
					HoTen = model.HoTen,
					Email = model.Email,
					SoDienThoai = model.SoDienThoai,
					TinNhan = model.TinNhan
				};
				await _context.messageCustomerVisit.AddAsync(message);
				await _context.SaveChangesAsync();
			}
			catch(Exception ex)
			{
				return View(ex.Message);
			}
			return RedirectToAction("Index", "Home");
		}
		public async Task<IActionResult> DatLichChupAnh()
		{
            var photoPackage = await _context.photopackage.ToListAsync();
            if (photoPackage != null)
            {
                ViewBag.PhotoPA = new SelectList(photoPackage, "Magoichup", "Tengoichup");
            }
            return View();
		}
        public async Task<IActionResult> BookingNow(Booking model)
        {
			var goichup = await _context.photopackage.SingleOrDefaultAsync(p => p.Magoichup == model.Magoichup);
			if (goichup != null)
			{
				model.Thoigianlienheit = DateTime.Now;
                model.photopackage = goichup;
                model.Tengoichup = model.photopackage.Tengoichup;
                await _context.booking.AddAsync(model);
                await _context.SaveChangesAsync();
				return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Index", "Home");
        }
        
    }
}
