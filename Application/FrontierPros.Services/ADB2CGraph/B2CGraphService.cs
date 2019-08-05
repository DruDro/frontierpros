using FrontierPros.Core.Configuration;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace FrontierPros.Services.ADB2CGraph
{
	public class B2CGraphService : IB2CGraphService
	{
		private readonly ADB2CGraphConfig _b2cGraphConfig;

		private AuthenticationContext authContext;
		private ClientCredential credential;

		public B2CGraphService(ADB2CGraphConfig b2cGraphConfig)
		{
			_b2cGraphConfig = b2cGraphConfig;

			// The AuthenticationContext is ADAL's primary class, in which you indicate the direcotry to use.
			this.authContext = new AuthenticationContext("https://login.microsoftonline.com/" + _b2cGraphConfig.Tenant);

			// The ClientCredential is where you pass in your client_id and client_secret, which are 
			// provided to Azure AD in order to receive an access_token using the app's identity.
			this.credential = new ClientCredential(_b2cGraphConfig.ClientId, _b2cGraphConfig.ClientSecret);
		}

		public async Task<string> GetUserByObjectIdAsync(string objectId)
		{
			return await SendGraphGetRequest("/users/" + objectId, null);
		}

		public async Task<string> GetAllUsersAsync(string query)
		{
			return await SendGraphGetRequest("/users", query);
		}

		public async Task<string> CreateUserAsync(object data)
		{
			var json = JsonConvert.SerializeObject(data);
			return await SendGraphPostRequest("/users", json);
		}

		public async Task<string> UpdateUserAsync(string objectId, object data)
		{
			var json = JsonConvert.SerializeObject(data);
			return await SendGraphPatchRequest("/users/" + objectId, json);
		}

		public async Task<string> DeleteUserAsync(string objectId)
		{
			return await SendGraphDeleteRequest("/users/" + objectId);
		}

		public async Task<string> RegisterExtension(string objectId, string body)
		{
			return await SendGraphPostRequest("/applications/" + objectId + "/extensionProperties", body);
		}

		public async Task<string> UnregisterExtension(string appObjectId, string extensionObjectId)
		{
			return await SendGraphDeleteRequest("/applications/" + appObjectId + "/extensionProperties/" + extensionObjectId);
		}

		public async Task<string> GetExtensions(string appObjectId)
		{
			return await SendGraphGetRequest("/applications/" + appObjectId + "/extensionProperties", null);
		}

		public async Task<string> GetApplications(string query)
		{
			return await SendGraphGetRequest("/applications", query);
		}

		private async Task<string> SendGraphDeleteRequest(string api)
		{
			// NOTE: This client uses ADAL v2, not ADAL v4
			AuthenticationResult result = await authContext.AcquireTokenAsync(_b2cGraphConfig.GraphResourceId, credential);
			HttpClient http = new HttpClient();
			string url = _b2cGraphConfig.GraphEndpoint + _b2cGraphConfig.Tenant + api + "?" + _b2cGraphConfig.GraphVersion;
			HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Delete, url);
			request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", result.AccessToken);
			HttpResponseMessage response = await http.SendAsync(request);

			if (!response.IsSuccessStatusCode)
			{
				string error = await response.Content.ReadAsStringAsync();
				object formatted = JsonConvert.DeserializeObject(error);
				throw new WebException("Error Calling the Graph API: \n" + JsonConvert.SerializeObject(formatted, Formatting.Indented));
			}

			return await response.Content.ReadAsStringAsync();
		}

		private async Task<string> SendGraphPatchRequest(string api, string json)
		{
			// NOTE: This client uses ADAL v2, not ADAL v4
			AuthenticationResult result = await authContext.AcquireTokenAsync(_b2cGraphConfig.GraphResourceId, credential);
			HttpClient http = new HttpClient();
			string url = _b2cGraphConfig.GraphEndpoint + _b2cGraphConfig.Tenant + api + "?" + _b2cGraphConfig.GraphVersion;
			HttpRequestMessage request = new HttpRequestMessage(new HttpMethod("PATCH"), url);
			request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", result.AccessToken);
			request.Content = new StringContent(json, Encoding.UTF8, "application/json");
			HttpResponseMessage response = await http.SendAsync(request);

			if (!response.IsSuccessStatusCode)
			{
				string error = await response.Content.ReadAsStringAsync();
				object formatted = JsonConvert.DeserializeObject(error);
				throw new WebException("Error Calling the Graph API: \n" + JsonConvert.SerializeObject(formatted, Formatting.Indented));
			}

			return await response.Content.ReadAsStringAsync();
		}

		private async Task<string> SendGraphPostRequest(string api, string json)
		{
			// NOTE: This client uses ADAL v2, not ADAL v4
			AuthenticationResult result = await authContext.AcquireTokenAsync(_b2cGraphConfig.GraphResourceId, credential);
			HttpClient http = new HttpClient();
			string url = _b2cGraphConfig.GraphEndpoint + _b2cGraphConfig.Tenant + api + "?" + _b2cGraphConfig.GraphVersion;

			HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, url);
			request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", result.AccessToken);
			request.Content = new StringContent(json, Encoding.UTF8, "application/json");
			HttpResponseMessage response = await http.SendAsync(request);

			if (!response.IsSuccessStatusCode)
			{
				string error = await response.Content.ReadAsStringAsync();
				object formatted = JsonConvert.DeserializeObject(error);
				throw new WebException("Error Calling the Graph API: \n" + JsonConvert.SerializeObject(formatted, Formatting.Indented));
			}

			return await response.Content.ReadAsStringAsync();
		}

		public async Task<string> SendGraphGetRequest(string api, string query)
		{
			// First, use ADAL to acquire a token using the app's identity (the credential)
			// The first parameter is the resource we want an access_token for; in this case, the Graph API.
			AuthenticationResult result = await authContext.AcquireTokenAsync("https://graph.windows.net", credential);

			// For B2C user managment, be sure to use the 1.6 Graph API version.
			HttpClient http = new HttpClient();
			string url = "https://graph.windows.net/" + _b2cGraphConfig.Tenant + api + "?" + _b2cGraphConfig.GraphVersion;
			if (!string.IsNullOrEmpty(query))
			{
				url += "&" + query;
			}

			// Append the access token for the Graph API to the Authorization header of the request, using the Bearer scheme.
			HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);
			request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", result.AccessToken);
			HttpResponseMessage response = await http.SendAsync(request);

			if (!response.IsSuccessStatusCode)
			{
				string error = await response.Content.ReadAsStringAsync();
				object formatted = JsonConvert.DeserializeObject(error);
				throw new WebException("Error Calling the Graph API: \n" + JsonConvert.SerializeObject(formatted, Formatting.Indented));
			}
			return await response.Content.ReadAsStringAsync();
		}
	}
}
