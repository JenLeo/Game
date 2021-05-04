using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using GameAPI.Controllers;
using Game.Models;

namespace GameClient
{
    class Program
    {
        static void Main(string[] args)
        {

            GetDraws().Wait();
        }
        private static async Task GetDraws()
        {
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri("http://localhost:33151/");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync("api/Game");

            if (response.IsSuccessStatusCode)
            {
                IEnumerable<draw> draws = await response.Content.ReadAsAsync<IEnumerable<draw>>();

                foreach (draw dw in draws)
                {
                    Console.WriteLine(dw.ToString());
                }
            }
            else
            {
                Console.WriteLine(response.StatusCode + " ReasonPhrase: " + response.ReasonPhrase);
            }
        }
    }
        }
 
