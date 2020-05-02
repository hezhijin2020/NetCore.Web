using System.Collections.Generic;

namespace WebSys.APIWork.Filters.tools
{
    public class jwtTool
    {
        public static string Encode(IDictionary<string, object> payload, string key = null)
        {
            //if (string.IsNullOrEmpty(key))
            //    key = _Key;
            //IJwtAlgorithm algorithm = new HMACSHA256Algorithm();
            //IJsonSerializer serializer = new JsonNetSerializer();
            //IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
            //IJwtEncoder encoder = new JwtEncoder(algorithm, serializer, urlEncoder);
            //var token = encoder.Encode(payload, key);
            //payload.Add("outtime", DateTime.Now.AddDays(1));
            return "";
        }

        public static IDictionary<string, object> Decode(string token, string key = null)
        {
            //if (string.IsNullOrEmpty(key))
            //    key = _Key;
            //IJwtAlgorithm algorithm = new HMACSHA256Algorithm();
            //IJsonSerializer serializer = new JsonNetSerializer();
            //IDateTimeProvider provider = new UtcDateTimeProvider();
            //IJwtValidator validator = new JwtValidator(serializer, provider);
            //IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
            //IJwtDecoder decoder = new JwtDecoder(serializer, validator, urlEncoder, algorithm);
            //IDictionary<string, object> payload = decoder.DecodeToObject(token, key, verify: true);
            return null;
        }
    }
}