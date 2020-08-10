using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodDentist.Common.MessageHelper
{
    public class AliCloudMessageResponse
    {
        public string Message { get; set; }
        public string RequestId { get; set; }
        public string BizId { get; set; }
        public string Code { get; set; }
    }
}
