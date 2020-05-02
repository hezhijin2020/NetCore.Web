using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WebSys.Dto;
using WebSys.IBLL;

namespace WebSys.BLL
{
    public class UserManager : IUserManager
    {
        private IDAL.IUserService userService = new DAL.UserService();

        public Task AddWeChatOpenIdByFullName(string opentId, string FullName)
        {
            throw new System.NotImplementedException();
        }

        public async Task< UserDto> GetWeChatByOpenId(string openId)
        {
            return await userService.GetALLAsync().Select(a => new Dto.UserDto()
            {
                OpenId = a.OpenId,
                SimpleCode = a.SimpleCode,
                DepartmentId = a.DepartmentId,
                DepartmentName = a.Department.DepartmentName,
                FullName = a.FullName,
                LoginName = a.LoginName,
                LoginPwd = a.LoginPwd,
                UserId = a.Id,
                UnionId = a.UnionId
            }).FirstOrDefaultAsync(b => b.OpenId == openId);
        }

        public Task<bool> Login(string loginName, string loginPwd)
        {
            throw new System.NotImplementedException();
        }
    }
}