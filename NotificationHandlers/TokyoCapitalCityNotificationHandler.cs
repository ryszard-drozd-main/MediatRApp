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
    public class TokyoCapitalCityNotificationHandler : INotificationHandler<CapitalCityNotification>
    {
        private readonly IContainer _container;
        public TokyoCapitalCityNotificationHandler(IContainer container)
        {
            _container = container;
        }

        public Task Handle(CapitalCityNotification notification, CancellationToken cancellationToken)
        {
            var timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Tokyo Standard Time");
            var dateTime = TimeZoneInfo.ConvertTime(DateTime.Now, timeZoneInfo);
            var repo = _container.GetInstance<InMemoryRepository>();
            repo.TokyoMessage = $"In Tokyo: {dateTime}";
            // call callback request:
            var mediator = _container.GetInstance<Mediator>();
            mediator.Send(new TokyoCallback());
            return Task.CompletedTask;
        }
    }
}
