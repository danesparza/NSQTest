using Newtonsoft.Json;
using NSQ.Library;
using NsqSharp;
using System;
using System.Text;

namespace NSQ.Consumer
{
    public class UserMessageHandler : IHandler
    {
        /// <summary>Handles a user message.</summary>
        public void HandleMessage(IMessage message)
        {
            //  Get the message body
            string msg = Encoding.UTF8.GetString(message.Body);

            //  Deserialize the user
            User deserializedUser = JsonConvert.DeserializeObject<User>(msg);

            //  Should we simulate a problem and trigger a requeue?
            Random rnd = new Random();
            var diceRoll = rnd.Next(1, 100);

            if (message.Attempts > 2) {
                Console.WriteLine("Done processing this message.  GET OUT.");
                return;
            }

            if (message.HasResponded) {
                Console.WriteLine("WAIT A SECOND -- we have already responded to this user!");
            }

            if (diceRoll > 90)
            {
                //  We're triggering a requeue and indicating a fake problem
                Console.WriteLine("Fake problem detected with {0}.  Requeuing", deserializedUser.Name);
                throw new ApplicationException("Problem with user " + deserializedUser.Name);
            }

            //  Indicate we found something:
            Console.WriteLine("Found user {0} - created on {1}", deserializedUser.Name, deserializedUser.Created);
        }

        /// <summary>
        /// Called when a message has exceeded the specified <see cref="Config.MaxAttempts"/>.
        /// </summary>
        /// <param name="message">The failed message.</param>
        public void LogFailedMessage(IMessage message)
        {
            // Log failed messages
        }
    }
}
