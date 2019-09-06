using System;
using EasyNetQ;
using TestRabbitMQ.Messages;

namespace TestRabbitMQ.Subscriber
{
    public class Program
    {
        static void Main(string[] args)
        {
            var connStr = "host=192.168.0.92;virtualHost=FXYHOST;username=admin;password=admin";

            using (var bus = RabbitHutch.CreateBus(connStr))
            {
                bus.Subscribe<TextMessage>("my_test_subscriptionid", HandleTextMessage);

                Console.WriteLine("Listening for messages. Hit <return> to quit.");
                Console.ReadLine();
            }
        }

        public static void HandleTextMessage(TextMessage textMessage)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Got message: {0}", textMessage.Text);
            Console.ResetColor();
        }
    }
}
