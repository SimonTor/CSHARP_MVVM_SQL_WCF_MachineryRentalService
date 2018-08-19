namespace Server.L1.Infrastructure.L1.CrossCuttingSchicht
{
    using Crosscutting.Logging;
    using Crosscutting.Logging.Contracts;
    using Ninject.Modules;
    class LoggingMapping : NinjectModule
    {
        public override void Load()
        {
            Bind<ILogger>().To<Logger>();
        }
    }
}
