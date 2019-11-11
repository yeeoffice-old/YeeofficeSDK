using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YeeOfficeSDKUnitTest
{
    public class Util
    {
        public static string DomainUrl = ConfigurationManager.AppSettings["domainUrl"];
        public static string Secret = ConfigurationManager.AppSettings["secret"];
    }
}
