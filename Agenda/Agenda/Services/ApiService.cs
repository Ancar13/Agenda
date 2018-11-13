using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Agenda.Common.Models;
using Newtonsoft.Json;

namespace Agenda.Services
{
    class ApiService
    {
        public async Task<Response> GetList<T>(string urlBase, string prefix, string controller)
        {

            try
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri(urlBase);
                var url = $"{prefix}{controller}";
                var response = await client.GetAsync(url);
                var answey = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = answey
                    };
                }
                var lista = JsonConvert.DeserializeObject<List<T>>(answey);
                return new Response
                {
                    IsSuccess = true,
                    Result = lista
                };
            }
            catch (Exception e)
            {

                return new Response()
                {
                    IsSuccess = false,
                    Message = e.Message,


                };
            }

        } 
    }
}
