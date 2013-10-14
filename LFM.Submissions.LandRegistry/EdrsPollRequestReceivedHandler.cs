using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LFM.Submissions.LandRegistry.Contracts;
using LFM.Submissions.Landregistry.InternalMessages;
using NServiceBus;

namespace LFM.Submissions.LandRegistry
{
    public class EdrsPollRequestReceivedHandler : IHandleMessages<EdrsPollRequestReceived>
    {
        public IBus Bus { get; set; }

        public void Handle(EdrsPollRequestReceived message)
        {
            Console.WriteLine("EdrsPollRequestReceived " + message.MessageId + " recieved.");
            Bus.Send(new DoEdrsPollRequest()
                {
                    MessageId = message.MessageId,
                    Username = message.Username,
                    Password = message.Password
                });
        }
    }
}
