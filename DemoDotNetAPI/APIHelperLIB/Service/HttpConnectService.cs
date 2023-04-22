using APIHelperLIB.Models;
using APIHelperLIB.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace APIHelperLIB.Service
{
    public class HttpConnectService : IHttpConnectService
    {
        public string PostAPI(string ip, string controller, string json)
        {
            try
            {
                using var client = new HttpClient();

                string url = ip + controller;
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = client.PostAsync(url, content).Result;

                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync().Result;
                    return result;
                }
                else
                {
                    throw new HttpRequestException($"Error to send HTTP request. StatusCode={response.StatusCode}. Response Content: {response.Content}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("PostAPI failed. " + ex.Message);
            }
        }

        public async Task PostAPIAsync(string ip, string controller, string json)
        {
            using var client = new HttpClient();

            string url = ip + controller;
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Content = new StringContent(json, Encoding.UTF8, "application/json");

            // Send the request without waiting for a response
            var _ = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
        }

        public string GetAPI(string url)
        {
            try
            {
                using var client = new HttpClient();

                var response = client.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    var content = response.Content.ReadAsStringAsync().Result;
                    return content;
                }
                else
                {
                    throw new HttpRequestException($"Error to send HTTP request. StatusCode={response.StatusCode}. Response Content: {response.Content}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("GetAPI failed. " + ex.Message);
            }
        }

        public async Task GetAPIAsync(string url)
        {
            using var client = new HttpClient();
            var response = await client.GetAsync(url);
            var _ = await response.Content.ReadAsStringAsync();
        }
    }
}
