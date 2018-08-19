using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Server.L1.Infrastructure.L1.CrossCuttingSchicht;
using Server.L1.Infrastructure.L2.Datenzugriffschicht;
using Server.L1.Infrastructure.L3.Logikschicht;
using Server.L1.Infrastructure.L4.Dienstschicht;

namespace Server.L1.Infrastructure
{
    public static class MappingAgregations
    {
        public static INinjectModule[] Mappings
        {
            get
            {
                return new INinjectModule[]{
                    new LoggingMapping(),
                    new DatenzugriffschichtMapping(),
                    new Logikschichtmapping(),
                    new Dienstschichtmapping()
                };
            }
        }
    }
}
