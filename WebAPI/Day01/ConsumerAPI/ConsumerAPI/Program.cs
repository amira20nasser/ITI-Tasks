using System.Text;
using System.Text.Json;

namespace ConsumerAPI
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            HttpClient client = new HttpClient();
           await client.GetAsync("https://localhost:7162/api/Course").ContinueWith(response =>
            {
                if (response.IsCompletedSuccessfully)
                {
                    var result = response.Result.Content.ReadAsStringAsync().Result;
                    Console.WriteLine($"Response from API: {result}");
                }
                else
                {
                    Console.WriteLine($"Error calling API: {response.Exception?.Message}");
                }
            });
            // string to Json object
            var data = new
            {
                name = "course 222",
                description = "course description 222",
                duration=1,
            };

            var jsonContent = new StringContent(JsonSerializer.Serialize(data),
            Encoding.UTF8,
            "application/json"
            ); 
            await client.PostAsync("https://localhost:7162/api/Course", jsonContent).ContinueWith(response =>
            {
                if (response.IsCompletedSuccessfully)
                {
                    var result = response.Result.Content.ReadAsStringAsync().Result;
                    Console.WriteLine($"Response from API: {result}");
                }
                else
                {
                    Console.WriteLine($"Error calling API: {response.Exception?.Message}");
                }
            });
        }
    }
}
