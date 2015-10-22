
using System.Collections.Generic;
using System.Net;

namespace Plus.Communications.SMS
{
    public interface ISms<T> where T:SmsMessage
    {
        string Username {  set; }
        string Password { set; }
        int LoginableUser {  set; }

        WebProxy SetProxy { set; }

        int SendSms(T message);

        int GetCredit(string from);

        int GetDelivered(string from, int smsId);

        T[] Recieve200LastMessages(string yourPage);
        T RecieveMessage();
    }
}
