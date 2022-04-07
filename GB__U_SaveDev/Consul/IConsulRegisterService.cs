using Consul;

namespace GB__U_SaveDev.Consul
{
    public interface IConsulRegisterService
    {
    }

    public class ConsulRegisterService : IHostedService, IConsulRegisterService
    {
        private readonly IConsulClient _consulClient;

        public ConsulRegisterService(IConsulClient consulClient)
        {
            _consulClient = consulClient;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
