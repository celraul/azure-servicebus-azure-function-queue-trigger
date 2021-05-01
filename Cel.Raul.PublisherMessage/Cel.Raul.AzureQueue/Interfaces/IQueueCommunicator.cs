using Cel.Raul.AzureQueue.Messages;
using System.Threading.Tasks;

namespace Cel.Raul.AzureQueue.Interfaces
{
    public interface IQueueCommunicator
    {
        T Read<T>(string message);
        Task SendAsync<T>(T obj) where T : BaseQueueMessage;
    }
}
