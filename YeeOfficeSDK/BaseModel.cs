using YeeOfficeSDK.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YeeOfficeSDK
{
    public class BaseModel
    {
        public string GetJsonString()
        {
            return ToString();
        }

        public override string ToString()
        {
            return JsonHelper.SerializationToJson(this);
        }
    }
}
