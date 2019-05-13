using Ikarii.Lib.SendGrid;
using Ikarii.Lib.SendGrid.Mail;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace Ikarii.List.SendGrid.Tests
{
   [TestClass]
   public class UnitTest1
   {
      [TestMethod]
      public async Task TestMethod1()
      {
         var base_client = new WebApiClient( "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" );
         var mail_client = new WebApiMailClient( base_client );
         var msg = new MailMessage()
         {
            From = new System.Collections.Generic.KeyValuePair<string, string>( "shall@etnainteractive.com", "Shawn Hall" ),
            Subject = "This is a test email",
            HtmlBody = "<body>Hello World</body>",
            TextBody = "Hello World"
         };
         msg.To.Add( "shawn@ikarii.com", "Ikarii Warrior" );
         await mail_client.SendAsync( msg, new MailMessageOptions() );
      }
   }
}
