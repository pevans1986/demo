using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using System.Xml.XPath;

using Evans.Demo.Web.Api;

using Swashbuckle.Application;

using WebActivatorEx;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace Evans.Demo.Web.Api
{
	/// <summary>
	/// Initializes swagger documentation.
	/// </summary>
	public static class SwaggerConfig
	{
		#region Public Methods

		public static void Register()
		{
			var thisAssembly = typeof(SwaggerConfig).Assembly;

			GlobalConfiguration.Configuration
				.EnableSwagger(config =>
					{
						// Use "SingleApiVersion" to describe a single version API. Swagger 2.0
						// includes an "Info" object to hold additional metadata for an API. Version
						// and title are required but you can also provide additional fields by
						// chaining methods off SingleApiVersion.
						config.SingleApiVersion("v1", "Evans.Demo.Web.Api");

						// Properly indent the output Swagger docs
						config.PrettyPrint();

						// You can use "BasicAuth", "ApiKey" or "OAuth2" options to describe security schemes for the API.
						// See https://github.com/swagger-api/swagger-spec/blob/master/versions/2.0.md for more details.
						// NOTE: These only define the schemes and need to be coupled with a corresponding "security" property
						// at the document or operation level to indicate which schemes are required for an operation. To do this,
						// you'll need to implement a custom IDocumentFilter and/or IOperationFilter to set these properties
						// according to your specific authorization implementation
						//
						//c.BasicAuth("basic")
						//    .Description("Basic HTTP Authentication");
						//
						// NOTE: You must also configure 'EnableApiKeySupport' below in the SwaggerUI section
						//c.ApiKey("apiKey")
						//    .Description("API Key Authentication")
						//    .Name("apiKey")
						//    .In("header");
						//
						//c.OAuth2("oauth2")
						//    .Description("OAuth2 Implicit Grant")
						//    .Flow("implicit")
						//    .AuthorizationUrl("http://petstore.swagger.wordnik.com/api/oauth/dialog")
						//    //.TokenUrl("https://tempuri.org/token")
						//    .Scopes(scopes =>
						//    {
						//        scopes.Add("read", "Read access to protected resources");
						//        scopes.Add("write", "Write access to protected resources");
						//    });

						// Omit descriptions for any actions decorated with the Obsolete attribute
						config.IgnoreObsoleteActions();

						// Incorporate XML comments from annotated Controllers and API Types
						config.IncludeXmlComments(GetXmlCommentsPath());

						// Omit schema property descriptions for any type properties decorated with
						// the Obsolete attribute
						config.IgnoreObsoleteProperties();

						// In contrast to WebApi, Swagger 2.0 does not include the query string
						// component when mapping a URL to an action. As a result, Swashbuckle will
						// raise an exception if it encounters multiple actions with the same path
						// (sans query string) and HTTP method. You can workaround this by providing
						// a custom strategy to pick a winner or merge the descriptions for the
						// purposes of the Swagger docs
						config.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
					})
				.EnableSwaggerUi(config =>
					{
						config.DocumentTitle("Paul Evans - Demo Code");

						// If your API supports the OAuth2 Implicit flow, and you've described it correctly, according to
						// the Swagger 2.0 specification, you can enable UI support as shown below.
						//
						//c.EnableOAuth2Support(
						//    clientId: "test-client-id",
						//    clientSecret: null,
						//    realm: "test-realm",
						//    appName: "Swagger UI"
						//    //additionalQueryStringParams: new Dictionary<string, string>() { { "foo", "bar" } }
						//);

						// If your API supports ApiKey, you can override the default values.
						// "apiKeyIn" can either be "query" or "header"
						//
						//c.EnableApiKeySupport("apiKey", "header");
					});
		}

		#endregion Public Methods

		#region Private Methods

		private static Func<XPathDocument> GetXmlCommentsPath()
		{
			var baseDirectory = $"{AppDomain.CurrentDomain.BaseDirectory}bin\\";
			var commentsFileName = Assembly.GetExecutingAssembly().GetName().Name + ".XML";
			var commentsFile = Path.Combine(baseDirectory, commentsFileName);

			return () => new XPathDocument(commentsFile);
		}

		#endregion Private Methods
	}
}