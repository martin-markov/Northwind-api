using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.UI.Services
{
    public class RestApiService : IDisposable
    {
        private HttpClient _httpClient;
        public RestApiService()
        {
            string host = ConfigurationManager.AppSettings["ApiBaseUrl"];
            string apiResponseType = ConfigurationManager.AppSettings["ApiResponseType"];

            this._httpClient = new HttpClient
            {
                BaseAddress = new Uri(host)
            };
            this._httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(apiResponseType));
        }

        private async Task<HttpResponseMessage> PostJsonAsync(string path, string jsonString)
        {
            StringContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            return await this._httpClient.PostAsync(path, content);
        }

        private async Task<HttpResponseMessage> PostJsonAsync(string path, MultipartFormDataContent obj)
        {
            return await this._httpClient.PostAsync(path, obj);
        }

        private async Task<HttpResponseMessage> PostFormUrlEncodedAsync(string path, Dictionary<string, string> formData)
        {
            FormUrlEncodedContent content = new FormUrlEncodedContent(formData);
            return await this._httpClient.PostAsync(path, content);
        }



        /// <summary>
        /// Creates a GET request.
        /// </summary>
        /// <param name="queryString">Relative path query string with parameters.</param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> GetAsync(string queryString)
        {
            HttpResponseMessage response = await this._httpClient.GetAsync(queryString);
            string responseContent = await response.Content.ReadAsStringAsync();
            return response;
        }

        /// <summary>
        /// Creates a GET request.
        /// </summary>
        /// <param name="queryString">Relative path query string with parameters.</param>
        /// <returns></returns>
        public async Task<string> GetJsonAsync(string queryString)
        {
            HttpResponseMessage response = await this._httpClient.GetAsync(queryString);
            string responseContent = await response.Content.ReadAsStringAsync();
            return responseContent;
        }

        /// <summary>
        /// Creates a GET request.
        /// </summary>
        /// <param name="path">Resource relative path.</param>
        /// <param name="queryParameters">Contains the parameters which will be added to the query string.</param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> GetAsync(string path, Dictionary<string, string> queryParameters)
        {
            StringBuilder strb = new StringBuilder(path);

            if (queryParameters.Count > 0)
            {
                strb.Append("?");
                for (int i = 0; i < queryParameters.Count; i++)
                {
                    strb.Append(queryParameters.ElementAt(i).Key);
                    strb.Append("=");
                    strb.Append(queryParameters.ElementAt(i).Value);
                    if (i < queryParameters.Count - 1)
                    {
                        strb.Append("&");
                    }
                }
            }

            return await GetAsync(strb.ToString());
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if(!this.disposed)
            {
                if(disposing)
                {
                    _httpClient.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}