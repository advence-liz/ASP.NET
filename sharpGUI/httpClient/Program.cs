using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace httpClient
{

    //// Create an HttpClient instance  
    //HttpClient client = new HttpClient();

    //// Send a request asynchronously continue when complete  
    //client.GetAsync(_address).ContinueWith(
    //            (requestTask) =>
    //            {
    //                // Get HTTP response from completed task.  
    //                HttpResponseMessage response = requestTask.Result;

    //// Check that response was successful or throw exception  
    //response.EnsureSuccessStatusCode();
    //                Console.WriteLine("GetAsync");
    //                // Read response asynchronously as JsonValue and write out top facts for each country  
    //                response.Content.ReadAsStringAsync().ContinueWith(
    //                    (readTask) =>
    //                    {
    //                        Console.WriteLine("ReadAsAsync");
                           
    //                    });
    //            });
    class Program
    {
        static string _address = "http://www.cnblogs.com";

        static void Main(string[] args)
        {

    

            //Console.WriteLine("Hit ENTER to exit...");
            var requestJson = JsonConvert.SerializeObject(new { startId = 1, itemcount = 3 });
            Uri serviceReq = new Uri("http://localhost/api/values/post");
            HttpClient client = new HttpClient();
            HttpContent content = new StringContent(requestJson);
         
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            // Send a request asynchronously continue when complete 
            client.PostAsync(serviceReq, content).ContinueWith(
                    (requestTask) =>
                    {
                    // Get HTTP response from completed task. 
                    HttpResponseMessage response = requestTask.Result;

                    // Check that response was successful or throw exception 
                    response.EnsureSuccessStatusCode();

                    // Read response asynchronously as JsonValue and write out top facts for each country 
                    response.Content.ReadAsStringAsync().ContinueWith(
                            (readTask) =>
                            {
                                Console.WriteLine(readTask.Result);

                            });
                    });
            Console.ReadLine();
        }
    }
    
}
