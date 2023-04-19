using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientUI
{
    public enum ChatUserEvent
    {
        UpdateFlights
    };
    public class ChatUserEventArgs : EventArgs
    {
        private readonly ChatUserEvent userEvent;
        private readonly Object data;

        public ChatUserEventArgs(ChatUserEvent userEvent, object data)
        {
            this.userEvent = userEvent;
            this.data = data;
        }

        public ChatUserEvent UserEventType
        {
            get { return userEvent; }
        }

        public object Data
        {
            get { return data; }
        }
    }
}
