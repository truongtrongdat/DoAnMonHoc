using DoAnMonHoc.Data;
using DoAnMonHoc.Models;
using DoAnMonHoc.Services;
using DoAnMonHoc.ViewModel;
using DoAnMonHoc.ViewModel.registerVM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DoAnMonHoc.Controllers
{
    [Authorize(Roles = "admin, manager")]
    public class CustomerProfiles : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly Helper _helper;
        private Dictionary<string, int> idMap = new Dictionary<string, int>();
        private int idCounter = 1;

        public int ConvertId(string longId)
        {
            // If the longId has already been converted, return the existing mapping
            if (idMap.ContainsKey(longId))
            {
                return idMap[longId];
            }

            // Otherwise, convert the string id to an integer id
            int newId = idCounter++;
            idMap[longId] = newId; // Store the mapping

            return newId;
        }

        public CustomerProfiles(ApplicationDbContext context, UserManager<AppUser> userManager, Helper helper)
        {
            _context = context;
            _userManager = userManager;
            _helper = helper;
        }

        public IActionResult Index()
        {
            if (!_helper.CheckPermission("UserList", User.Identity?.Name ?? ""))
            {
                return Redirect("/Account/Login");
            }


            var customerProfiles = _context.Users.ToList();
            return View(customerProfiles);
        }

        public async Task<IActionResult> Delete(string id)
        {
            if (!_helper.CheckPermission("UserDelete", User.Identity?.Name ?? ""))
            {
                return NotFound();
            }

            var customerProfile = await _context.Users.FindAsync(id);
            if (customerProfile == null)
            {
                return NotFound();
            }

            _context.Users.Remove(customerProfile);
            await _context.SaveChangesAsync();

            int newId = ConvertId(id);
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Reset(string id)
        {
            var customerProfile = await _context.Users.FindAsync(id);
            if (customerProfile == null)
            {
                return NotFound();
            }

            // Reset logic here. For example, you might want to reset some properties of the user.
            // customerProfile.SomeProperty = defaultValue;

            _context.Update(customerProfile);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet("CustomerProfiles/ResetPassword/{id}")]
        public IActionResult ResetPassword(string id)
        {
            if (!_helper.CheckPermission("UserResetPassword", User.Identity?.Name ?? ""))
            {
                return Redirect("/Account/Login");
            }
            ViewBag.id = id;
            return View();
        }


        [HttpPost("change-pass")]
        public async Task<IActionResult> ChangePass([FromForm] ChangPassViewModel vm)
        {
            var user = await _userManager.FindByIdAsync(vm.Id);
            if (user == null)
            {
                return Ok(new
                {
                    code = 400,
                    message = "not found"
                });
            }

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var result = await _userManager.ResetPasswordAsync(user, token, vm.NewPass);

            if (result.Succeeded)
            {
                return Ok(new
                {
                    code = 200,
                    message = "success"
                });
            }

            return Ok(new
            {
                code = 500,
                message = ""
            });
        }

        public async Task<IActionResult> Details(string id)
        {
            if (!_helper.CheckPermission("UserDetail", User.Identity?.Name ?? ""))
            {
                return Redirect("/Account/Login");
            }

            var customerProfile = await _context.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customerProfile == null)
            {
                return NotFound();
            }

            return View(customerProfile);
        }

        public async Task<IActionResult> ChangeRole([FromForm] ChangeRoleViewModel vm)
        {
            try
            {
                var user = await _context.Users
                    .FirstOrDefaultAsync(m => m.Id == vm.Id);

                await _userManager.RemoveFromRoleAsync(user, user.Role);

                await _userManager.AddToRoleAsync(user, vm.Role);


                return Ok(new
                {
                    code = 200,
                });
            }
            catch (Exception e)
            {
                return Ok(new
                {
                    code = 500,
                    message = e.Message
                });
            }
        }

        public IActionResult UpdatePermission(Permission vm)
        {

            try
            {
                var user = _context.Users
                    .FirstOrDefault(m => m.Id == vm.Id);

                user.Permission = vm.Permissions;

                _context.Update(user);
                _context.SaveChanges();


                return Ok(new
                {
                    code = 200,
                });
            }
            catch (Exception e)
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
