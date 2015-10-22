using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Plus.Communications.SMS
{
    
    [Serializable()]
    public class SmsMessage
    {
         [XmlElement("unicid")]
        public int MessageId { get; set; }
         [System.Xml.Serialization.XmlElement("date")]
         public string StringDate { get; set; }
        public DateTime MessageDate { get; set; }
        public string To { get; set; }

         [System.Xml.Serialization.XmlElement("from")]
        public string From { get; set; }

         [System.Xml.Serialization.XmlElement("text")]
        public string Message { get; set; }
    }
}
