namespace Client.L1.DepenendencyInjection.CrossCuttingSchicht
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
