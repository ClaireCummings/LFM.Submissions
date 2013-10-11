using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LFM.Submissions.LandRegistry.Contracts;
using NServiceBus;

namespace LFM.Submissions.LandRegistry
{
    public class GetEdrsSubmissionStatusHandler : IHandleMessages<GetEdrsSubmissionStatus>
    {
        public IBus Bus { get; set; }

        public void Handle(GetEdrsSubmissionStatus message)
        {
            Bus.Send();
        }
    }
}
