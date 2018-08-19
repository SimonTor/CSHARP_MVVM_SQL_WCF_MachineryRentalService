using System;
namespace Crosscutting.Logging.Contracts
{
    public interface ILogger
    {
        void Write(string message);
    }
}
