using Consul;
using Domain.Core.Configuration;
using Microsoft.Extensions.Options;

namespace GB__U_SaveDev.Consul
{
    public interface IConsulRegisterService: IHostedService
    {
    }

    public class ConsulRegisterService :  IConsulRegisterService
    {
        private readonly IConsulClient _consulClient;
        private readonly MenuConfiguration _menuOptions;
        private readonly ConsulConfiguration _consulOptions;

        public ConsulRegisterService(IConsulClient consulClient,
            IOptions<MenuConfiguration> menuOptions,
            IOptions<ConsulConfiguration> consulOptions)
        {
            _consulClient = consulClient;
            _menuOptions = menuOptions.Value;
            _consulOptions = consulOptions.Value;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            var menuUri = new Uri(_menuOptions.Url);

            var serviceRegistration = new AgentServiceRegistration()
            {
                Address = menuUri.Host,
                Name = _menuOptions.ServiceName,
                Port = menuUri.Port,
                ID = _menuOptions.ServiceId,
                Tags = new[] { _menuOptions.ServiceName }
            };

            await _consulClient.Agent.ServiceDeregister(_menuOptions.ServiceId, cancellationToken);
            await _consulClient.Agent.ServiceRegister(serviceRegistration, cancellationToken);
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            await _consulClient.Agent.ServiceDeregister(_menuOptions.ServiceId, cancellationToken);
        }
    }
}
