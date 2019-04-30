using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using NemoStore.Core.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace NemoStore.Repository
{
    public class RepositoryModuleInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            //注册Repository
            container.Register(Component
                .For(typeof(IRepository<>))
                .ImplementedBy(typeof(Repository<>))
                .LifeStyle.Transient);
        }
    }
}
