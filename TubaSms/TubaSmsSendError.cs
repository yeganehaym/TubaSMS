using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plus.Communications.TubaSms
{
    public enum TubaSmsSendError
    {
        ServerError=1,
        UDH_OverflowMessage=2,
        Wrong_To=3,
        WrongVariables=4,
        MessageIsEmpty=5,
        ToIsUndefind=6,
        BadAuthentication=7,
        NeedToTry=8,
        ServiceIsOut=9,
        Uncredit=14
    }
}
