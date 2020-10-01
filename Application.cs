//Copyright © Ryszard Drozd 2020
using MediatR;
using MediatRApp.DateTimeRequest;
using MediatRApp.Notifications;
using MediatRApp.Services;
using StructureMap;
using System;

namespace MediatRApp
{
    public class Application
    {
        private Container _container;

        public int Run(string[] args)
        {
            Configure();
            RunApp(args);
            return 0;
        }

        private void RunApp(string[] args)
        {
            var mediator = _container.GetInstance<Mediator>();

            var currentDateResponse = mediator.Send(new CurrentDate());
            Console.WriteLine($"We have response! Current UTC: {currentDateResponse.Result}");

            mediator.Publish(new CapitalCityNotification());
        }

        private void Configure()
        {
            _container = new Container(cfg =>
            {
                cfg.Scan(scanner =>
                {
                    scanner.TheCallingAssembly();
                    scanner.ConnectImplementationsToTypesClosing(typeof(IRequestHandler<,>));
                    scanner.ConnectImplementationsToTypesClosing(typeof(INotificationHandler<>));
                });
                cfg.For<ServiceFactory>().Use<ServiceFactory>(ctx => ctx.GetInstance);
                cfg.For<IMediator>().Use<Mediator>();
                cfg.ForSingletonOf<InMemoryRepository>().Singleton();
            });
        }
    }
}
