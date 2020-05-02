using WebSys.IDAL;

namespace WebSys.DAL
{
    public class UserService : BaseService<Models.ACL_User>, IUserService
    {
        public UserService() : base(new Models.WebSysDBContext())
        {
        }
    }
}