using CardapioLugano.Shared.Requests;
using CardapioLugano.API.Services.Interfaces;
using CardapioLugano.Data.Persistence.Interfaces;
using CardapioLugano.Modelos.Models;

namespace CardapioLugano.API.Services;

public class CustomerService : ICustomerService
{
    private readonly IDal<Customer> _customer;

    public CustomerService(IDal<Customer> customer)
    {
        _customer = customer;
    }

    public async Task<Customer> CreateAsync(CustomerRequest request)
    {
        var customer = new Customer(request.Id)
        {
            Name = request.Name,
            Addresses = [ new Address(
                string.Empty, 
                request.Address.Number,
                string.Empty,
                request.Address.Bairro,
                request.Address.Street)]
        };

        var document = await _customer.CreateDocument(customer);

        return (Customer)document;
    }
}
