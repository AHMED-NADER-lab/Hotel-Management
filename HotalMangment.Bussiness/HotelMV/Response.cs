using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotalMangment.Bussiness.HotelMV
{
 public   class Response
    {
        public bool IsValid { get; set; }

        public Dictionary<string, string> ErrorMessages { get; set; }
        public Dictionary<string, string> SucessMessages { get; set; }

        public Response()
        {
            ErrorMessages = new Dictionary<string, string>();
            SucessMessages= new Dictionary<string, string>();
        }
    }
}
