using Appwrite;
using CardapioLugano.API.Requests;
using CardapioLugano.API.Responses;
using CardapioLugano.API.Services.Interfaces;
using CardapioLugano.Data.Persistence.Interfaces;
using CardapioLugano.Modelos.Modelos;

namespace CardapioLugano.API.Services;

public class CartServices : ICartServices
{
    private readonly IDal<Cart> _cartDal;

    public CartServices(IDal<Cart> cartDal)
    {
        _cartDal = cartDal;
    }

    public async Task<CartResponse> AddCartItem(CartItemRequest cartItemRequest)
    {
        CartItem cartItem = 
            new CartItem(cartItemRequest.ProductId, cartItemRequest.Quantity, cartItemRequest.UnitPrice, cartItemRequest.Name);

        var cartDocument = await _cartDal.ListDocuments();

        if (cartDocument is null or { Total: 0 })
            throw new AppwriteException(message:"Não há nenhum carrinho existente", code:500);

        var cart = (Cart)cartDocument.Documents.First();

        var (Exists, Id) = cart.CartItemsExists(cartItem);


        if(!Exists && string.IsNullOrEmpty(Id))
        {
            cart.AddCartItem(cartItem);
            
        }
        else
        {
            cartItem.Id = Id;
            cart.AddCartItem(cartItem);
        }

        var result = (Cart)await _cartDal.UpdateDocument(cart.Id!, cart);

        return result;
    }
}
