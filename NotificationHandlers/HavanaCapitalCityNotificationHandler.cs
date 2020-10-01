//Copyright © Ryszard Drozd 2020
using MediatR;
using MediatRApp.Notifications;
using MediatRApp.Services;
using System;
using System.Threading;
using System.Threading.Tasks;
using StructureMap;
using MediatRApp.CallbackRequest;

namespace MediatRApp.NotificationHandlers
{
    public class HavanaCapitalCityNotificationHandler : INotificationHandler<CapitalCityNotification>
    {
        private readonly IContainer _container;
        public HavanaCapitalCityNotificationHandler(IContainer container)
        {
            _container = container;
        }

        public Task Handle(CapitalCityNotification notification, CancellationToken cancellationToken)
        {
            var timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Cuba Standard Time");
            var dateTime = TimeZoneInfo.ConvertTime(DateTime.Now, timeZoneInfo);
            var repo = _container.GetInstance<InMemoryRepository>();
            repo.HavanaMessage = $"In Havana: {dateTime}";
            // call callback request:
            var mediator = _container.GetInstance<Mediator>();
            mediator.Send(new HavanaCallback());
            return Task.CompletedTask;
        }
    }
}
