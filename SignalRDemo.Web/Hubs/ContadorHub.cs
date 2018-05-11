using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace SignalRDemo.Web.Hubs
{
    [HubName("contador")]
    public class ContadorHub : Hub
    {
        static int _contador = 0;
        //public void Hello()
        //{
        //    Clients.All.hello();
        //}
        public void AumentarContador()
        {
            _contador++;
            Clients.All.onActualizarContador(new { contador = _contador });
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            _contador--;
            Clients.All.onActualizarContador(new { contador = _contador });
            return base.OnDisconnected(stopCalled);
        }
    }
}