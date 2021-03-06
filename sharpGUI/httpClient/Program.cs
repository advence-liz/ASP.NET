﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Threading;

namespace httpClient
{
    //using LT = LevelOne.LevelTwo;
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
        static string _address = "https://10.2.165.40:10701/CoreBase/Login/Index?status=2";

        static void Main(string[] args)
        {

    

            Console.WriteLine("pre start send request..."+ Thread.CurrentThread.ManagedThreadId);
            HttpClient client = new HttpClient();

            // Send a request asynchronously continue when complete  
            client.GetAsync(_address).ContinueWith(
                        (requestTask) =>
                        {
                            // Get HTTP response from completed task.  
                            HttpResponseMessage response = requestTask.Result;

                            // Check that response was successful or throw exception  
                            response.EnsureSuccessStatusCode();
                            Console.WriteLine("GetAsync");
                            // Read response asynchronously as JsonValue and write out top facts for each country  
                            response.Content.ReadAsStringAsync().ContinueWith(
                                (readTask) =>
                                {
                                    Console.WriteLine("ReadAsAsync");

                                });
                        });
            Console.WriteLine("over" + Thread.CurrentThread.ManagedThreadId);
            Console.ReadLine();
        }
    }
    
}


//var requestJson = JsonConvert.SerializeObject(new { startId = 1, itemcount = 3 });
//Uri serviceReq = new Uri("https://10.2.165.40:10701/CoreBase/Login/Index?status=2");
//HttpClient client = new HttpClient();
//HttpContent content = new StringContent(requestJson);

//content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

//// Send a request asynchronously continue when complete 
////ContinueWith 方法在新的线程中进行，但是拥有原来的上下文
//client.PostAsync(serviceReq, content).ContinueWith(
//                    (requestTask) =>
//                    {
//                    // Get HTTP response from completed task. 
//                    HttpResponseMessage response = requestTask.Result;

//// Check that response was successful or throw exception 
//response.EnsureSuccessStatusCode();
//                        Console.WriteLine("in another thread id" + serviceReq + Thread.CurrentThread.ManagedThreadId);
//                        // Read response asynchronously as JsonValue and write out top facts for each country 
//                        response.Content.ReadAsStringAsync().ContinueWith(
//                            (readTask) =>
//                            {
//                                Console.WriteLine(readTask.Result);
//                                Console.WriteLine("in another thread id"+serviceReq + Thread.CurrentThread.ManagedThreadId);

//                            });
//                    });