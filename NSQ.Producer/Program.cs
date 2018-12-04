using NSQ.Library;
using System;

namespace NSQ.Producer
{
    class Program
    {
        static void Main(string[] args)
        {
            //  Create an API client
            var nsq = Refit.RestService.For<IQueueApi>("http://localhost:4151");

            //  Create users
            for (int i = 0; i < 10; i++)
            {
                var user = new User
                {
                    Id = i,
                    Created = DateTime.Now,
                    Name = "User " + i,
                    Description = "Description for " + i,
                };

                //  Send the user:
                var test = nsq.SendUserInformation(user, "Users").Result;
            }            
        }
    }
}
