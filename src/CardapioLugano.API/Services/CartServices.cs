using Appwrite;
using CardapioLugano.API.Requests;
using CardapioLugano.API.Services.Interfaces;
using CardapioLugano.Data.Persistence.Interfaces;
using CardapioLugano.Modelos.Models;
using CardapioLugano.API.Responses;

namespace CardapioLugano.API.Services;

public class CartServices : ICartServices
{
    private readonly IDal<Cart> _cartDal;

    public CartServices(IDal<Cart> cartDal)
    {
        _cartDal = cartDal;
    }

    public async Task<Response<CartResponse>> AddCartItem(CartItemRequest cartItemRequest)
    {
        CartItem cartItem = 
            new(cartItemRequest.ProductId, 1, cartItemRequest.UnitPrice, cartItemRequest.Name);

        var cartDocument = await _cartDal.ListDocuments();

        if (cartDocument is null or { Total: 0 })
            throw new AppwriteException(message:"Não há nenhum carrinho existente", code:500);

        var cart = (Cart)cartDocument.Documents!.FirstOrDefault(x => x.Id == cartItemRequest.CartId)! ?? cartDocument.Documents.First();

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

        return new Response<CartResponse>(result);
    }
}
