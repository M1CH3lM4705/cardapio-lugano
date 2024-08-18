namespace CardapioLugano.Shared.Requests;

public record CustomerRequest(string Id, string Name, AddressRequest Address);
