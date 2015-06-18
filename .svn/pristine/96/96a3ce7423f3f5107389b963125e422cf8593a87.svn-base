using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace ICM.Message.Observer
{
    public class MyQueueMessage
    {
        private static MessageQueue _message;

        private MyQueueMessage() { }


        public static MessageQueue MakeMessageQueueInstance()
        {
            if (_message != null) return _message;
       
            _message = MessageQueue.Exists(@".\Private$\MyQueue") ? new MessageQueue(@".\Private$\MyQueue") : MessageQueue.Create(@".\Private$\MyQueue");


            return _message;
        }
    }
}
