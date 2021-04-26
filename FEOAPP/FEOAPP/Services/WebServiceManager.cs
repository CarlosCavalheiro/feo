using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace FEOAPP.Services
{
    public abstract class WebServiceManager
    {
        public async System.Threading.Tasks.Task<HttpResponseMessage> ConsumirAPIAsync(string url,
                                    PostType tipo,
                                    string json = null,
                                    string token = null)
        {
            HttpResponseMessage retorno = null;

            using (HttpClient hc = new HttpClient())
            {
                hc.BaseAddress = new System.Uri(url);
                if (!string.IsNullOrWhiteSpace(token))
                    hc.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                StringContent content;

                switch (tipo)
                {
                    case PostType.GET:
                        retorno = await hc.GetAsync("");
                        break;

                    case PostType.POST:
                        content = new StringContent(json.ToString(), Encoding.UTF8, "application/json");
                        retorno = await hc.PostAsync("", content);
                        break;
                    case PostType.PUT:
                        content = new StringContent(json.ToString(), Encoding.UTF8, "application/json");
                        retorno = await hc.PutAsync("", content);
                        break;
                    case PostType.DELETE:
                        retorno = await hc.DeleteAsync("");
                        break;

                }

            }

            return retorno;

        }

        public enum PostType
        {
            GET = 1,
            POST = 2,
            PUT = 3,
            DELETE = 4
        }
    }
}
