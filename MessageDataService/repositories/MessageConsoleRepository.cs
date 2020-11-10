using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DataService
{
    class MessageConsoleRepository: IMessageRepository
    {
        public async Task<int> InsertMessage(MessageInput input)
        {
            try
            {
                var url = "https://localhost:44330/api/Values/";
                var client = new HttpClient();
                var contentjson = new StringContent(input.input, UTF8Encoding.UTF8, "application/json");
                var response = await client.PostAsync(url, contentjson);
                response.EnsureSuccessStatusCode();
                return 0;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
    }
     
}
