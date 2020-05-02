using System;

namespace WebSys.Dto
{
    public class UserDto
    {
        public Guid UserId { get; set; } = Guid.NewGuid();

        /// <summary>
        /// 登录名称
        /// </summary>

        public string LoginName { get; set; }

        /// <summary>
        /// 登录密码
        /// </summary>
        public string LoginPwd { get; set; } = "123";

        /// <summary>
        /// 部门简称、或缩写
        /// </summary>
        public string SimpleCode { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// 单微信应用程序的唯一码
        /// </summary>
        public string OpenId { get; set; }

        /// <summary>
        ///  多微信应用程序的唯一码、包含公众号与服务号
        /// </summary>
        public string UnionId { set; get; }

        /// <summary>
        /// 部门ID
        /// </summary>
        public Guid DepartmentId { get; set; }

        /// <summary>
        /// 部门名称 不存在user表
        /// </summary>
        public string DepartmentName { get; set; }

        public string Token { get; set; }
    }
}