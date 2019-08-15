using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MakaleApp.Helper
{
    public class HttpApiHelper
    {
        public HttpApiHelper(string url, string metot)
        {
            this.url = url;
            this.metot = metot;
        }

        public string url { get; set; }
        public string metot { get; set; }

        public string GetResponse()
        {
            WebRequest request = WebRequest.Create(url) as HttpWebRequest;
            request.Method = metot;
            request.ContentType = "application/json";
            request.ContentLength = 0;
            //request.Headers.Add("ApiUser", Environment.GetEnvironmentVariable("ApiUser"));
            //request.Headers.Add("ApiPassword", Environment.GetEnvironmentVariable("ApiPassword"));

            using (var response = request.GetResponse() as HttpWebResponse)
            {
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    var responseContent = reader.ReadToEnd();
                    return responseContent;
                }
            }
        }

        /// <summary>
        /// Model json a serialize edilip string formatında verilir
        /// </summary>
        /// <param name="postData"></param>
        /// <returns>ApiResultModel</returns>
        public string GetResponseWithModel(string postData)
        {
            WebRequest request = WebRequest.Create(url) as HttpWebRequest;
            request.Method = metot;
            request.ContentType = "application/json";
            //request.Headers.Add("ApiUser", Environment.GetEnvironmentVariable("ApiUser"));
            //request.Headers.Add("ApiPassword", Environment.GetEnvironmentVariable("ApiPassword"));

            using (var streamwirter = new StreamWriter(request.GetRequestStream()))
            {
                streamwirter.Write(postData);
            }

            using (var response = request.GetResponse() as HttpWebResponse)
            {
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    var responseContent = reader.ReadToEnd();
                    return responseContent;
                }
            }
        }
    }
}
