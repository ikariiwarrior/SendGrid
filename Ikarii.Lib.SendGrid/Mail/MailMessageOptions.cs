using System;
using System.Collections.Generic;
using System.Text;

namespace Ikarii.Lib.SendGrid.Mail
{
   public class MailMessageOptions
   {
      /// <summary>
      /// An object following the pattern "substitution_tag":"value to substitute". All are assumed to be strings. These substitutions will apply to the content of your email, in addition to the subject and reply-to parameters. 
      /// </summary>
      internal Dictionary<String, String> Substitutions { get; set; } = new Dictionary<String, String>();

      /// <summary>
      /// A unix timestamp allowing you to specify when you want your email to be sent from SendGrid. If you have the flexibility, it’s better to schedule mail for off-peak times. Most emails are scheduled and sent at the top of the hour or half hour. Scheduling email to avoid those times (for example, scheduling at 10:53) can result in lower deferral rates because it won’t be going through our servers at the same times as everyone else’s mail.
      /// </summary>
      internal int SendAt { get; set; }

      /// <summary>
      /// An array of category names for this message. Each category name may not exceed 255 characters. You cannot have more than 10 categories per request.
      /// </summary>
      internal string[] Categories { get; set; }

      internal string TemplateId { get; set; }

      internal string BatchId { get; set; }

      /// <summary>
      /// Allows you to bypass all unsubscribe groups and suppressions to ensure that the email is delivered to every single recipient. This should only be used in emergencies when it is absolutely necessary that every recipient receives your email. Ex: outage emails, or forgot password emails.
      /// </summary>
      internal bool BypassListManagement { get; set; } = false;

      /// <summary>
      /// The default footer that you would like appended to the bottom of every email.
      /// </summary>
      internal string Footer { get; set; }

      /// <summary>
      /// This allows you to send a test email to ensure that your request body is valid and formatted correctly. For more information, please see our Classroom.
      /// </summary>
      internal bool SandboxMode { get; set; } = false;

      /// <summary>
      /// Allows you to track whether a recipient clicked a link in your email.
      /// </summary>
      internal bool ClickTracking { get; set; } = false;

      /// <summary>
      /// Allows you to track whether the email was opened or not, by including a single pixel image in the body of the content. When the pixel is loaded, we can log that the email was opened.
      /// </summary>
      internal bool OpenTracking { get; set; } = false;

      /// <summary>
      /// Allows you to insert a subscription management link at the bottom of the text and html bodies of your email. If you would like to specify the location of the link within your email, you may use the substitution_tag.
      /// </summary>
      internal bool SubscriptionTracking { get; set; } = false;

      /// <summary>
      /// Allows you to enable tracking provided by Google Analytics.
      /// </summary>
      internal bool GoogleAnalytics { get; set; } = false;
   }
}
