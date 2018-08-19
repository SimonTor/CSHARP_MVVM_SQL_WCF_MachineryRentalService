using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Activation;
using System.Web;
using Server.L1.Infrastructure;
using Ninject;
using Crosscutting.Dienste.Shared.Contracts;
using Server.L4.Dienste;

namespace Server.L5.Dienstserver
{
    public class WcfNinjectBaumaschinenmietServiceHostFactory : ServiceHostFactory
    {
        private static readonly WcfNinjectBaumaschinenmietServiceProxyFactory
             ServiceProxyFactory = new WcfNinjectBaumaschinenmietServiceProxyFactory();
        protected override System.ServiceModel.ServiceHost
                  CreateServiceHost(Type serviceType, Uri[] baseAddresses)
        {
            Mietservice test = KernelHelper.Get<Mietservice>();
            Type serviceProxyType = ServiceProxyFactory.GetProxyType(
            //serviceType, () => new StandardKernel(MappingAgregations.Mappings));

            serviceType, () => test);
            
            return base.CreateServiceHost(serviceProxyType, baseAddresses);
        }
    }

    public static class KernelHelper
    {
        public static StandardKernel Kernel { get; private set; }

        static KernelHelper()
        {
            Kernel = new StandardKernel(MappingAgregations.Mappings);
        }

        public static T Get<T>()
        {
            return Kernel.Get<T>();
        }
    }
}