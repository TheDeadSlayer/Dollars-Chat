using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dollars_Chat
{
    class AdminUser : UserInfo
    {
        public int Code;

        public AdminUser(string UN, string P, int C) : base(UN, P)
        {
            Code = C;
        }
    }
}
