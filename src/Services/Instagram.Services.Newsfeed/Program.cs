using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Instagram.Common.Services;
using Instagram.Common.Events;

namespace Instagram.Services.Newsfeed
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ServiceHost.Create<Startup>(args)
                .UseRabbitMq()
                .SubscribeToEvent<UserCreated>()
                .SubscribeToEvent<UserFollowed>()
                .SubscribeToEvent<UsersNewPostsFetched>()
                .Build()
                .Run();
        }
    }
}
