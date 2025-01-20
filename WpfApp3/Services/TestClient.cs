using Microsoft.AspNetCore.Http.Connections;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MyUserManagementApp.Services
{
    public class TestClient
    {
        private HubConnection _connection;
        private string _urlAddress;

        public TestClient()
        {
            _urlAddress = $"http://106.15.61.202:6001";
        }

        public async Task InitHubConnectionAsync()
        {
            if (_connection != null)
                return;

            var builder = new HubConnectionBuilder()
                .AddJsonProtocol(t =>
                {
                    t.PayloadSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                    //t.PayloadSerializerOptions.Converters.Add(new DateTimeConverter());
                })
                .WithUrl($"{_urlAddress}/MonitorHub", options =>
                {
                    options.Transports = HttpTransportType.WebSockets;
                })
                .WithAutomaticReconnect();

            _connection = builder.Build();

            //监控状态变化
            _connection.On<bool>("MonitoringStatusChanged",
                (isMonitoring) =>
                {

                });

            await _connection.StartAsync();
        }
    }
}
