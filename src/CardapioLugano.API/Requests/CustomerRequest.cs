namespace CardapioLugano.API.Requests;

public record CustomerRequest(string Id, string Name, AddressRequest Address);
