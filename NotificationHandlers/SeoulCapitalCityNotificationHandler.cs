//Copyright © Ryszard Drozd 2020
using MediatR;
using MediatRApp.Notifications;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MediatRApp.NotificationHandlers
{
    public class SeoulCapitalCityNotificationHandler : INotificationHandler<CapitalCityNotification>
    {
        public Task Handle(CapitalCityNotification notification, CancellationToken cancellationToken)
        {
            var timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Korea Standard Time");
            var dateTime = TimeZoneInfo.ConvertTime(DateTime.Now, timeZoneInfo);
            Console.WriteLine($"In Seoul: {dateTime}");
            return Task.CompletedTask;
        }
    }
}
