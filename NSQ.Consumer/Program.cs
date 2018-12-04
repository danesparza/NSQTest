using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NsqSharp;

namespace NSQ.Consumer
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new Consumer for each topic/channel
            var consumer = new NsqSharp.Consumer("Users", "processor");
            consumer.AddHandler(new UserMessageHandler());
            consumer.ConnectToNsqLookupd("localhost:4161");

            Console.WriteLine("Listening for messages. If this is the first execution, it " +
                              "could take up to 60s for topic producers to be discovered.");
            Console.WriteLine("Press enter to stop...");
            Console.ReadLine();

            consumer.Stop();
        }
    }
}
