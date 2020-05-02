using System.Threading.Tasks;

namespace WebSys.IBLL
{
    public interface IUserManager
    {
        Task<bool> Login(string loginName, string loginPwd);

        Task AddWeChatOpenIdByFullName(string opentId, string FullName);

        Task<WebSys.Dto.UserDto> GetWeChatByOpenId(string openId);
    }
}