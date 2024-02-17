using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using MassTransit;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace CommonMormon.Infrastructure.Core.Utils;

/// <summary>
/// HttpClient 帮助类
/// </summary>
public class HttpClientHelper
{
    private readonly IHttpClientFactory _httpClientFactory = null!;
    private readonly ILogger<HttpClientHelper> _logger;
    private readonly JsonSerializerSettings _requestSettings;
    private readonly JsonSerializerSettings _responseSettings;

    /// <summary>
    /// 初始化
    /// </summary>
    public HttpClientHelper(IHttpClientFactory httpClientFactory, ILogger<HttpClientHelper> logger)
    {
        _httpClientFactory = httpClientFactory;
        _logger = logger;

        _requestSettings = new JsonSerializerSettings()
        {
            ContractResolver = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            },
            NullValueHandling = NullValueHandling.Ignore
        };

        _responseSettings = new JsonSerializerSettings()
        {
            ContractResolver = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            },
            NullValueHandling = NullValueHandling.Ignore,
            MaxDepth = 5
        };
    }

    /// <summary>
    /// Get
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="url"></param>
    /// <param name="headers"></param>
    /// <param name="responseSettings"></param>
    /// <returns></returns>
    public async Task<T?> GetAsync<T>(string url, Dictionary<string, string>? headers, JsonSerializerSettings? responseSettings)
    {
        var responseBody = await GetAsync(url, headers);
        return responseBody is null ? default : JsonConvert.DeserializeObject<T>(responseBody, responseSettings);
    }

    /// <summary>
    /// Post
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="url"></param>
    /// <param name="body"></param>
    /// <param name="headers"></param>
    /// <param name="requestSettings"></param>
    /// <param name="responseSettings"></param>
    /// <returns></returns>
    public async Task<T?> PostAsync<T>(string url, object body, Dictionary<string, string>? headers, JsonSerializerSettings? requestSettings, JsonSerializerSettings? responseSettings)
    {
        var responseBody = await PostAsync(url, body, headers, requestSettings);
        return responseBody is null ? default : JsonConvert.DeserializeObject<T>(responseBody, responseSettings);
    }

    /// <summary>
    /// Get
    /// </summary>
    /// <param name="url"></param>
    /// <param name="headers"></param>
    /// <returns></returns>
    public async Task<string> GetAsync(string url, Dictionary<string, string>? headers)
    {
        _logger.LogInformation("{url} - request: {content}", url, string.Empty);
        var httpClient = _httpClientFactory.CreateClient();
        var request = new HttpRequestMessage(HttpMethod.Get, url);
        AddHeaders(request, headers);
        var response = await httpClient.SendAsync(request);
        if (response.StatusCode == HttpStatusCode.Unauthorized)
        {
            string refreshedAccessToken = await RefreshAccessToken();
            if (!string.IsNullOrEmpty(refreshedAccessToken))
            {
                AddAuthorizationHeader(request, refreshedAccessToken);
                response = await httpClient.SendAsync(request);
            }
        }
        response.EnsureSuccessStatusCode();
        var responseContent = await response.Content.ReadAsStringAsync();
        _logger.LogInformation("{url} - response: {content}", url, responseContent);
        return responseContent;
    }

    /// <summary>
    /// Post
    /// </summary>
    /// <param name="url"></param>
    /// <param name="body"></param>
    /// <param name="headers"></param>
    /// <param name="requestSettings"></param>
    /// <returns></returns>
    public async Task<string> PostAsync(string url, object body, Dictionary<string, string>? headers, JsonSerializerSettings? requestSettings)
    {
        var jsonBody = JsonConvert.SerializeObject(body, requestSettings);
        _logger.LogInformation("{url} - request: {content}", url, jsonBody);
        var httpClient = _httpClientFactory.CreateClient();
        var request = new HttpRequestMessage(HttpMethod.Post, url);
        AddHeaders(request, headers);
        request.Content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
        var response = await httpClient.SendAsync(request);
        if (response.StatusCode == HttpStatusCode.Unauthorized)
        {
            var refreshedAccessToken = await RefreshAccessToken();
            if (!string.IsNullOrEmpty(refreshedAccessToken))
            {
                AddAuthorizationHeader(request, refreshedAccessToken);
                response = await httpClient.SendAsync(request);
            }
        }
        response.EnsureSuccessStatusCode();
        var responseContent = await response.Content.ReadAsStringAsync();
        _logger.LogInformation("{url} - response: {content}", url, responseContent);
        return responseContent;
    }

    private void AddHeaders(HttpRequestMessage request, Dictionary<string, string> headers)
    {
        if (headers != null)
        {
            foreach (var header in headers)
            {
                if (request.Headers.Contains(header.Key))
                {
                    request.Headers.Remove(header.Key);
                }
                request.Headers.Add(header.Key, header.Value);
            }
        }

        var accessToken = GetAccessTokenFromSomewhere();
        if (!string.IsNullOrEmpty(accessToken))
        {
            AddAuthorizationHeader(request, accessToken);
        }
    }

    private void AddAuthorizationHeader(HttpRequestMessage request, string accessToken)
    {
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
    }

    private static string GetAccessTokenFromSomewhere()
    {
        return "YOUR_ACCESS_TOKEN";
    }

    private async Task<string> RefreshAccessToken()
    {
        return string.Empty;
    }
}
