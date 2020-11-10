using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Net;

namespace MessageListener
{
    class Program
    {
        static void Main(string[] args)
        {
            _ListenForMessages();
        }

        private static void _ListenForMessages()
        {
            try
            {
                var server = new HttpListener();
                var url = ConfigurationManager.AppSettings["MessageListenerEndpopint"];
                server.Prefixes.Add(url);
                server.Start();

                Console.WriteLine("Listening for messages...");

                while (true)
                {
                    var context = server.GetContext();
                    var request = context.Request;

                    string text;
                    using (var reader = new StreamReader(request.InputStream, request.ContentEncoding))
                    {
                        text = reader.ReadToEnd();
                        Console.WriteLine(text);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                //TODO log exception
            }

        }
    }
}
