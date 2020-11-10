using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService
{
    class MessageFileRepository : IMessageRepository
    {
        public Task<int> InsertMessage(MessageInput input)
        {
            //TODO Implement InsertMessage
            return Task<int>.Factory.StartNew(() => 0);
        }
    }
}
