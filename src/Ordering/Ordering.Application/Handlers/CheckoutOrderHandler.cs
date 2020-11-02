using AutoMapper;
using MediatR;
using Ordering.Application.Commands;
using Ordering.Application.Responses;
using Ordering.Core.Entities;
using Ordering.Core.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ordering.Application.Handlers
{
    public class CheckoutOrderHandler : IRequestHandler<CheckoutOrderCommand, OrderResponse>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public CheckoutOrderHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<OrderResponse> Handle(CheckoutOrderCommand request, CancellationToken cancellationToken)
        {
            var orderEntity = _mapper.Map<Order>(request);

            if (orderEntity == null)
                throw new ApplicationException("Order is not mapped");

            var order = await _orderRepository.AddAsync(orderEntity);

            return _mapper.Map<OrderResponse>(order);
        }
    }
}
