using AutoMapper;
using NetCore.Application.DataContract.Request.Client;
using NetCore.Application.DataContract.Request.Orders;
using NetCore.Application.DataContract.Response.Orders;
using NetCore.Application.Interfaces;
using NetCore.Domain.Interfaces.Service;
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

    public async Task<Response> CreateAsync(CreateOrdersRequest ordersRequest)
    {
        var orderModel = _mapper.Map<OrdersModel>(ordersRequest);
        //return await _ordersService.CreateAsync(orderModel);
        throw new NotImplementedException();
    }

    public Task<Response<OrdersResponse>> GetByIdAsync(string orderId)
    {
        throw new NotImplementedException();
    }

    public async Task<Response<List<OrdersResponse>>> GetListByFilterAsync(string orderId = null, string clientId = null, string userId = null)
    {
        Response<List<OrdersModel>> orders = await _ordersService.GetListByFilterAsync(orderId, clientId, userId);

        if (orders.Reports.Any())
            return Response.Unprocessable<List<OrdersResponse>>(orders.Reports);

        var response = _mapper.Map<List<OrdersResponse>>(orders.Data);

        return Response.Ok(response);
    }

   
}