namespace WebSys.APIWork.vModels.toolsvModels
{
    public class JwtSettings
    {
        /// <summary>
        /// token颁发机构
        /// </summary>
        public string Issuer { get; set; }

        /// <summary>
        /// 可以给哪些客户端使用
        /// </summary>
        public string Audience { get; set; }

        /// <summary>
        /// 加密码的Key
        /// </summary>
        public string SecretKey { get; set; }
    }
}