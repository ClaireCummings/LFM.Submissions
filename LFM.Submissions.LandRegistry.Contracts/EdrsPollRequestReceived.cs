using NServiceBus;

namespace LFM.Submissions.LandRegistry.Contracts
{
    public class EdrsPollRequestReceived : IEvent
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string MessageId { get; set; }
    }
}
