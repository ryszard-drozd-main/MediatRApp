//Copyright © Ryszard Drozd 2020
using MediatR;
using MediatRApp.CallbackRequest;
using MediatRApp.Services;
using StructureMap;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MediatRApp.CallbackRequestHandler
{
    public class HavanaCallbackRequestHandler : IRequestHandler<HavanaCallback>
    {
        private readonly IContainer _container;
        public HavanaCallbackRequestHandler(IContainer container)
        {
            _container = container;
        }
        public Task<Unit> Handle(HavanaCallback request, CancellationToken cancellationToken)
        {
            var repo = _container.GetInstance<InMemoryRepository>();
            Console.WriteLine(repo.HavanaMessage);
            return Task.FromResult(Unit.Value);
        }
    }
}
