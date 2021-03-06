﻿using Api.Infrastructure;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Api.Domain
{
    public class DomainInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<RetrieveUserInteractor>());
            container.Register(Component.For<AddUserInteractor>());
            container.Register(Component.For<IRepository>().ImplementedBy<DapperRepository>());
            container.Register(Component.For<FindUserQuery>().ImplementedBy<FindUserQueryDapper>());
        }
    }
}