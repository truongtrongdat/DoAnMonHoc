using DoAnMonHoc.Data;
using DoAnMonHoc.ViewModel;
using Newtonsoft.Json;

namespace DoAnMonHoc.Services
{
    public class Helper
    {
        private readonly ApplicationDbContext _context;

        public Helper(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool CheckPermission(string permission, string username)
        {
            AppUser user = _context.Users.FirstOrDefault(i=>i.UserName== username);

            if (user == null)
            {
                return false;
            }

            if (user.Role == "admin")
            {
                return true;
            }

            if(user.Role == "user")
            {
                return false;
            }

            List<string> list_permission = JsonConvert.DeserializeObject<List<string>>(user.Permission);

            if(list_permission == null)
            {
                return false;
            }

            if (list_permission.Contains(permission))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
