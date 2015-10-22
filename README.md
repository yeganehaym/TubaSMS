# TubaSMS

SMS class for tuba sms system and specially for web uses

this class give you ability to

1- send sms

2-delivered report

3- get credits

4- get 200 last sms you recieved

5- get any sms arrived at any time


این کلاس برای  ارسال اس ام اس از طریق خدمات شرکت توباست که برای هر پلتفرمی به خصوص وب آماده شده است

قابلیت های این کلاس

یک. ارسال پیامک

دو. گزارش تحویل

سه.دریافت میزان اعتبار

چهار. دریافت 200 پیامک اخیر

پنج. دریافت لحظه ای پیامک مختص وب

```C#

  var tubaSms = new TubaSms
            {
                Username = "username",
                Password = "password",
                LoginableUser = 0
            };
            
//or

var tubaSms=new TubaSms("username","password",0);


//send sms (xxx is your number get from tube like 3000123123)
 int smsId=tubaSms.SendSms(new SmsMessage()
            {
                Message = "this is message",
                From = "xxx",
                To = "yyy"
            });

//delivered or not?
//check it 5 minutes after sent in 24 hours
tubaSms.GetDelivered("xxx", smsId);

//credits
 tubaSms.GetCredit("xxx");

//recieve
 tubaSms.Recieve200LastMessages("xxx");
 
 //just for web (you need to define your url on tuba system
 tubaSms.RecieveMessage();


```

