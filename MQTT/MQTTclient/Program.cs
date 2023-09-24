using System;
using System.Text;
using UnityEngine;
using MQTTnet;
using MQTTnet.Client;
//using MQTTnet.Client.Options;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

public class MQTTClient : MonoBehaviour
{
    //MQTT broker settings
    private string brokerAddress = "SAMPLE";
    private int brokerPort = 1884;
    private string clientId = "UntiyCLient";
    private string topic = "SAMPLE";

    //MQTT client instance
    private IMqttClient mqttClient;
    private bool isConnected = false;

    private async Task ConnectAsync()
    {

        //Create a new MQTT client instance
        var factory = new MqttFactory();
        mqttClient = factory.CreateMqttClient();

        var options = new MqttClientOptionsBuilder()
            .WithTcpServer(brokerAddress, brokerPort)
            .WithClientId(clientId)
            .Build();

        try
        {
            await mqttClient.ConnectAsync(options, CancellationToken.None);
            isConnected = true; //Connection successful
            Debug.Log("Connected to MQTT broker."); 

        }
        catch(Exception ex)
        {

        }


    }


  
}


