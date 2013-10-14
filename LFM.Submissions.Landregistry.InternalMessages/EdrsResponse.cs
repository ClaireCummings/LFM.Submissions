using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NServiceBus;

namespace LFM.Submissions.Landregistry.InternalMessages
{
    public class EdrsResponse : IMessage
    {
        public string MessageId { get; set; }
        public object Response { get; set; }
    }
}
