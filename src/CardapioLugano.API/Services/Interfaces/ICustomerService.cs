using CardapioLugano.Shared.Requests;
using CardapioLugano.Modelos.Models;

namespace CardapioLugano.API.Services.Interfaces;

public interface ICustomerService
{
    Task<Customer> CreateAsync(CustomerRequest request);
}
