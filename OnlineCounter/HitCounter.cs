using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace OnlineCounter
{
    public class HitCounter : Hub
    {
        private static int clientCounter = 0;
        public void Send()
        {
            string message = "";
            if (clientCounter < 2)
                message = string.Format("Atualmente existem {0} usuários online.", clientCounter);
            else
                message = string.Format("Atualmente {0} usuários estão online.", clientCounter);

        }

        /// <summary>
        /// registra usuário online
        /// </summary>
        /// <returns></returns>
        public override System.Threading.Tasks.Task OnConnected()
        {
            clientCounter++;
            return base.OnConnected();
        }

        /// <summary>
        /// desregistra usuário online
        /// </summary>
        /// <returns></returns>
        public override System.Threading.Tasks.Task OnDisconnected()
        {
            clientCounter--;
            return base.OnDisconnected();
        }
    }
}