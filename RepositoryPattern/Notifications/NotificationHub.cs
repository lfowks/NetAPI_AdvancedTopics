

using Microsoft.AspNetCore.SignalR;

namespace RepositoryPattern.Notifications
{
    public interface IMessageHubClient : IHubContext , IClientProxy
    {
        Task JoinGroup(string companyName);
        Task SendMessageToClients(string message);
        Task SendToAll(string message);
        Task SendMessage(string message);
        Task SendMessageToGroup(string message);
    }

    public class NotificationHub : Hub //IMessageHubClient
    {
        public async Task JoinGroup(string companyName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, "MyChannel");
        }
        //public async Task SendMessageToClients(string message)
        //{
        //    await Clients.All.SendMessageToClients(message);
        //}
        
        //public async Task SendMessage(string message)
        //{
        //    await Clients.All.SendMessage(message);
        //}

        //public async Task SendMessageToGroup(string message)
        //{
        //    await Clients.Group("Test").SendMessageToGroup(message);
        //}

        public async Task SendToAll(string message)
        {
            try
            {
                await Clients.All.SendAsync("SendToAll", message);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

    }
}
