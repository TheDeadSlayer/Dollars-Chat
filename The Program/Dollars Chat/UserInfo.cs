using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dollars_Chat
{
    abstract class UserInfo
    {
        public string UserName;
        public string Password;

        public UserInfo (string UN,string P)
        {
            UserName = UN;
            Password = P;
        }
    }
}
