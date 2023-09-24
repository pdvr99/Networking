using MQTTnet;
using MQTTnet.Client;
using System;
using System.Threading.Tasks;

namespace MQTTSubscriber
{
    class Subscriber
    {
        static async Task Main(string[] args)
        {
            var mqttFactory = new MqttFactory();
            var client = mqttFactory.CreateMqttClient();
            var options = new MqttClientOptionsBuilder().WithClientId(Guid.NewGuid().ToString()).WithTcpServer("10.61.2.31", 1884).Build();

            var topicFilter = new MqttTopicFilterBuilder().WithTopic("test").Build();


            await client.SubscribeAsync(topicFilter); 

            await client.ConnectAsync(options);

            Console.ReadLine();

            await client.DisconnectAsync(); 
        }
    }
}
