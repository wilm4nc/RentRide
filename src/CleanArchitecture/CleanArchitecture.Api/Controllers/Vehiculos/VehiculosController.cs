
using System.Net;
using CleanArchitecture.Application.Vehiculos.GetVehiculosByPagination;
using CleanArchitecture.Application.Vehiculos.GetVehiculosKitByPagination;
using CleanArchitecture.Application.Vehiculos.SearchVehiculos;
using CleanArchitecture.Domain.Abstractions;
using CleanArchitecture.Domain.Permissions;
using CleanArchitecture.Domain.Vehiculos;
using CleanArchitecture.Infrastructure.Authentication;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Api.Controllers.Vehiculos;

[ApiController]
[Route("api/vehiculos")]
public class VehiculosController : ControllerBase
{

    private readonly ISender _sender;

    public VehiculosController(ISender sender)
    {
        _sender = sender;
    }

    [HasPermission(PermissionEnum.ReadUser)]
    [HttpGet("search")]
    public async Task<IActionResult> SearchVehiculos(
        DateOnly startDate,
        DateOnly endDate,
        CancellationToken cancellationToken
    )
    {
        var query = new SearchVehiculosQuery(startDate, endDate);
        var resultados = await _sender.Send(query, cancellationToken);
        return Ok(resultados.Value);
    }

    [AllowAnonymous]
    [HttpGet("getPagination", Name = "PaginationVehiculos")]
    [ProducesResponseType(typeof(PaginationResult<Vehiculo, VehiculoId>),
    (int)HttpStatusCode.OK)]
    public async Task<ActionResult<PaginationResult<Vehiculo, VehiculoId>>>
    GetPaginationVehiculo(
        [FromQuery] GetVehiculosByPaginationQuery request
    ){

        var Resultados = await _sender.Send(request);
        return Ok(Resultados);
    }

    [AllowAnonymous]
    [HttpGet("getPaginationKit", Name = "PaginationVehiculosKit")]
    [ProducesResponseType(typeof (PagedResults<Vehiculo, VehiculoId>),
    (int)HttpStatusCode.OK)]
    public async Task<ActionResult<PagedResults<Vehiculo, VehiculoId>>>
    GetPaginationVehiculoKit(
        [FromQuery] GetVehiculosKitByPaginationQuery request
    )
    {
        var Resultados = await _sender.Send(request);
        return Ok(Resultados);
    }


}