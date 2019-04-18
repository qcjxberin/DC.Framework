using System.Threading.Tasks;

namespace DCLGB.SignalR
{
    public interface ISignalRChatService
    {
        Task SendMessageAsync(string message);
    }
}
