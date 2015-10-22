using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml.Serialization;
using Plus.Communications.SMS;

namespace Plus.Communications.TubaSms
{
    public class TubaSms:ISms<SmsMessage>
    {
        [Serializable()]
        [XmlRoot("allmessage")]
        public class Messages
        {
            [XmlElement("msg", typeof(SmsMessage))]
            public SmsMessage[] Sms { get; set; }
        }
        private WebClient _client;

        private int _loginable = 0;
        public TubaSms()
        {
            _client=new WebClient();
        }
        //constansts
        private const string UrlAddress = "http://tsms.ir/url/";
        private const string ServiceUrl = UrlAddress + "tsmshttp.php";
        private const string LatestShowMessagesUrl = UrlAddress + "recived_sms_xml.php";

        //authentications stuff

        /// <summary>
        /// username panel
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// password panel
        /// </summary>
        public string Password { get;set;}

        /// <summary>
        /// user is loginable or it's a sub user in panel
        /// </summary>
        public int LoginableUser {
            set { _loginable = value; } }

        public WebProxy SetProxy
        {
            set { _client.Proxy = value; } 
        }

        public int SendSms(SmsMessage message)
        {
            Prepare();
            string url = ServiceUrl +
                         "?from={0}&to={1}&username={2}&password={3}&user_login={4}&message={5}";
            url=String.Format(url,message.From,message.To,Username,Password,_loginable,message.Message);

            string data=_client.DownloadString(url);
            return int.Parse(data);
        }

        /// <summary>
        /// ofcourse it Rials.
        /// </summary>
        /// <returns></returns>
        public int GetCredit(string from)
        {
            Prepare();
            string url = ServiceUrl +
                         "?from={0}&username={1}&password={2}&user_login={3}&credit=what";
            url = String.Format(url,from, Username, Password, _loginable);

            string data = _client.DownloadString(url);
            return int.Parse(data);
        }

        public int GetDelivered(string @from, int smsId)
        {
            Prepare();
            string url = ServiceUrl +
                         "?from={0}&username={1}&password={2}&user_login={3}&deliver20={4}";
            url = String.Format(url, from, Username, Password, _loginable,smsId);

            string data = _client.DownloadString(url);
            return int.Parse(data);
        }

        public SmsMessage[] Recieve200LastMessages(string from)
        {
            Prepare();
            string url = LatestShowMessagesUrl + "?username={0}&password={1}&from={2}";
            url = String.Format(url, Username, Password, from);

            var data = _client.DownloadString(url);

            var xmlOptions=new XmlSerializer(typeof(Messages));
            var reader = new StringReader(data);
            var messages = (Messages) xmlOptions.Deserialize(reader);

            foreach (var smsMessage in messages.Sms)
            {
                smsMessage.MessageDate=DateTime.Parse(smsMessage.StringDate);
                smsMessage.Message = HttpUtility.UrlDecode(smsMessage.Message);
            }
            return messages.Sms;
        }

        public SmsMessage RecieveMessage()
        {
            var message=new SmsMessage();
            var requestBody = HttpContext.Current.Request.QueryString;
            message.From = requestBody["from"];
            message.To = requestBody["to"];
            message.Message = HttpUtility.UrlDecode(requestBody["text"]);
            message.MessageDate=DateTime.Now;
            return message;
        }

        private void Prepare()
        {

            _client.Credentials = new NetworkCredential(Username,Password);
        }
    }
}
