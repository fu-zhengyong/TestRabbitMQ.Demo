using System;
using EasyNetQ;
using TestRabbitMQ.Messages;

namespace TestRabbitMQ.Publisher
{
    public class Program
    {
        static void Main(string[] args)
        {
            var connStr = "host=192.168.0.92;virtualHost=FXYHOST;username=admin;password=admin";

            using (var bus = RabbitHutch.CreateBus(connStr))
            {
                var input = "";
                Console.WriteLine("Please enter a message. 'Quit' to quit.");
                while ((input = Console.ReadLine()) != "Quit")
                {
                    bus.Publish(new TextMessage
                    {
                        Text = input
                    });
                }
            }
        }
    }
}
