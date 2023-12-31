﻿using System.Net.Http.Headers;

namespace UserManagement.Utility.Messages
{
    /// <summary>
    /// Defines a http get message.
    /// </summary>
    public class HttpGetMessage : IHttpMessage
    {
        /// <inheritdoc />
        public string GetResultMessage<T>(string endpoint, string? token, T content)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            var result = string.Empty;

            using (var client = new HttpClient())
            {
                var api = "http://localhost:8080/admin/realms/master/" + endpoint;

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                response = client.GetAsync(api).GetAwaiter().GetResult();
            }
            if(response != null)
            {
               result = response.Content.ReadAsStringAsync().Result;
            }

            if(result != null)
            {
                return result;
            }

            throw new Exception("Result is null.");
        }
    }
}
