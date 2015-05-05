using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.IO;
using System.Net;
using System.Net.Mail;
using System.Configuration;
using System.Text;
namespace jeffreymedina.com
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            footeryear.Text = dt.Year.ToString();
        }

        protected void sendmessage_Click(object sender, EventArgs e)
        {
            try
            {
                using (MailMessage mm = new MailMessage(ConfigurationManager.AppSettings["emailFrom"], ConfigurationManager.AppSettings["emailTo"]))
                {

                    string emailusername = ConfigurationManager.AppSettings["emailUsername"].ToString();
                    string emailPwd = ConfigurationManager.AppSettings["emailPwd"].ToString();

                    StringBuilder mailBody = new StringBuilder();
                    mailBody.AppendFormat("<h1>" + emailaddress.Text.ToString() + "</h1>");
                    mailBody.AppendFormat("<br />" + name.Text.ToString());
                    mailBody.AppendFormat("<br />" + message.Text.ToString());

                    mm.Subject = "Message from jeffreymedina.com";
                    mm.Body = mailBody.ToString();
                    mm.IsBodyHtml = true;
                    //SmtpClient smtp = new SmtpClient("relay-hosting.secureserver.net", 25);
                    SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                    smtp.EnableSsl = true;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential(emailusername, emailPwd);
                    smtp.Send(mm);
                    
                }
            }
            catch
            {
                messagepanel.Visible = false;
                messageerrorpanel.Visible = true;
            }
            finally
            {
                messagepanel.Visible = false;
                messagesentpanel.Visible = true;
            }


        }
    }
}