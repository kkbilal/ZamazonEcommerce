using StackExchange.Redis;

namespace Zamazon.Basket.WebApi.Settings
{
    public class RedisService
    {
        private readonly string _host;
        private readonly int _port;
        private  ConnectionMultiplexer _connectionMultiplexer;
        public RedisService( string host,int port)
        {
            _port = port;
            _host = host;
        }
        public void connect() => _connectionMultiplexer = ConnectionMultiplexer.Connect($"{_host}:{_port}");
        public IDatabase GetDatabase(int db = 1) => _connectionMultiplexer.GetDatabase(0);

    }
}
