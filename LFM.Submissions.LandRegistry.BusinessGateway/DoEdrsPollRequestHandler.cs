using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using LFM.Submissions.Landregistry.InternalMessages;
using LFM.Submissions.LandRegistry.BusinessGateway.EdrsPollRequestService;

using NServiceBus;

namespace LFM.Submissions.LandRegistry.BusinessGateway
{
    public class DoEdrsPollRequestHandler : IHandleMessages<DoEdrsPollRequest>
    {
        IBus Bus { get; set; }

        public void Handle(DoEdrsPollRequest message)
        {
            var request = new PollRequestType
            {
                ID = new Q1IdentifierType {MessageID = new MessageIDTextType {Value = message.MessageId}}
            };

            // create an instance of the client
            var client = new EDocumentRegistrationV1_0PollRequestServiceClient();

            // overwrite endpoint address 
            client.ChannelFactory.Endpoint.Address = new EndpointAddress(@"https://bgtest.landregistry.gov.uk/b2b/ECDRS_StubService/EDocumentRegistrationV1_0PollRequestWebService");

            // overwrite endpointBehavior attributes
            client.ChannelFactory.Credentials.ClientCertificate.SetCertificate(StoreLocation.CurrentUser, StoreName.My, X509FindType.FindBySerialNumber, "47 ce 29 6f");

            // create a Header Instance
            client.ChannelFactory.Endpoint.Behaviors.Add(new HMLRBGMessageEndpointBehavior(message.Username, message.Password));

            // submit the request
            var response = client.getResponse(request);
            

        }
    }
}
