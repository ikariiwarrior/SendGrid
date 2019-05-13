using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Ikarii.Lib.SendGrid
{
   public class WebApiClient : ISendGridClient
   {
      private readonly IHttpClientFactory _httpClientFactory;
      internal readonly string _apiKey;
      /// <summary>
      /// 
      /// </summary>
      /// <param name="httpClientFactory"></param>
      public WebApiClient( string apiKey, IHttpClientFactory httpClientFactory  )
      {
         this._apiKey = apiKey;
         this._httpClientFactory = httpClientFactory;
      }

      /// <summary>
      /// 
      /// </summary>
      public WebApiClient( string apiKey ) : this( apiKey, null ) { }

      public async Task<IWebApiResponse> ExecuteApiCall( Func<HttpClient,Object,Task<IWebApiResponse>> _func )
      {
         var httpClient = this._httpClientFactory.CreateClient();
         var result = await _func( httpClient, new { } );
         return ( result );
      }

      internal HttpClient GetHttpClient()
      {
         if( _httpClientFactory != null )
            return ( this._httpClientFactory.CreateClient( "SendGrid_WebClient" ) );
         else
            return ( new HttpClient() );
      }
   }
}
