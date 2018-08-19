using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.L1.Infrastructure.L3.Logikschicht
{
    using Server.L3.Logikschicht;
    using Server.L3.Logikschicht.Contracts;
    using Ninject.Modules;
    class Logikschichtmapping : NinjectModule
    {
        public override void Load()
        {
            Bind<IMietmanager>().To<Mietmanager>();
        }
    }
}
