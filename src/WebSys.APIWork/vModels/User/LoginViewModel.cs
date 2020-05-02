using System.ComponentModel.DataAnnotations;

namespace WebSys.APIWork.vModels.User
{
    public class LoginViewModel
    {
        /// <summary>
        /// 登录名
        /// </summary>
        [Required]
        public string LoginName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [Required]
        public string LoginPwd { get; set; }
    }
}