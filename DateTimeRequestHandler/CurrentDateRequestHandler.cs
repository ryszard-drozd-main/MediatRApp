//Copyright © Ryszard Drozd 2020
using MediatR;
using MediatRApp.DateTimeRequest;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MediatRApp.DateTimeRequestHandler
{
    public class CurrentDateRequestHandler : IRequestHandler<CurrentDate, DateTime>
    {
        public Task<DateTime> Handle(CurrentDate request, CancellationToken cancellationToken)
        {
            return Task.FromResult(DateTime.UtcNow);
        }
    }
}
