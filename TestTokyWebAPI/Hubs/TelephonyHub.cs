using Microsoft.AspNetCore.SignalR;

namespace TestTokyWebAPI.Hubs
{
    public class TelephonyHub:Hub
    {
        private string UserId;
        private string ConnectionId;

        /// <summary>
        /// Se mandará a llamanar cuando un agente se conecta al hub
        /// Para asi saber que esta conectado
        /// </summary>
        /// <returns></returns>
        public override Task OnConnectedAsync()
        {
            UserId =this.Context.UserIdentifier;
            ConnectionId = this.Context.ConnectionId;
            return base.OnConnectedAsync();
        }




        /// <summary>
        /// Se mandará a llamanar cuando un agente se desconecta del hub
        /// Para asi saber que esta desconectado y dejar de mandarle mensajes o
        /// leads
        /// </summary>
        public override Task OnDisconnectedAsync(Exception? exception)
        {
            return base.OnDisconnectedAsync(exception);
        }

        public Task NotifyToAll(string phoneNumber)
        {
            //mandale a este Cliente "ConnectionId" este mensaje y dicho cliente lo 
            //va a recibir en el metodo llamado "CallLead"
            //return Clients.Client(ConnectionId).SendAsync("CallLead", phoneNumber);

            //return Clients.AllExcept(ConnectionId).SendAsync("CallLead", phoneNumber);//asi se lo envias a todos excepto al ConnectionId

            return Clients.All.SendAsync("CallLeadOnFront", phoneNumber);//asi se lo envias a todos los que estan conectados al Hub
        }
    }
}
