using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LFM.Submissions.Landregistry.InternalMessages;
using NServiceBus;
using Raven.Client;

namespace LFM.Submissions.LandRegistry
{
    public class EdrsResponseHandler : IHandleMessages<EdrsResponse>
    {
        IDocumentSession Session { get; set; }

        public void Handle(EdrsResponse message)
        {
            Console.WriteLine("Response Recieved " + message.MessageId);
            
            //Session.Store(message.Response);
        }
    }
}
