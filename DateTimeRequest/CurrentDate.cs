//Copyright © Ryszard Drozd 2020
using MediatR;
using System;

namespace MediatRApp.DateTimeRequest
{
    public class CurrentDate : IRequest<DateTime>
    {
    }
}
