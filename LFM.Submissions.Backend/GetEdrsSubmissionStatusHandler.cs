using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LFM.Submissions.Backend;
using LFM.Submissions.LandRegistry.Contracts;
using NServiceBus;
using NServiceBus.Unicast;
using Raven.Client;

namespace LFM.Submissions.Backend
{
    public class GetEdrsSubmissionStatusHandler : IHandleMessages<GetEdrsSubmissionStatus>
    {
        public IDocumentSession Session { get; set; }
        public IBus Bus { get; set; }

        public void Handle(GetEdrsSubmissionStatus message)
        {
            Console.WriteLine("GetEdrsSubmissionStatus " + message.MessageId + " recieved.");

            Session.Store(new eDrsPollRequest()
                {
                    MessageId = message.MessageId
                });
            Console.WriteLine("Publishing event for " + message.MessageId);
            Bus.Publish(new EdrsPollRequestReceived()
                {
                    MessageId = message.MessageId,
                    Username = message.Username,
                    Password = message.Password
                });
        }
    }
}
