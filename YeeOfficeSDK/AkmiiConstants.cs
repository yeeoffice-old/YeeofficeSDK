using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace YeeOfficeSDK
{
    public class AkmiiConstants
    {
        public const string AkmiiSecret = "AkmiiSecret";
        public static string GetAkmiiSecret()
        {
            var request = HttpContext.Current?.Request;
            if (request == null)
            {
                return null;
            }
            string token = request.Headers.Get(AkmiiSecret);
            //querystring
            if (string.IsNullOrWhiteSpace(token))
            {
                token = request.QueryString.Get(AkmiiSecret);
            }
            //cookie
            if (string.IsNullOrWhiteSpace(token))
            {
                token = request.Cookies.Get(AkmiiSecret)?.Value;
                token = string.IsNullOrWhiteSpace(token) ? "" : HttpUtility.UrlDecode(token, Encoding.UTF8);
            }
            return token;
        }
    }
}
