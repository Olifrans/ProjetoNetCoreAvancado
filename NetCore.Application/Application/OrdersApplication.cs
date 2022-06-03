using AutoMapper;
using NetCore.Application.DataContract.Request.Client;
using NetCore.Application.DataContract.Request.Orders;
using NetCore.Application.Interfaces;
using NetCore.Domain.Interfaces.Services;
using NetCore.Domain.Models;
using NetCore.Domain.Validations.Base;

namespace NetCore.Application.Application;

public class OrdersApplication : IOrdersApplication
{
    private readonly IOrdersService _ordersService;
    private readonly IMapper _mapper;

    public OrdersApplication(IOrdersService ordersService, IMapper mapper)
    {
        this._ordersService = ordersService;
        this._mapper = mapper;
    }

    public async Task<Response> CreateAsync(CreateOrdersRequest orderRequest)
    {
        var orderModel = _mapper.Map<OrdersModel>(orderRequest);
        return await _ordersService.CreateAsync(orderModel);
    }
}