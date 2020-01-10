using System;
using System.Collections.Generic;
using System.Text;

namespace MyClass.Models
{
    class Token
    {
        public int id { get; set; }
        public string acess_token { get; set; }
        public string error_description { get; set; }
        public DateTime expire_time { get; set; }
        
    }
}
