using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.L1.Infrastructure.L4.Dienstschicht
{
    using Server.L4.Dienste;
    using Ninject.Modules;
    using Crosscutting.Dienste.Shared.Contracts;
    class Dienstschichtmapping : NinjectModule
    {
        public override void Load()
        {
            Bind<IMietservice>().To<Mietservice>();
        }
    }
}
