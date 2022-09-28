using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dollars_Chat
{
    class VIPUser : UserInfo
    {
        public int Code;
        public int creditCardNum;
        public int SecurityNum;
        public int DonatedAmount;

        public VIPUser(string UN, string P, int C) : base(UN, P)
        {
            Code = C;
        }

       public string WhichTier()
        {
            if(DonatedAmount>0&&DonatedAmount<50)
            {
                return "Tier1";
            }
            else if (DonatedAmount >= 50 && DonatedAmount < 100)
            {
                return "Tier 2";
            }

            else
            {
                return "Invalid";
            }
        }
    }
}

