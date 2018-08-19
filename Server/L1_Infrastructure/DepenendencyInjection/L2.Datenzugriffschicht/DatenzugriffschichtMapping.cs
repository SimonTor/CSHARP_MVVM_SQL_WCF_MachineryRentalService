using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.L1.Infrastructure.L2.Datenzugriffschicht
{
    using Server.L2.Mietmaterialdatenbankzugriffsschicht;
    using Server.L2.Mietmaterialdatenbankzugriffsschicht.Contracts;
    using Ninject.Modules;
    class DatenzugriffschichtMapping : NinjectModule
    {        
        public override void Load()
        {
            Bind<IKunden_Verwaltungsklasse>().To<Kunden_Verwaltungsklasse>();
            Bind<ILagerbestand_Verwaltungsklasse>().To<Lagerbestand_Verwaltungsklasse>();
            Bind<IMaschinenarten_Verwaltungsklasse>().To<Maschinenarten_Verwaltungsklasse>();
            Bind<IMaschinenkauf_Verwaltungsklasse>().To<Maschinenkauf_Verwaltungsklasse>();
            Bind<IVermitungs_Verwaltungsklasse>().To<Vermitungs_Verwaltungsklasse>();
        }
    }
}
