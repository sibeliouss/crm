using Application.Features.Customers.Commands.Create;
using Application.Features.Customers.Commands.Delete;
using Application.Features.Customers.Commands.Update;
using Application.Features.Customers.Queries;
using Domain.Pages;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WMVC.Controllers;

public class CustomersController : Controller
{
    private readonly IMediator _mediator;

    public CustomersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // GET
    public async Task<IActionResult> Index(
        [FromQuery] string? name,
        [FromQuery] int pageSize = 10,
        [FromQuery] int pageNumber = 1)
    {
        var pageSizeLimit = 1000;

        if (pageSize > pageSizeLimit)
        {
            throw new ArgumentException(
                $"PageSize exceeds the page size limit: {pageSizeLimit}", nameof(pageSize));
        }

        var query = new ListCustomerQuery
        {
            Name = name,
            PageSize = pageSize,
            PageNumber = pageNumber
        };

        var customers = await _mediator.Send(query);

        Response.AddPagingHeaders(customers.Metadata);

        return View(customers);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateCustomer(CreateCustomerCommand model)
    {
        await _mediator.Send(model);
        return RedirectToAction("Index", "Customers");
    }

    [HttpGet]
    public async Task<IActionResult> Update(Guid customerId)
    {
        var customer = await _mediator.Send(new GetCustomerQuery { CustomerId = customerId });
        if (customer == null)
        {
            return NotFound();
        }

        var model = new UpdateCustomerCommand
        {
            CustomerId = customer.Id,
            Name = customer.Name,
            Email = customer.Email,
            Phone = customer.Phone,
            Address = customer.Address
        };
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Update(UpdateCustomerCommand model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        await _mediator.Send(model);
        return RedirectToAction("Index");
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteCustomer(Guid customerId)
    {
        var customer = await _mediator.Send(new GetCustomerQuery { CustomerId = customerId });

        if (customer is null)
        {
            return NotFound();
        }

        await _mediator.Send(new DeleteCustomerCommand { CustomerId = customerId });

        return NoContent();
    }
}
