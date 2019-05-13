using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Ikarii.Lib.SendGrid.Mail
{
   public class WebApiMailClient
   {
      private const string _endpoint = "https://api.sendgrid.com/v3/mail/send";

      private readonly WebApiClient _client;
      
      public WebApiMailClient( WebApiClient client ) => this._client = client;


      public async Task<IWebApiResponse> SendAsync( MailMessage msg, MailMessageOptions options )
      {
         var response = new MailMessageResponse();
         var httpClient = _client.GetHttpClient();
         httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue( "Bearer", this._client._apiKey );
         httpClient.DefaultRequestHeaders.Accept.Add( new MediaTypeWithQualityHeaderValue( "application/json" ) );
         options.Substitutions.Add( "%clientname%", "test" );
         options.Substitutions.Add( "%banana%", "bananas" );
         var payload = BuildPayload( msg, options );
         var result = await httpClient.PostAsync( _endpoint, new StringContent( payload, Encoding.UTF8, "application/json" ) );
         return ( response );
      }


      private string BuildPayload( MailMessage msg, MailMessageOptions options )
      {
         var payload = new
         {
            personalizations = new []
            {
               new {
                  to = msg.To.Select( x => new { email = x.Key, name = x.Value } ),
                  //cc = msg.Cc?.Select( x => new { email = x.Key, name = x.Value } ),
                  //bcc = msg.Bcc?.Select( x => new { email = x.Key, name = x.Value } ),
                  subject = msg.Subject,
                  headers = new { },
                  substitutions = options.Substitutions
               }
            },
            from = new { email = msg.From.Key, name = msg.From.Value },
            
            //reply_to = new { email = msg.ReplyTo.Key, name = msg.ReplyTo.Value },
            send_at = options.SendAt,
            //batch_id = options.BatchId ?? Guid.NewGuid().ToString(),
            content = new []{
               new { type="text/plain", value = msg.TextBody },
               new { type="text/html", value = msg.HtmlBody }
            },
            mail_settings = new
            {
               bypass_list_management = new { enable = options.BypassListManagement },
               sandbox_mode = new { enable = options.SandboxMode }
            },
            //template_id = options.TemplateId,
            //categories = options.Categories?.Select( x => x ),
            tracking_settings = new
            {
               click_tracking = new
               {
                  enable = options.ClickTracking,
                  enable_text = options.ClickTracking
               },
               open_tracking = new
               {
                  enable = options.OpenTracking,
                  substitution_tag = String.Empty
               },
               subscription_tracking = new
               {
                  enable = options.SubscriptionTracking,
                  text = String.Empty,
                  html = String.Empty,
                  substitution_tag = String.Empty
               },
               ganalytics = new
               {
                  enable = options.GoogleAnalytics,
                  utm_source = String.Empty,
                  utm_medium = String.Empty,
                  utm_term = String.Empty,
                  utm_content = String.Empty,
                  utm_campaign = String.Empty
               }
            }
         };

         return ( JsonConvert.SerializeObject( payload, Formatting.Indented ) );
      }
   }
}
