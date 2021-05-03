using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Game.Models;

namespace GameAPI
{
    public class Program
    {
        static void Main(string[] args)
        {
            
            PostADraw().Wait();
            UpdateADraw().Wait();
            DeleteADraw().Wait();
          
        }

        private static async Task UpdateADraw()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:33151/");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.PutAsJsonAsync("api/Game/5", "MillionPlus");

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Draw Updated!");
            }
            else
            {
                Console.WriteLine(response.StatusCode + " Reason Phrase: " + response.ReasonPhrase);

            }
        }

        private static async Task DeleteADraw()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:33151/");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.DeleteAsync("api/Game/5");

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Draw deleted!");
            }
            else
            {
                Console.WriteLine(response.StatusCode + " Reason Phrase: " + response.ReasonPhrase);

            }
        }


        private static async Task PostADraw()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:33151/");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            draw newDraw = new draw() { DrawID = "DS99", DrawName = "EuroDraw" };
            HttpResponseMessage response = await client.PostAsJsonAsync("api/Game", newDraw);

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Draw added!");
            }
            else
            {
                Console.WriteLine(response.StatusCode + " Reason Phrase: " + response.ReasonPhrase);

            }
        }

       

        //private static async Task GetAllDraws()
        //{
        //    HttpClient client = new HttpClient();
        //    client.BaseAddress = new Uri("http://localhost:33151/");
        //    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

        //    HttpResponseMessage response = await client.GetAsync("api/draw");

        //    if (response.IsSuccessStatusCode)
        //    {
        //        IEnumerable<draw> draws = await response.Content.ReadAsAsync<IEnumerable<draw>>();

        //        foreach (draw dw in draws)
        //        {
        //            Console.WriteLine(dw);
        //        }
        //    }
        //    else
        //    {
        //        Console.WriteLine(response.StatusCode + " Reason Phrase: " + response.ReasonPhrase);
        //    }
        //}
    }
}
    
