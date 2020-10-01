//Copyright © Ryszard Drozd 2020
using MediatR;
using MediatRApp.Notifications;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MediatRApp.NotificationHandlers
{
    public class LondonCapitalCityNotificationHandler : INotificationHandler<CapitalCityNotification>
    {
        public Task Handle(CapitalCityNotification notification, CancellationToken cancellationToken)
        {
            var timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("GMT Standard Time");
            var dateTime = TimeZoneInfo.ConvertTime(DateTime.Now, timeZoneInfo);
            Console.WriteLine($"In London: {dateTime}");
            return Task.CompletedTask;
        }
    }
}
