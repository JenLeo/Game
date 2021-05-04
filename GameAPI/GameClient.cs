using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace GameAPI
{
    public class GameClient
    {
        static async Task RunAsync()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:33151");                     

                    // add an Accept header 
                    client.DefaultRequestHeaders.
                            Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));         

                    HttpResponseMessage response = await client.GetAsync("api");

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        //static void Main()
        //{
        //    Task result = RunAsync();               
        //    result.Wait();                         
        //}
    }
}
           

