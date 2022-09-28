using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dollars_Chat
{
    class NormalUser:UserInfo
    {
       public int Code;

        public NormalUser(string UN, string P,int C):base(UN,P)
        {
            Code = C;
        }
    }
}
