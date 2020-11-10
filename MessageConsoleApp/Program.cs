using System;
using System.Configuration;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Web;
namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            _ReadMessages();
        }

        private static void _ReadMessages()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Enter your message (200 char max):");
                    var input = Console.ReadLine();
                    var url = ConfigurationManager.AppSettings["MessageServiceEndpopint"];
                    var client = new HttpClient();
                    input = HttpUtility.HtmlEncode(input);
                    var contentjson = new StringContent(string.Format("{{\"input\":\"{0}\"}}", input), UTF8Encoding.UTF8, "application/json");
                    var response = client.PostAsync(url, contentjson).Result;
                    response.EnsureSuccessStatusCode();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    //TODO log exception
                }
            }
        }
    }
}
