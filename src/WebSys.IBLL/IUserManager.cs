using System.Threading.Tasks;

namespace WebSys.IBLL
{
    public interface IUserManager
    {
        Task<bool> Login(string loginName, string loginPwd);

        bool AddWeChatOpenIdByLogin(string opentId, string loginName,string loginPwd);

        Task<WebSys.Dto.UserDto> GetWeChatByOpenId(string openId);
    }
}