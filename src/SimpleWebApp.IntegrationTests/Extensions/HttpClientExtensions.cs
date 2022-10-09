using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace SimpleWebApp.IntegrationTests.Extensions
{
	internal static class HttpClientExtensions
	{
		public static async Task<ApiResponse<T>> GetAsync<T>(this HttpClient client, string url) where T : class
		{
			var response = await client.GetAsync(url);
			var value = await response.Content.ReadAsStringAsync();

			var result = new ApiResponse<T>
			{
				StatusCode = response.StatusCode
			};

			try
			{
				result.Result = JsonConvert.DeserializeObject<T>(value);
			}
			catch (Exception) { }

			return result;
		}

		public static async Task<ApiResponse<T>> PostAsync<T>(this HttpClient client, string url, object body) where T : class
		{
			HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");

			var response = await client.PostAsync(url, httpContent);
			var value = await response.Content.ReadAsStringAsync();

			var result = new ApiResponse<T>
			{
				StatusCode = response.StatusCode
			};

			try
			{
				result.Result = JsonConvert.DeserializeObject<T>(value);
			}
			catch (Exception) { }

			return result;
		}
	}

	internal class ApiResponse<T>
	{
		public HttpStatusCode StatusCode { get; set; }
		public T Result { get; set; }
	}
}
