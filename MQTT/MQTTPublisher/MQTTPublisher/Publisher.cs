using MQTTnet;
using MQTTnet.Client; 
using System;
using System.Threading.Tasks;

namespace MQTTPublisher
{
    class Publisher
    {
        static async Task Main(string[] args)
        {
            var mqttFactory = new MqttFactory();
            var client = mqttFactory.CreateMqttClient();
            var options = new MqttClientOptionsBuilder().WithClientId(Guid.NewGuid().ToString()).WithTcpServer("10.61.2.31", 1884).Build();



            await client.ConnectAsync(options);

            Console.WriteLine("Please press a key to publish a message");

            Console.ReadLine();

            await PublicMessageAsync(client);

            await client.DisconnectAsync();

            Console.WriteLine("MQTT application message is published"); 




        }


        private static async Task PublicMessageAsync(IMqttClient client)
        {
            String messagePayload = "Hello!";

            var message = new MqttApplicationMessageBuilder().WithTopic("test").WithPayload(messagePayload).Build();

            if(client.IsConnected)
            {
                await client.PublishAsync(message); 
            }

        }
    }
}
