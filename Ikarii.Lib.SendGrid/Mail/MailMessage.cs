using System;
using System.Collections.Generic;
using System.Text;

namespace Ikarii.Lib.SendGrid.Mail
{
   public sealed class MailMessage
   {
      public Dictionary<String,String> Headers { get; set; }
      public KeyValuePair<String, String> From { get; set; }
      public KeyValuePair<String, String> ReplyTo { get; set; }
      public Dictionary<String, String> To { get; set; }
      public Dictionary<String, String> Cc { get; set; }
      public Dictionary<String, String> Bcc { get; set; }
      public string Subject { get; set; }
      public string HtmlBody { get; set; }
      public string TextBody { get; set; }


      public MailMessage()
      {
         this.Headers = new Dictionary<String, String>();
         this.From = new KeyValuePair<String, String>();
         this.ReplyTo = new KeyValuePair<String, String>();
         this.To = new Dictionary<String, String>();
         this.Cc = new Dictionary<String, String>();
         this.Bcc = new Dictionary<String, String>();

      }
   }
}
