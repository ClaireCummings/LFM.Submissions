﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NServiceBus;

namespace LFM.Submissions.LandRegistry.Contracts
{
    public class GetEdrsSubmissionStatus : ICommand
    {
        public string MessageId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
