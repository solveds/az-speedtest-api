using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.EventHubs;
using Newtonsoft.Json;
using SpeedTestApi.Models;

namespace SpeedTestApi.Services
{
    public class SpeedTestEvents : ISpeedTestEvents, IDisposable
    {
        private readonly EventHubClient _client;

        public SpeedTestEvents(string connectionString, string entityPath)
        {
            var connectionStringBuilder = new EventHubsConnectionStringBuilder(connectionString)
            {
                EntityPath = entityPath
            };

            _client = EventHubClient.CreateFromConnectionString(connectionStringBuilder.ToString());
        }

        public async Task PublishSpeedTest(TestResult speedTest)
        {
            var message = JsonConvert.SerializeObject(speedTest);
            var data = new EventData(Encoding.UTF8.GetBytes(message));

            await _client.SendAsync(data);
        }

        public void Dispose()
        {
            _client.CloseAsync();
        }
    }
}