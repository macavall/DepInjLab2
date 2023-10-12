using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Net.Http;
using System.Threading.Tasks;

internal class Program
{

    delegate string MyDelegate(string message);

    public static void TestMethod()
    {
        TestMethod();
    }


    private static void Main(string[] args)
    {
        MyDelegate mydelegate1 = delegate (string message)
        {
            _ = Task.Factory.StartNew(() =>
            {
                try
                {
                    TestMethod();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                
            });

            return $"The message is: {message}";
        };

        MyDelegate mydelegate2 = delegate (string message)
        {
            return $"The message is: {message}!!!";
        };


        Console.WriteLine(mydelegate1("test"));
        //var host = new HostBuilder()
        //.ConfigureFunctionsWorkerDefaults()
        //.ConfigureServices((s) =>
        //{
        //    s.AddSingleton<MyClass>(sp =>
        //    {
        //        return new MyClass();
        //    });
        //})
        //.Build();

        //host.Run();

        Console.ReadLine();
    }

    public class MyClass
    {
        public async Task<string> GetBingStatus()
        {
            using (var client = new HttpClient())
            {
                var requestMessage = new HttpRequestMessage()
                {
                    Method = HttpMethod.Get,
                    RequestUri = new System.Uri("https://www.bing.com"),
                };

                var result = await client.SendAsync(requestMessage);

                await Console.Out.WriteLineAsync(result.StatusCode.ToString());
            }

            return "good";
        }
    }
}

