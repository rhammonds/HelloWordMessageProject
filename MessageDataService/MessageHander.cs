using System.Threading.Tasks;

namespace DataService
{
    public class MessageHander
    {
        public async Task<int> InsertMessage(MessageInput messageInput, MessageRepositoryType messageRepositoryType)
        {
            try
            {
                if (messageInput == null || string.IsNullOrEmpty(messageInput.input) || (messageInput.input.Length > 200))
                {
                    return -1;
                }
                if (messageRepositoryType.HasFlag(MessageRepositoryType.Console))
                {
                    new MessageConsoleRepository().InsertMessage(messageInput);
                }
                if (messageRepositoryType.HasFlag(MessageRepositoryType.Database))
                {
                    new MessageDbRepository().InsertMessage(messageInput);
                }
                if (messageRepositoryType.HasFlag(MessageRepositoryType.File))
                {
                    new MessageFileRepository().InsertMessage(messageInput);
                }
                Task.WaitAll();
                return 0;
            }
            catch (System.Exception ex)
            {
                return -1;
            }

        }
    }
}
