using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Net;
using System.Security.Claims;
using System.Text;
using WebSys.APIWork.vModels.toolsvModels;

namespace WebSys.APIWork.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        #region 用户Jwt授权颁发Token

        private JwtSettings _jwtSettings;

        public HomeController(IOptions<JwtSettings> _jwtSettingsAccesser)
        {
            _jwtSettings = _jwtSettingsAccesser.Value;
        }

        [HttpPost]
        public IActionResult Index(string LoginName, string LoginPwd)
        {
            if (ModelState.IsValid)//判断是否合法
            {
                if (!(LoginName == "wyt" && LoginPwd == "123456"))//判断账号密码是否正确
                {
                    //return "";
                    return BadRequest();
                }

                try
                {
                    var claim = new Claim[]{
                    new Claim(ClaimTypes.Name,"wyt"),
                    new Claim(ClaimTypes.Role,"admin")
                };

                    //对称秘钥
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));
                    //签名证书(秘钥，加密算法)
                    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    //生成token  [注意]需要nuget添加Microsoft.AspNetCore.Authentication.JwtBearer包，并引用System.IdentityModel.Tokens.Jwt命名空间
                    var token = new JwtSecurityToken(_jwtSettings.Issuer, _jwtSettings.Audience, claim, DateTime.Now, DateTime.Now.AddDays(1), creds);

                    //return token.ToString();
                    return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
                }
                catch
                {
                    return BadRequest();
                }
            }

            return BadRequest();
        }

        #endregion 用户Jwt授权颁发Token

        [HttpGet]
        public string Index()
        {
            return "WebSys服务,接口列表";
        }

      /// <summary>
      /// 检查OpenId 是否有关联用户信息
      /// </summary>
      /// <param name="OpenId">OpenId</param>
      /// <returns></returns>
        public bool ExistsUserByOpenId(string OpenId ,out Dto.UserDto uDto)
        {
            IBLL.IUserManager userManager = new  BLL.UserManager();
            var userDto= userManager.GetWeChatByOpenId(OpenId);
            userDto.Wait();
            if (userDto.Result == null)
            {
                uDto = null;
                return false;
            }
            else
            {
                uDto= userDto.Result;
                return true;
            }
        }

        [Route("GetUserDtoByCode")]
        public vModels.ResponsevModel.ResponseData GetRequertCode(string Code)
        {
           //https://api.weixin.qq.com/sns/jscode2session?appid=APPID&secret=APPSECRET&js_code=CODE&grant_type=authorization_code
            string appid = "wx1fbe11921dd5ccc5";
            string appsecret = "7bb5b01a0259765dd6b93cec0369ad8c";
            string Url = string.Format("https://api.weixin.qq.com/sns/jscode2session?appid={0}&secret={1}&js_code={2}&grant_type=authorization_code", appid, appsecret, Code);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
            request.Method = "GET";
            request.ContentType = "textml;charset=UTF-8";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.UTF8);
            string jsonData = myStreamReader.ReadToEnd();
            response.Close();
            myStreamReader.Close();
            myResponseStream.Close();

            JObject obj= Common.cls.clsPublic.StringConvertToJson(jsonData);
            if (obj == null)
            {
                return new vModels.ResponsevModel.ResponseData() {Code=500, Msg = "获取OpenId错误" };
            }
            else
            {
                string OpenId = obj["openid"].ToString();
                Dto.UserDto udto = new Dto.UserDto();
                if (ExistsUserByOpenId(OpenId, out udto))
                {
                    return new vModels.ResponsevModel.ResponseData() { Data = udto };
                }
                else {
                    return new vModels.ResponsevModel.ResponseData() {Code=401, Msg = "没有关联用户" };
                }
            }
        }
    }
}