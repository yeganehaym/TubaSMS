using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plus.Communications.TubaSms
{
    public enum TubaSmsDeliver
    {
        Dlivered=1,
        NoDelivered=2,
        NotDeliveredYet=5,
        NotDeliveredYetOrWrongCode=9
    }
}
