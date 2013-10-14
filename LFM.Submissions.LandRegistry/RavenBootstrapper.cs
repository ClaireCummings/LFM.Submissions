using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NServiceBus;
using NServiceBus.UnitOfWork;
using Raven.Client;
using Raven.Client.Document;

namespace LFM.Submissions.LandRegistry
{
    public class RavenBootstrapper : INeedInitialization
    {
        public void Init()
        {
            Configure.Instance.Configurer.ConfigureComponent<IDocumentStore>(
                () =>
                {
                    var store = new DocumentStore
                    {
                        Url = "http://localhost:8080"
                    };
                    store.Initialize();
                    store.JsonRequestFactory.DisableRequestCompression = true;
                    return store;
                }
                , DependencyLifecycle.SingleInstance);

            Configure.Instance.Configurer.ConfigureComponent<IDocumentSession>(
                () =>
                {
                    var session = Configure.Instance.Builder.Build<IDocumentStore>().OpenSession(
                        new OpenSessionOptions()
                        {
                            Database = "LFM.Submissions.LandRegistry"
                        });
                    return session;
                }
                    , DependencyLifecycle.InstancePerUnitOfWork);

            Configure.Instance.Configurer.ConfigureComponent<RavenUnitOfWork>(DependencyLifecycle.InstancePerUnitOfWork);
        }
    }

    public class RavenUnitOfWork : IManageUnitsOfWork
    {
        public IDocumentSession Session { get; set; }

        public void Begin()
        {

        }

        public void End(Exception ex = null)
        {
            if (ex == null)
                Session.SaveChanges();
        }

    }

}
