

namespace Geziyoruz.WebUI.Models;

public class MailVM
{
    public string SendDisplayName { get; set; }

    string email = "emre.barut97@outlook.com";
    public string SendMail
    {
        get
        {
            return email;
        }
        set
        {
            email = value;
        }
    }

    string password = "Emre7797";
    public string SendPassword
    {
        get
        {
            return password;
        }
        set
        {
            password = value;
        }
    }

    public string Subject { get; set; }

    public string Body { get; set; }

    string mailTo = "emrebarut1997@gmail.com";
    public string MailTo
    {
        get
        {
            return mailTo;
        }
        set
        {
            mailTo = value;
        }
    }


}
