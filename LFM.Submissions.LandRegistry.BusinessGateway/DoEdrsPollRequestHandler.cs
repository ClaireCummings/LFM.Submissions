using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LFM.Submissions.Landregistry.InternalMessages;
using NServiceBus;

namespace LFM.Submissions.LandRegistry.BusinessGateway
{
    public class DoEdrsPollRequestHandler : IHandleMessages<DoEdrsPollRequest>
    {
        public void Handle(DoEdrsPollRequest message)
        {
            
        }
    }
}
